using System;
using System.Windows.Forms;

namespace pr_3
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
            txtMinWork.Text = "600";     
            txtMaxWork.Text = "3000";    
            txtAvgWork.Text = "1200";
            txtTargetTime.Text = "900";
            txtTotalItems.Text = "100";
        }

        private double Erf(double x)
        {
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            int sign = Math.Sign(x);
            x = Math.Abs(x);

            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        }

        private double NormalCdf(double x)
        {
            return 0.5 * (1.0 + Erf(x / Math.Sqrt(2.0)));
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(txtMinWork.Text, out double minWork) ||
                    !double.TryParse(txtMaxWork.Text, out double maxWork) ||
                    !double.TryParse(txtAvgWork.Text, out double avgWork) ||
                    !double.TryParse(txtTargetTime.Text, out double targetTime) ||
                    !int.TryParse(txtTotalItems.Text, out int totalItems))
                {
                    MessageBox.Show("Пожалуйста, введите корректные числовые значения!",
                                  "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (minWork >= maxWork)
                {
                    MessageBox.Show("Минимальная наработка должна быть меньше максимальной!",
                                  "Логическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (avgWork < minWork || avgWork > maxWork)
                {
                    MessageBox.Show("Средняя наработка должна находиться между минимальной и максимальной!",
                                  "Логическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (totalItems <= 0)
                {
                    MessageBox.Show("Количество изделий должно быть положительным!",
                                  "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double sigma = (maxWork - minWork) / 6.0;

                double u = (targetTime - avgWork) / sigma;

                double pReliable = NormalCdf(-u);  
                double pFailure = 1.0 - pReliable;

                int failedItems = (int)Math.Round(totalItems * pFailure);

                lblSigmaValue.Text = sigma.ToString("F2") + " ч";
                lblProbReliableValue.Text = pReliable.ToString("F4");
                lblProbFailureValue.Text = pFailure.ToString("F4");
                lblFailedItemsValue.Text = failedItems.ToString() + " из " + totalItems;
                lblUValue.Text = u.ToString("F3");

                lblMeanTimeValue.Text = avgWork.ToString("F0") + " ч";
                lblVarianceValue.Text = (sigma * sigma).ToString("F0") + " ч²";
                lblCoefficientValue.Text = (sigma / avgWork).ToString("F3");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при расчете: " + ex.Message,
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitializeDefaults();
            lblSigmaValue.Text = "";
            lblProbReliableValue.Text = "";
            lblProbFailureValue.Text = "";
            lblFailedItemsValue.Text = "";
            lblUValue.Text = "";
            lblMeanTimeValue.Text = "";
            lblVarianceValue.Text = "";
            lblCoefficientValue.Text = "";
        }
    }
}
