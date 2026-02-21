using System;
using System.Drawing;
using System.Windows.Forms;

namespace prakt_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string DetermineMotionType(double v0, double a, double t)
        {
            const double epsilon = 0.001;

            if (Math.Abs(v0) < epsilon && Math.Abs(a) > epsilon && a > 0)
                return "Движение из состояния покоя";

            if (Math.Abs(v0 + a * t) < epsilon && a < 0)
                return "Торможение до полной остановки";

            if (Math.Abs(a) < epsilon)
                return "Равномерное прямолинейное движение";

            if (a > epsilon)
                return "Равноускоренное движение";

            if (a < -epsilon)
                return "Равнозамедленное движение";

            return "Неопределённый тип движения";
        }

        private string GenerateDescription(double v0, double a, double t, double s, double v)
        {
            var desc = new System.Text.StringBuilder();
            desc.AppendLine($"Тело начало движение со скоростью {v0:F2} м/с.");

            if (a > 0)
                desc.AppendLine($"Ускорение {a:F2} м/с² вызывает равномерный рост скорости.");
            else if (a < 0)
                desc.AppendLine($"Замедление {Math.Abs(a):F2} м/с² вызывает равномерное снижение скорости.");
            else
                desc.AppendLine("Скорость остаётся постоянной (ускорение отсутствует).");

            desc.AppendLine($"За время {t:F2} с тело прошло путь {s:F2} м.");
            desc.AppendLine($"Конечная скорость составила {v:F2} м/с.");

            if (v < 0)
                desc.AppendLine("⚠ Внимание: отрицательная конечная скорость означает изменение направления движения.");

            return desc.ToString();
        }


        private double CalculatePath(double v0, double a, double t)
        {
            return v0 * t + 0.5 * a * t * t;
        }


        private double CalculateFinalVelocity(double v0, double a, double t)
        {
            return v0 + a * t;
        }


        private void DrawGraph(double v0, double a, double t)
        {
            pictureBoxGraph.Image = null;

            if (t <= 0) return;

            Bitmap bmp = new Bitmap(pictureBoxGraph.Width, pictureBoxGraph.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                int margin = 40;
                int graphWidth = bmp.Width - 2 * margin;
                int graphHeight = bmp.Height - 2 * margin;
                int pointCount = 100;

                double maxS = 0;
                for (int i = 0; i <= pointCount; i++)
                {
                    double time = t * i / pointCount;
                    double s = CalculatePath(v0, a, time);

                    if (s > maxS) maxS = s;
                }
                if (maxS == 0)
                {
                    double minS = 0;
                    for (int i = 0; i <= pointCount; i++)
                    {
                        double time = t * i / pointCount;
                        double s = CalculatePath(v0, a, time);
                        if (s < minS) minS = s;
                    }
                    maxS = Math.Abs(minS) * 1.2; 
                }
                else
                {
                    maxS *= 1.1; 
                }
                if (maxS < 1.0) maxS = 1.0; 

                float scaleX = (float)(graphWidth / t);
                float scaleY = (float)(graphHeight / maxS); 

                int zeroY = bmp.Height - margin; 

                Pen axisPen = new Pen(Color.Black, 1.5f);
                Pen gridPen = new Pen(Color.LightGray, 0.5f);

                g.DrawLine(axisPen, margin, zeroY, bmp.Width - margin, zeroY);

                g.DrawLine(axisPen, margin, bmp.Height - margin, margin, margin);

                int divisionsX = 10;
                for (int i = 1; i <= divisionsX; i++)
                {
                    int x = margin + (int)(i * graphWidth / divisionsX);
                    g.DrawLine(gridPen, x, margin, x, bmp.Height - margin);
                    g.DrawString((t * i / divisionsX).ToString("F1"), Font, Brushes.Black, x - 12, zeroY + 5);
                }

                int divisionsY = 8;
                for (int i = 1; i <= divisionsY; i++)
                {
                    double sValue = maxS * i / divisionsY;
                    int y = zeroY - (int)(sValue * scaleY);
                    if (y < margin) continue;
                    g.DrawLine(gridPen, margin, y, bmp.Width - margin, y);
                    g.DrawString(sValue.ToString("F1"), Font, Brushes.Black, 5, y - 6);
                }

                g.DrawString("Время t (с)", Font, Brushes.Black, bmp.Width / 2 - 30, bmp.Height - 20);
                g.DrawString("Путь S (м)", Font, Brushes.Black, 5, bmp.Height / 2 - 10);

                PointF[] points = new PointF[pointCount + 1];
                for (int i = 0; i <= pointCount; i++)
                {
                    double time = t * i / pointCount;
                    double s = CalculatePath(v0, a, time);
                    int x = margin + (int)(time * scaleX);
                    int y = zeroY - (int)(s * scaleY); 

                    if (y < margin) y = margin;
                    if (y > bmp.Height - margin) y = bmp.Height - margin;

                    points[i] = new PointF(x, y);
                }

                g.DrawLines(new Pen(Color.Blue, 2), points);

                g.FillEllipse(Brushes.Red, points[0].X - 4, points[0].Y - 4, 8, 8);
                g.FillEllipse(Brushes.Red, points[pointCount / 2].X - 4, points[pointCount / 2].Y - 4, 8, 8);
                g.FillEllipse(Brushes.Red, points[pointCount].X - 4, points[pointCount].Y - 4, 8, 8);

                string equation = $"S(t) = {v0:F2}·t + ({a:F2}·t²)/2";
                g.DrawString(equation, new Font(Font.FontFamily, 9, FontStyle.Bold), Brushes.DarkGreen,
                    new PointF(margin, bmp.Height - margin + 5));
            }

            pictureBoxGraph.Image = bmp;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtInitialVelocity.Text, out double v0))
            {
                MessageBox.Show("Введите корректное значение начальной скорости!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtAcceleration.Text, out double a))
            {
                MessageBox.Show("Введите корректное значение ускорения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtTime.Text, out double t) || t < 0)
            {
                MessageBox.Show("Время должно быть положительным числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t == 0)
            {
                lblMotionType.Text = "Тип движения: —";
                lblPath.Text = "Пройденный путь: 0.00 м";
                lblFinalVelocity.Text = "Конечная скорость: " + v0.ToString("F2") + " м/с";
                lblDescription.Text = "Время движения равно нулю. Тело не переместилось.";
                pictureBoxGraph.Image = null;
                return;
            }

            double s = CalculatePath(v0, a, t);
            double v = CalculateFinalVelocity(v0, a, t);
            string motionType = DetermineMotionType(v0, a, t);
            string description = GenerateDescription(v0, a, t, s, v);

            lblMotionType.Text = $"Тип движения: {motionType}";
            lblPath.Text = $"Пройденный путь: {s:F2} м";
            lblFinalVelocity.Text = $"Конечная скорость: {v:F2} м/с";
            lblDescription.Text = description;

            DrawGraph(v0, a, t);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInitialVelocity.Text = "0";
            txtAcceleration.Text = "0";
            txtTime.Text = "5";

            lblMotionType.Text = "Тип движения: —";
            lblPath.Text = "Пройденный путь: —";
            lblFinalVelocity.Text = "Конечная скорость: —";
            lblDescription.Text = "Результаты расчёта появятся здесь после нажатия кнопки \"Рассчитать\".";

            pictureBoxGraph.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtInitialVelocity.Text = "0";
            txtAcceleration.Text = "0";
            txtTime.Text = "5";
            lblMotionType.Text = "Тип движения: —";
            lblPath.Text = "Пройденный путь: —";
            lblFinalVelocity.Text = "Конечная скорость: —";
            lblDescription.Text = "Введите параметры движения и нажмите \"Рассчитать\".";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
