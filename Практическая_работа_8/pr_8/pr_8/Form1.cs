using System;
using System.Collections.Generic;
using System.Windows.Forms;
using pr_8.Models;
using pr_8.Services;

namespace pr_8
{
    public partial class Form1 : Form
    {
        private readonly DeliveryService _deliveryService;
        private readonly List<HistoryItem> _history;
        private Dictionary<string, double> _transportRates;

        public Form1()
        {
            InitializeComponent();
            _deliveryService = new DeliveryService();
            _history = new List<HistoryItem>();
            InitializeTransportRates();
            cmbTransport.SelectedIndex = 0;
        }
        private void InitializeTransportRates()
        {
            _transportRates = new Dictionary<string, double>
            {
                { "Автомобиль (40 руб./км)", 40 },
                { "Грузовик (60 руб./км)", 60 },
                { "Мотоцикл (25 руб./км)", 25 }
            };
        }

        private void cmbTransport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransport.SelectedItem != null)
            {
                string selected = cmbTransport.SelectedItem.ToString();
                lblRate.Text = $"{_transportRates[selected]} руб./км";
            }
        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFrom.Text) || 
                    string.IsNullOrWhiteSpace(txtTo.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните оба поля адресов!", 
                        "Ошибка ввода", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    return;
                }

                lblStatus.Text = "Поиск маршрута...";
                btnCalculate.Enabled = false;
                Application.DoEvents();

                string fromText = txtFrom.Text.Trim();
                string toText = txtTo.Text.Trim();

                Coordinates fromCoords = _deliveryService.IsCoordinates(fromText) 
                    ? _deliveryService.ParseCoordinates(fromText)
                    : await System.Threading.Tasks.Task.Run(() => 
                        _deliveryService.GeocodeAddress(fromText));

                Coordinates toCoords = _deliveryService.IsCoordinates(toText)
                    ? _deliveryService.ParseCoordinates(toText)
                    : await System.Threading.Tasks.Task.Run(() => 
                        _deliveryService.GeocodeAddress(toText));

                lblStatus.Text = "Построение маршрута...";
                Application.DoEvents();

                RouteInfo route = await System.Threading.Tasks.Task.Run(() => 
                    _deliveryService.GetRoute(fromCoords, toCoords, fromText, toText));

                string selectedTransport = cmbTransport.SelectedItem.ToString();
                double rate = _transportRates[selectedTransport];
                string transportName = selectedTransport.Split('(')[0].Trim();
                
                DeliveryResult result = _deliveryService.CalculateDelivery(route, transportName, rate);

                DisplayResult(result, route);

                AddToHistory(route, selectedTransport, result.Cost);

                lblStatus.Text = "Расчет завершен";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", 
                    "Ошибка расчета", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                lblStatus.Text = "Ошибка расчета";
            }
            finally
            {
                btnCalculate.Enabled = true;
            }
        }

        private void DisplayResult(DeliveryResult result, RouteInfo route)
        {
            string resultText = string.Format(
                "📍 Откуда: {0}\n\n" +
                "📍 Куда: {1}\n\n" +
                "📏 Расстояние: {2:F1} км\n\n" +
                "⏱ Время в пути: {3:F1} ч ({4:F0} мин)\n\n" +
                "💰 Стоимость: {5:F0} руб.\n\n" +
                "🚚 Транспорт: {6}",
                route.FromAddress,
                route.ToAddress,
                result.Distance,
                result.TimeHours,
                result.TimeHours * 60,
                result.Cost,
                result.TransportType);

            lblResult.Text = resultText;
        }

        private void AddToHistory(RouteInfo route, string transport, double cost)
        {
            var historyItem = new HistoryItem
            {
                From = route.FromAddress,
                To = route.ToAddress,
                Transport = transport,
                Distance = route.Distance,
                Cost = cost,
                Date = DateTime.Now
            };

            _history.Add(historyItem);
            UpdateHistoryList();
        }

        private void UpdateHistoryList()
        {
            lstHistory.Items.Clear();
            foreach (var item in _history)
            {
                lstHistory.Items.Add(item.ToString());
            }
        }

        private void lstHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHistory.SelectedIndex >= 0 && lstHistory.SelectedIndex < _history.Count)
            {
                var item = _history[lstHistory.SelectedIndex];
                txtFrom.Text = item.From;
                txtTo.Text = item.To;
                
                foreach (var transport in cmbTransport.Items)
                {
                    if (transport.ToString().Contains(item.Transport))
                    {
                        cmbTransport.SelectedItem = transport;
                        break;
                    }
                }

                MessageBox.Show("Данные загружены из истории. Нажмите 'Рассчитать' для повторного расчета.", 
                    "Загрузка из истории", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFrom.Clear();
            txtTo.Clear();
            cmbTransport.SelectedIndex = 0;
            lblResult.Text = "Результат появится здесь...";
            lblStatus.Text = "Готов";
            txtFrom.Focus();
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            if (_history.Count > 0)
            {
                var result = MessageBox.Show("Очистить историю расчетов?", 
                    "Подтверждение", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _history.Clear();
                    lstHistory.Items.Clear();
                    lblStatus.Text = "История очищена";
                }
            }
        }
    }
}
