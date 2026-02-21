using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace pr_6
{
    public partial class Form1 : Form
    {
        private List<Planet> planets;
        private float zoom = 1.0f;
        private float speedMultiplier = 1.0f;
        private bool isPaused = false;
        private int centerX, centerY;
        private const float baseOrbitRadius = 30f;
        private Random random = new Random();
        private List<PointF> stars = new List<PointF>();

        public Form1()
        {
            InitializeComponent();
            SetupEvents();
            InitializeSolarSystem();
            GenerateStars();
            UpdateCenter();
        }
        private void SetupEvents()
        {
            this.Paint += Form1_Paint;
            this.Resize += Form1_Resize;
            this.MouseWheel += Form1_MouseWheel;
            this.KeyDown += Form1_KeyDown;
            animationTimer.Tick += Timer_Tick;
            btnReset.Click += BtnReset_Click;
        }

        private void InitializeSolarSystem()
        {
            planets = new List<Planet>
            {
                new Planet("Меркурий", 1.0f, 0.050f, 8, Color.Gray, 0, ""),
                new Planet("Венера", 1.5f, 0.030f, 10, Color.Orange, 30, ""),
                new Planet("Земля", 2.0f, 0.020f, 11, Color.Blue, 60, ""),
                new Planet("Марс", 2.5f, 0.016f, 9, Color.Red, 90, ""),
                new Planet("Юпитер", 3.5f, 0.008f, 25, Color.Brown, 120, ""),
                new Planet("Сатурн", 4.5f, 0.006f, 22, Color.Gold, 150, ""),
                new Planet("Уран", 5.5f, 0.004f, 18, Color.Cyan, 180, ""),
                new Planet("Нептун", 6.5f, 0.003f, 17, Color.DarkBlue, 210, "")
            };
        }

        private void GenerateStars()
        {
            stars.Clear();
            for (int i = 0; i < 150; i++)
            {
                stars.Add(new PointF(
                    random.Next(this.ClientSize.Width),
                    random.Next(this.ClientSize.Height - 50)));
            }
        }

        private void UpdateCenter()
        {
            centerX = this.ClientSize.Width / 2;
            centerY = (this.ClientSize.Height - 50) / 2;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                foreach (var planet in planets)
                {
                    planet.Angle += planet.Speed * speedMultiplier;
                    if (planet.Angle >= 360)
                        planet.Angle -= 360;
                }
                this.Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Color.Black);

            // Звёзды
            foreach (var star in stars)
            {
                e.Graphics.FillEllipse(Brushes.White, star.X, star.Y, 2, 2);
            }

            // Орбиты
            foreach (var planet in planets)
            {
                float orbitRadius = baseOrbitRadius * planet.OrbitRadius * zoom;
                e.Graphics.DrawEllipse(
                    new Pen(Color.FromArgb(80, 80, 100), 1),
                    centerX - orbitRadius,
                    centerY - orbitRadius,
                    orbitRadius * 2,
                    orbitRadius * 2);
            }

            // Солнце
            int sunSize = (int)(40 * zoom);
            using (var sunBrush = new SolidBrush(Color.Yellow))
            {
                e.Graphics.FillEllipse(sunBrush, centerX - sunSize, centerY - sunSize, sunSize * 2, sunSize * 2);
            }

            using (var glowPen = new Pen(Color.Orange, 3))
            {
                e.Graphics.DrawEllipse(glowPen,
                    centerX - sunSize - 5,
                    centerY - sunSize - 5,
                    (sunSize + 5) * 2,
                    (sunSize + 5) * 2);
            }

            // Планеты
            foreach (var planet in planets)
            {
                DrawPlanet(e.Graphics, planet);
            }

            // Информация
            DrawInfo(e.Graphics);
        }

        private void DrawPlanet(Graphics g, Planet planet)
        {
            float orbitRadius = baseOrbitRadius * planet.OrbitRadius * zoom;
            double angleRad = planet.Angle * (Math.PI / 180);

            float x = centerX + (float)Math.Cos(angleRad) * orbitRadius;
            float y = centerY + (float)Math.Sin(angleRad) * orbitRadius;

            float planetSize = planet.Size * zoom;
            if (planetSize < 4) planetSize = 4;
            if (planetSize > 40) planetSize = 40;

            using (var brush = new SolidBrush(planet.Color))
            using (var pen = new Pen(Color.White, 1))
            {
                g.FillEllipse(brush, x - planetSize / 2, y - planetSize / 2, planetSize, planetSize);
                g.DrawEllipse(pen, x - planetSize / 2, y - planetSize / 2, planetSize, planetSize);
            }

            if (planet.Name == "Сатурн")
            {
                g.DrawEllipse(new Pen(Color.LightGray, 2),
                    x - planetSize, y - planetSize / 3, planetSize * 2, planetSize / 1.5f);
            }

            if (zoom > 0.7f)
            {
                g.DrawString(planet.Name, new Font("Segoe UI", 8),
                    Brushes.White, x - 20, y + planetSize + 5);
            }
        }

        private void DrawInfo(Graphics g)
        {
            string info = $"Масштаб: {zoom:F1}x | Скорость: {speedMultiplier:F1}x | " +
                         $"Планет: {planets.Count} | {(isPaused ? "⏸ ПАУЗА" : "▶ ИДЁТ")}";
            g.DrawString(info, new Font("Segoe UI", 9, FontStyle.Bold),
                Brushes.LightGreen, 10, 10);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateCenter();
            GenerateStars();
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                zoom = Math.Min(zoom * 1.1f, 3.0f);
            else
                zoom = Math.Max(zoom / 1.1f, 0.3f);
            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                case Keys.Oemplus:
                    speedMultiplier = Math.Min(speedMultiplier * 1.2f, 5.0f);
                    break;
                case Keys.Subtract:
                case Keys.OemMinus:
                    speedMultiplier = Math.Max(speedMultiplier / 1.2f, 0.1f);
                    break;
                case Keys.P:
                    isPaused = !isPaused;
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.R:
                    zoom = 1.0f;
                    speedMultiplier = 1.0f;
                    isPaused = false;
                    break;
            }
            this.Invalidate();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            zoom = 1.0f;
            speedMultiplier = 1.0f;
            isPaused = false;
            this.Invalidate();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            animationTimer?.Stop();
            base.OnFormClosing(e);
        }
    }
}