using System;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pr_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDefaults();
        }
        private void InitializeDefaults()
        {
            txtLambda.Text = "0.002";
            txtMu.Text = "0.05";
            txtTime.Text = "100";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                CultureInfo invariantCulture = CultureInfo.InvariantCulture;

                double lambda;
                if (!double.TryParse(txtLambda.Text, NumberStyles.Any, invariantCulture, out lambda))
                {
                    MessageBox.Show("Неверный формат числа в поле λ (интенсивность отказов). Используйте точку в качестве десятичного разделителя.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLambda.Focus();
                    return;
                }

                double mu;
                if (!double.TryParse(txtMu.Text, NumberStyles.Any, invariantCulture, out mu))
                {
                    MessageBox.Show("Неверный формат числа в поле μ (интенсивность восстановления). Используйте точку в качестве десятичного разделителя.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMu.Focus();
                    return;
                }

                double time;
                if (!double.TryParse(txtTime.Text, NumberStyles.Any, invariantCulture, out time))
                {
                    MessageBox.Show("Неверный формат числа в поле времени. Используйте точку в качестве десятичного разделителя.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTime.Focus();
                    return;
                }

                if (lambda <= 0 || mu <= 0 || time < 0)
                {
                    MessageBox.Show("Значения должны быть положительными (λ > 0, μ > 0, время ≥ 0).",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double p1Stationary = mu / (lambda + mu);
                double p2Stationary = lambda / (lambda + mu);

                double p1_t = p1Stationary + (1 - p1Stationary) * Math.Exp(-(lambda + mu) * time);
                double p2_t = 1 - p1_t;

                string equations = $"dP₁(t)/dt = -{lambda:F4}·P₁(t) + {mu:F4}·P₂(t)\n" +
                                   $"dP₂(t)/dt =  {lambda:F4}·P₁(t) - {mu:F4}·P₂(t)";
                txtEquations.Text = equations;

                lblP1Stationary.Text = $"P₁ (стационарная) = {p1Stationary:F4}";
                lblP2Stationary.Text = $"P₂ (стационарная) = {p2Stationary:F4}";
                lblP1Time.Text = $"P₁({time} ч) = {p1_t:F4}";
                lblP2Time.Text = $"P₂({time} ч) = {p2_t:F4}";
                lblKg.Text = $"Коэффициент готовности Kг = {p1Stationary:F4}";
                lblKp.Text = $"Коэффициент простоя Kп = {p2Stationary:F4}";

                DrawGraph(lambda, mu, time);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DrawGraph(double lambda, double mu, double maxTime)
        {
            chartPanel.Controls.Clear();

            PictureBox chart = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.White,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            int panelWidth = chartPanel.Width > 0 ? chartPanel.Width : 459;
            int panelHeight = chartPanel.Height > 0 ? chartPanel.Height : 150;

            using (var bmp = new System.Drawing.Bitmap(panelWidth, panelHeight))
            using (var g = System.Drawing.Graphics.FromImage(bmp))
            {
                g.Clear(System.Drawing.Color.White);
                g.DrawString("График вероятностей состояний во времени",
                    new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold),
                    System.Drawing.Brushes.Black, 10, 10);

                int margin = 40;
                int width = bmp.Width - 2 * margin;
                int height = bmp.Height - 2 * margin - 30;

                g.DrawLine(System.Drawing.Pens.Black, margin, bmp.Height - margin,
                    bmp.Width - margin, bmp.Height - margin);
                g.DrawLine(System.Drawing.Pens.Black, margin, margin,
                    margin, bmp.Height - margin);

                double p1_inf = mu / (lambda + mu);
                int points = 50;

                for (int i = 0; i < points - 1; i++)
                {
                    double t1 = i * maxTime / points;
                    double t2 = (i + 1) * maxTime / points;

                    double p1_t1 = p1_inf + (1 - p1_inf) * Math.Exp(-(lambda + mu) * t1);
                    double p1_t2 = p1_inf + (1 - p1_inf) * Math.Exp(-(lambda + mu) * t2);

                    int x1 = margin + (int)(i * width / (double)points);
                    int x2 = margin + (int)((i + 1) * width / (double)points);
                    int y1 = bmp.Height - margin - (int)(p1_t1 * height);
                    int y2 = bmp.Height - margin - (int)(p1_t2 * height);

                    g.DrawLine(new System.Drawing.Pen(System.Drawing.Color.Blue, 2), x1, y1, x2, y2);
                }

                g.DrawString("P₁(t) — работоспособное состояние",
                    new System.Drawing.Font("Arial", 7F),
                    new System.Drawing.SolidBrush(System.Drawing.Color.Blue),
                    margin, bmp.Height - margin + 10);
                g.DrawString($"Стационарное значение: {p1_inf:F4}",
                    new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Italic),
                    System.Drawing.Brushes.DarkGreen,
                    margin, bmp.Height - margin + 25);

                chart.Image = new System.Drawing.Bitmap(bmp);
            }

            chartPanel.Controls.Add(chart);
        }
    }
}
