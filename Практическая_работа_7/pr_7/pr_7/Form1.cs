using System;
using System.Windows.Forms;

namespace pr_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения из полей ввода
                double N = double.Parse(txtN.Text.Replace(".", ","));
                double Nobn = double.Parse(txtNobn.Text.Replace(".", ","));

                // Валидация данных
                if (N <= 0)
                {
                    MessageBox.Show("Число ошибок N должно быть больше 0!", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Nobn < 0 || Nobn > N)
                {
                    MessageBox.Show("N_обн должно быть в диапазоне [0; N]!", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Расчёт коэффициента обнаружения
                double K_obn = Nobn / N;
                double percent = K_obn * 100;

                // Формируем результат
                string result = $"✅ Результат расчёта:\n\n" +
                               $"N (всего ошибок) = {N}\n" +
                               $"N_обн (обнаружено) = {Nobn}\n\n" +
                               $"K_обн = N_обн / N = {Nobn} / {N} = {K_obn:F4}\n\n" +
                               $"📊 Коэффициент обнаружения: {K_obn:F4} ({percent:F2}%)";

                lblResult.Text = result;
                lblResult.Visible = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые значения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtN.Text = "50";
            txtNobn.Text = "40";
            lblResult.Visible = false;
            lblResult.Text = "Результат появится здесь...";
            txtN.Focus();
        }
    }
}
