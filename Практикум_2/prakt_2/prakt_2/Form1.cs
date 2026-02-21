using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace prakt_2
{
    public partial class Form1 : Form
    {
        private string originalWord = "";
        private List<Button> letterButtons = new List<Button>();
        private string currentAnswer = "";

        public Form1()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            string input = txtInputWord.Text.Trim();
            if (string.IsNullOrEmpty(input) || !input.All(char.IsLetter))
            {
                MessageBox.Show("Введите корректное слово (только буквы).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            originalWord = input.ToUpper();
            currentAnswer = "";
            lblAnswer.Text = "";
            lblStatus.Text = "";
            lblStatus.BackColor = System.Drawing.Color.Transparent;

            foreach (var btn in letterButtons)
                pnlLetters.Controls.Remove(btn);
            letterButtons.Clear();

            var shuffled = ShuffleString(originalWord).ToCharArray();
            int x = 10, y = 10;
            const int btnSize = 40;
            const int spacing = 10;

            for (int i = 0; i < shuffled.Length; i++)
            {
                var btn = new Button
                {
                    Text = shuffled[i].ToString(),
                    Size = new System.Drawing.Size(btnSize, btnSize),
                    Location = new System.Drawing.Point(x, y),
                    Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold),
                    Tag = shuffled[i]
                };
                btn.Click += LetterButton_Click;
                pnlLetters.Controls.Add(btn);
                letterButtons.Add(btn);

                x += btnSize + spacing;
                if (x > pnlLetters.Width - btnSize)
                {
                    x = 10;
                    y += btnSize + spacing;
                }
            }

            btnCheck.Enabled = true;
            btnUndo.Enabled = true;
        }

        private string ShuffleString(string word)
        {
            var random = new Random();
            var chars = word.ToCharArray();
            for (int i = chars.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }
            return new string(chars);
        }

        private void LetterButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                currentAnswer += btn.Text;
                lblAnswer.Text = currentAnswer;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (currentAnswer.Length > 0)
            {
                currentAnswer = currentAnswer.Substring(0, currentAnswer.Length - 1);
                lblAnswer.Text = currentAnswer;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (currentAnswer == originalWord)
            {
                lblStatus.Text = "✅ Верно! Вы угадали слово!";
                lblStatus.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                lblStatus.Text = "❌ Неверно. Попробуйте ещё!";
                lblStatus.BackColor = System.Drawing.Color.LightPink;
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            txtInputWord.Clear();
            lblAnswer.Text = "";
            lblStatus.Text = "";
            lblStatus.BackColor = System.Drawing.Color.Transparent;
            currentAnswer = "";
            originalWord = "";

            foreach (var btn in letterButtons)
                pnlLetters.Controls.Remove(btn);
            letterButtons.Clear();

            btnCheck.Enabled = false;
            btnUndo.Enabled = false;
        }
    }
}
