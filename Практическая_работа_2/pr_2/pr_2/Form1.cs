using System;
using System.Linq;
using System.Windows.Forms;

namespace pr_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalc1_Click(object sender, EventArgs e)
        {
            try
            {
                var values = txtTimes1.Text.Split(new[] { ' ', ',', ';', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length == 0)
                {
                    MessageBox.Show("Введите времена до отказов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double sum = values.Sum(v => double.Parse(v));
                double mtbf = sum / values.Length;
                lblResult1.Text = $"Средняя наработка на отказ (T₀): {mtbf:F2} часов";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalc2_Click(object sender, EventArgs e)
        {
            try
            {
                var lines = txtSystems2.Lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
                if (lines.Length == 0)
                {
                    MessageBox.Show("Введите данные по системам: \"наработка,число отказов\".", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double totalWork = 0;
                int totalFailures = 0;

                foreach (var line in lines)
                {
                    var parts = line.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 2)
                        throw new FormatException($"Неверный формат: \"{line}\"");

                    double work = double.Parse(parts[0].Trim());
                    int failures = int.Parse(parts[1].Trim());

                    totalWork += work;
                    totalFailures += failures;
                }

                if (totalFailures == 0)
                {
                    MessageBox.Show("Общее число отказов = 0 — расчёт невозможен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double mtbf = totalWork / totalFailures;
                lblResult2.Text = $"Общая наработка на отказ: {mtbf:F2} часов";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCalc3_Click(object sender, EventArgs e)
        {
            try
            {
                double t0_1 = double.Parse(txtT0_1.Text);
                double tv_1 = double.Parse(txtTv_1.Text);
                double t0_2 = double.Parse(txtT0_2.Text);
                double tv_2 = double.Parse(txtTv_2.Text);

                if (t0_1 <= 0 || t0_2 <= 0)
                    throw new ArgumentException("Время работы должно быть > 0");

                double kg1 = t0_1 / (t0_1 + tv_1);
                double kg2 = t0_2 / (t0_2 + tv_2);

                string res = $"Система 1: Kг = {kg1:F4}\nСистема 2: Kг = {kg2:F4}\n\n";
                res += kg1 > kg2 ? "✅ Система 1 надёжнее" : "✅ Система 2 надёжнее";
                lblResult3.Text = res;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
