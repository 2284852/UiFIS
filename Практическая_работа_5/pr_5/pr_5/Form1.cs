using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static pr_5.Models;

namespace pr_5
{
    public partial class Form1 : Form
    {
        private readonly NetworkSimulator _simulator = new NetworkSimulator();
        private readonly Timer _animationTimer = new Timer { Interval = 30 };
        private readonly Timer _packetGeneratorTimer = new Timer();
        private bool _isRunning = false;
        private readonly Random _random = new Random();
        private readonly HashSet<int> _loggedPackets = new HashSet<int>();
        private readonly HashSet<int> _loggedSwitchArrivals = new HashSet<int>();

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            SetupTimers();
        }
        private void InitializeUI()
        {
            logTextBox.BackColor = Color.Black;
            logTextBox.ForeColor = Color.Cyan;
            logTextBox.Font = new Font("Consolas", 9.5F);

            speedTrackBar.Minimum = 1;
            speedTrackBar.Maximum = 10;
            speedTrackBar.Value = 5;
            speedValueLabel.Text = speedTrackBar.Value.ToString();

            networkPanel.Paint += networkPanel_Paint;
        }

        private void SetupTimers()
        {
            _animationTimer.Tick += AnimationTimer_Tick;
            _packetGeneratorTimer.Tick += PacketGeneratorTimer_Tick;
        }

        private void networkPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.Clear(Color.White);

            var switchPos = new Point(310, 210);
            var pen = new Pen(Color.Gray, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot };

            foreach (var device in _simulator.GetAllDevices())
            {
                if (device.Type == DeviceType.PC)
                {
                    g.DrawLine(pen, device.X, device.Y, switchPos.X, switchPos.Y);
                }
            }

            foreach (var pc in _simulator.GetAllDevices().Where(d => d.Type == DeviceType.PC))
            {
                Brush brush = pc.IsActive ? Brushes.LightGreen : Brushes.LightGray;
                g.FillRectangle(brush, pc.X - 30, pc.Y - 30, 60, 60);
                g.DrawRectangle(Pens.Black, pc.X - 30, pc.Y - 30, 60, 60);

                g.FillRectangle(Brushes.White, pc.X - 25, pc.Y - 35, 50, 40); 
                g.DrawRectangle(Pens.Black, pc.X - 25, pc.Y - 35, 50, 40);
                g.FillRectangle(Brushes.DarkGray, pc.X - 20, pc.Y + 10, 40, 15); 

                g.DrawString(pc.Name, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, pc.X - 25, pc.Y - 55);
            }

            var sw = _simulator.GetAllDevices().First(d => d.Type == DeviceType.Switch);
            Brush swBrush = sw.IsActive ? Brushes.LightBlue : Brushes.CadetBlue;
            g.FillRectangle(swBrush, sw.X - 50, sw.Y - 25, 100, 50);
            g.DrawRectangle(Pens.Black, sw.X - 50, sw.Y - 25, 100, 50);
            g.DrawString("SWITCH", new Font("Arial", 11, FontStyle.Bold), Brushes.White, sw.X - 42, sw.Y - 22);

            for (int i = 0; i < 4; i++)
            {
                Brush ledBrush = _random.Next(20) > 15 ? Brushes.LimeGreen : Brushes.Red;
                g.FillEllipse(ledBrush, sw.X - 40 + i * 25, sw.Y + 30, 12, 12);
                g.DrawEllipse(Pens.Black, sw.X - 40 + i * 25, sw.Y + 30, 12, 12);
            }

            foreach (var packet in _simulator.ActivePackets.ToList())
            {
                Color packetColor = GetPacketColor(packet.Source.Name, packet.Destination.Name);
                Brush packetBrush = new SolidBrush(packetColor);

                g.FillEllipse(packetBrush, packet.CurrentX - 12, packet.CurrentY - 12, 24, 24);
                g.DrawEllipse(Pens.Black, packet.CurrentX - 12, packet.CurrentY - 12, 24, 24);
                g.DrawString(packet.Id.ToString(), new Font("Arial", 9, FontStyle.Bold), Brushes.White,
                    packet.CurrentX - 8, packet.CurrentY - 10);
            }
        }

        private Color GetPacketColor(string source, string dest)
        {
            if (source == "ПК1" && dest == "ПК2") return Color.OrangeRed;
            if (source == "ПК1" && dest == "ПК3") return Color.Orange;
            if (source == "ПК1" && dest == "ПК4") return Color.Gold;
            if (source == "ПК2" && dest == "ПК1") return Color.DeepSkyBlue;
            if (source == "ПК2" && dest == "ПК3") return Color.DodgerBlue;
            if (source == "ПК2" && dest == "ПК4") return Color.RoyalBlue;
            if (source == "ПК3" && dest == "ПК1") return Color.MediumPurple;
            if (source == "ПК3" && dest == "ПК2") return Color.DarkOrchid;
            if (source == "ПК3" && dest == "ПК4") return Color.Indigo;
            if (source == "ПК4" && dest == "ПК1") return Color.LimeGreen;
            if (source == "ПК4" && dest == "ПК2") return Color.ForestGreen;
            if (source == "ПК4" && dest == "ПК3") return Color.DarkGreen;
            return Color.Silver;
        }

        private void LogMessage(string message)
        {
            if (logTextBox.InvokeRequired)
            {
                logTextBox.Invoke(new Action(() => LogMessage(message)));
                return;
            }

            string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
            logTextBox.AppendText($"[{timestamp}] {message}{Environment.NewLine}");
            logTextBox.SelectionStart = logTextBox.Text.Length;
            logTextBox.ScrollToCaret();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            var packetsToRemove = new List<Packet>();

            foreach (var packet in _simulator.ActivePackets.ToList())
            {
                if (!_loggedPackets.Contains(packet.Id))
                {
                    LogMessage($"Пакет #{packet.Id}: {packet.Source.Name} -> {packet.Destination.Name}, Размер: {packet.Size} байт");
                    _loggedPackets.Add(packet.Id);
                }

                if (packet.HasReachedSwitch && !_loggedSwitchArrivals.Contains(packet.Id))
                {
                    LogMessage($"Пакет #{packet.Id} достиг коммутатора SWITCH");
                    _loggedSwitchArrivals.Add(packet.Id);
                }

                _simulator.UpdatePacketPosition(packet);

                if (packet.ReceivedTime.HasValue && (DateTime.Now - packet.ReceivedTime.Value).TotalSeconds > 0.8)
                {
                    packetsToRemove.Add(packet);
                }
            }

            foreach (var packet in packetsToRemove)
            {
                _simulator.ActivePackets.Remove(packet);
                var delay = packet.GetDelay();
                if (delay.HasValue)
                {
                    LogMessage($"Пакет #{packet.Id} доставлен на {packet.Destination.Name} (задержка: {delay} мс)");
                }
                packet.Source.IsActive = false;
                packet.Destination.IsActive = false;
                _loggedPackets.Remove(packet.Id);
                _loggedSwitchArrivals.Remove(packet.Id);
            }

            networkPanel.Invalidate();
        }

        private void PacketGeneratorTimer_Tick(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                var packet = _simulator.GeneratePacket();
                _simulator.ActivePackets.Add(packet);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!_isRunning)
            {
                _simulator.ResetStatistics();
                _simulator.ActivePackets.Clear();
                _loggedPackets.Clear();
                _loggedSwitchArrivals.Clear();
                logTextBox.Clear();
                _isRunning = true;
                startButton.Enabled = false;
                stopButton.Enabled = true;

                int interval = 1000 / speedTrackBar.Value;
                _packetGeneratorTimer.Interval = interval;
                _packetGeneratorTimer.Start();
                _animationTimer.Start();

                LogMessage("Симуляция сети запущена");
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                _isRunning = false;
                _packetGeneratorTimer.Stop();
                _animationTimer.Stop();
                startButton.Enabled = true;
                stopButton.Enabled = false;

                LogMessage("=== ИТОГОВАЯ СТАТИСТИКА ===");
                LogMessage($"Всего отправлено пакетов: {_simulator.TotalPacketsSent}");
                LogMessage($"Успешно доставлено: {_simulator.TotalPacketsDelivered}");
                LogMessage($"Потеряно: {_simulator.TotalPacketsSent - _simulator.TotalPacketsDelivered}");
                LogMessage("Симуляция остановлена");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
            _simulator.ActivePackets.Clear();
            _loggedPackets.Clear();
            _loggedSwitchArrivals.Clear();
            foreach (var device in _simulator.GetAllDevices())
                device.IsActive = false;
            networkPanel.Invalidate();
        }

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            speedValueLabel.Text = speedTrackBar.Value.ToString();
            if (_isRunning)
            {
                int interval = 1000 / speedTrackBar.Value;
                _packetGeneratorTimer.Interval = interval;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _packetGeneratorTimer.Stop();
            _animationTimer.Stop();
        }
    }
}
