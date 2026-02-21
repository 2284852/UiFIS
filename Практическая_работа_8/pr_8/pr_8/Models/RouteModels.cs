using System;
using System.Collections.Generic;

namespace pr_8.Models
{
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Coordinates(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }

        public override string ToString()
        {
            return $"{Latitude}, {Longitude}";
        }
    }


    public class RouteInfo
    {
        public double Distance { get; set; }           // Расстояние в км
        public double Duration { get; set; }           // Время в секундах
        public string FromAddress { get; set; }        // Адрес отправления
        public string ToAddress { get; set; }          // Адрес назначения
        public DateTime CalculationTime { get; set; }  // Время расчета

        public RouteInfo()
        {
            CalculationTime = DateTime.Now;
        }
    }

    public class DeliveryResult
    {
        public double Distance { get; set; }      // Расстояние (км)
        public double TimeHours { get; set; }     // Время (часы)
        public double Cost { get; set; }          // Стоимость (руб)
        public string TransportType { get; set; } // Тип транспорта
    }

    public class HistoryItem
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Transport { get; set; }
        public double Distance { get; set; }
        public double Cost { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Date:dd.MM.yyyy HH:mm} | {From} → {To} | {Transport} | {Distance:F1} км | {Cost:F0} руб.";
        }
    }
}
