using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using pr_8.Models;
using System.Web.Script.Serialization;
using System.IO;
using System.Globalization;


namespace pr_8.Services
{
    public class DeliveryService
    {
        private const string NOMINATIM_URL = "https://nominatim.openstreetmap.org/search?format=json&q=";
        private const string OSRM_URL = "https://router.project-osrm.org/route/v1/driving/";

        private readonly JavaScriptSerializer _jsonSerializer;

        public DeliveryService()
        {
            _jsonSerializer = new JavaScriptSerializer();
            _jsonSerializer.MaxJsonLength = int.MaxValue;
        }

        public Coordinates GeocodeAddress(string address)
        {
            try
            {
                string encodedAddress = Uri.EscapeDataString(address);
                string url = NOMINATIM_URL + encodedAddress + "&limit=1";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "DeliveryCalculator/1.0";
                request.Accept = "application/json";
                request.Timeout = 10000;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string jsonResponse = reader.ReadToEnd();
                    var results = _jsonSerializer.Deserialize<ArrayList>(jsonResponse);

                    if (results.Count > 0)
                    {
                        var result = (Dictionary<string, object>)results[0];

                        string latStr = result["lat"].ToString();
                        string lonStr = result["lon"].ToString();

                        double lat = double.Parse(latStr, CultureInfo.InvariantCulture);
                        double lon = double.Parse(lonStr, CultureInfo.InvariantCulture);

                        return new Coordinates(lat, lon);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при поиске адреса '{address}': {ex.Message}");
            }

            throw new Exception($"Адрес не найден: {address}");
        }


        public RouteInfo GetRoute(Coordinates from, Coordinates to, string fromAddress, string toAddress)
        {
            try
            {
                string lon1 = from.Longitude.ToString("F6", CultureInfo.InvariantCulture);
                string lat1 = from.Latitude.ToString("F6", CultureInfo.InvariantCulture);
                string lon2 = to.Longitude.ToString("F6", CultureInfo.InvariantCulture);
                string lat2 = to.Latitude.ToString("F6", CultureInfo.InvariantCulture);

                string url = $"{OSRM_URL}{lon1},{lat1};{lon2},{lat2}?overview=false&alternatives=false";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Accept = "application/json";
                request.UserAgent = "DeliveryCalculator/1.0";
                request.Timeout = 15000;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string jsonResponse = reader.ReadToEnd();
                    var result = _jsonSerializer.Deserialize<Dictionary<string, object>>(jsonResponse);

                    if (result.ContainsKey("routes"))
                    {
                        var routes = (ArrayList)result["routes"];
                        if (routes.Count > 0)
                        {
                            var route = (Dictionary<string, object>)routes[0];

                            return new RouteInfo
                            {
                                Distance = Convert.ToDouble(route["distance"]) / 1000.0,
                                Duration = Convert.ToDouble(route["duration"]),
                                FromAddress = fromAddress,
                                ToAddress = toAddress
                            };
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)ex.Response)
                    using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                    {
                        string error = reader.ReadToEnd();
                        throw new Exception($"OSRM API вернул ошибку {(int)errorResponse.StatusCode}: {error}");
                    }
                }
                throw new Exception($"Ошибка подключения к сервису маршрутизации: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при построении маршрута: {ex.Message}");
            }

            throw new Exception("Не удалось построить маршрут");
        }


        public bool IsCoordinates(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string[] parts = input.Split(',');
            if (parts.Length != 2)
                return false;

            double lat, lon;

            string latStr = parts[0].Trim().Replace(',', '.');
            string lonStr = parts[1].Trim().Replace(',', '.');

            if (!double.TryParse(latStr, NumberStyles.Float, CultureInfo.InvariantCulture, out lat))
                return false;

            if (!double.TryParse(lonStr, NumberStyles.Float, CultureInfo.InvariantCulture, out lon))
                return false;

            return lat >= -90 && lat <= 90 && lon >= -180 && lon <= 180;
        }


        public Coordinates ParseCoordinates(string input)
        {
            string[] parts = input.Split(',');

            string latStr = parts[0].Trim().Replace(',', '.');
            string lonStr = parts[1].Trim().Replace(',', '.');

            double lat = double.Parse(latStr, CultureInfo.InvariantCulture);
            double lon = double.Parse(lonStr, CultureInfo.InvariantCulture);

            return new Coordinates(lat, lon);
        }


        public DeliveryResult CalculateDelivery(RouteInfo route, string transportType, double ratePerKm)
        {
            double speedKmh = GetTransportSpeed(transportType);

            return new DeliveryResult
            {
                Distance = route.Distance,
                TimeHours = route.Distance / speedKmh,
                Cost = route.Distance * ratePerKm,
                TransportType = transportType
            };
        }

        private double GetTransportSpeed(string transportType)
        {
            switch (transportType.ToLower())
            {
                case "мотоцикл": return 60;
                case "автомобиль": return 80;
                case "грузовик": return 60;
                default: return 70;
            }
        }
    }
}
