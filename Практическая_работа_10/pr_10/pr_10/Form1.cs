using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace pr_10
{
    public partial class Form1 : Form
    {
        private List<Question> questions;
        private int currentQuestionIndex = 0;
        private int correctAnswersCount = 0;
        private const int TotalQuestions = 5;

        public Form1()
        {
            InitializeComponent();
            InitializeQuestions();
            LoadQuestion();
        }
        private void InitializeQuestions()
        {
            questions = new List<Question>
            {
                new Question(
                    "Что описывает стандарт IEEE 754?",
                    new string[]
                    {
                        "Кодирование текстовых символов",
                        "Представление чисел с плавающей точкой",
                        "Протоколы беспроводной связи",
                        "Требования к качеству ПО"
                    },
                    1),

                new Question(
                    "Для чего предназначен стандарт ASCII?",
                    new string[]
                    {
                        "Управление качеством производства",
                        "Кодирование символов латинского алфавита",
                        "Шифрование данных в сетях",
                        "Формат хранения изображений"
                    },
                    1),

                new Question(
                    "Что регламентирует стандарт ISO 9001?",
                    new string[]
                    {
                        "Систему менеджмента качества",
                        "Кодировку Unicode",
                        "Протоколы TCP/IP",
                        "Формат PDF-документов"
                    },
                    0),

                new Question(
                    "Стандарт IEEE 802.11 относится к:",
                    new string[]
                    {
                        "Проводным сетям Ethernet",
                        "Беспроводным сетям Wi-Fi",
                        "Базам данных SQL",
                        "Языкам программирования"
                    },
                    1),

                new Question(
                    "Главное преимущество стандарта Unicode:",
                    new string[]
                    {
                        "Поддержка только английских символов",
                        "Включение символов всех письменностей мира",
                        "Сжатие графических файлов",
                        "Ускорение работы процессора"
                    },
                    1)
            };
        }

        private void LoadQuestion()
        {
            if (currentQuestionIndex >= TotalQuestions)
            {
                ShowResult();
                return;
            }

            Question q = questions[currentQuestionIndex];

            lblQuestionNumber.Text = $"Вопрос {currentQuestionIndex + 1} из {TotalQuestions}";
            progressBar1.Value = currentQuestionIndex + 1;
            lblProgress.Text = $"Правильных ответов: {correctAnswersCount}";

            lblQuestionText.Text = q.QuestionText;

            radioButton1.Text = q.Answers[0];
            radioButton2.Text = q.Answers[1];
            radioButton3.Text = q.Answers[2];
            radioButton4.Text = q.Answers[3];

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;

            lblResult.Text = string.Empty;
            btnNext.Text = "Далее →";
            btnNext.Enabled = false; 
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int selectedIndex = -1;
            if (radioButton1.Checked) selectedIndex = 0;
            else if (radioButton2.Checked) selectedIndex = 1;
            else if (radioButton3.Checked) selectedIndex = 2;
            else if (radioButton4.Checked) selectedIndex = 3;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите вариант ответа!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isCorrect = questions[currentQuestionIndex].IsCorrect(selectedIndex);

            if (isCorrect)
            {
                correctAnswersCount++;
                lblResult.Text = "✓ Правильно!";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                lblResult.Text = $"✗ Неверно. Правильный ответ: {questions[currentQuestionIndex].Answers[questions[currentQuestionIndex].CorrectAnswerIndex]}";
                lblResult.ForeColor = Color.Red;
            }

            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;

            currentQuestionIndex++;

            Timer delayTimer = new Timer();
            delayTimer.Interval = 1000; 
            delayTimer.Tick += (s, args) =>
            {
                delayTimer.Stop();
                LoadQuestion(); 
            };
            delayTimer.Start();

            btnNext.Enabled = false;
        }

        private void ShowResult()
        {
            double percentage = (double)correctAnswersCount / TotalQuestions * 100;

            lblQuestionNumber.Text = "Тест завершён";
            lblQuestionText.Text = $"Ваш результат: {correctAnswersCount} из {TotalQuestions}";

            string grade = percentage >= 80 ? "Отлично!" :
                          percentage >= 60 ? "Хорошо" :
                          percentage >= 40 ? "Удовлетворительно" : "Необходимо повторить материал";

            lblResult.Text = $"{percentage:F1}% правильных ответов\n{grade}";
            lblResult.ForeColor = Color.Blue;
            lblProgress.Text = string.Empty;
            progressBar1.Value = TotalQuestions;

            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;

            btnNext.Text = "Пройти тест заново";
            btnNext.Click -= btnNext_Click;
            btnNext.Click += btnRestart_Click;
            btnNext.Enabled = true;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;

            currentQuestionIndex = 0;
            correctAnswersCount = 0;

            btnNext.Click -= btnRestart_Click;
            btnNext.Click += btnNext_Click;

            InitializeQuestions();
            LoadQuestion();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = radioButton1.Checked || radioButton2.Checked ||
                             radioButton3.Checked || radioButton4.Checked;
        }
    }
}
