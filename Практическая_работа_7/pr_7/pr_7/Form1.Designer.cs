namespace pr_7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblN = new System.Windows.Forms.Label();
            this.lblNobn = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtNobn = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblFormula = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Коэффициент обнаружения ошибок";
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Font = new System.Drawing.Font("Consolas", 11F);
            this.lblFormula.Location = new System.Drawing.Point(20, 70);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(220, 22);
            this.lblFormula.TabIndex = 1;
            this.lblFormula.Text = "K_обн = N_обн / N";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNobn);
            this.panel1.Controls.Add(this.lblN);
            this.panel1.Controls.Add(this.txtNobn);
            this.panel1.Controls.Add(this.txtN);
            this.panel1.Location = new System.Drawing.Point(20, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 140);
            this.panel1.TabIndex = 2;
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(20, 30);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(280, 20);
            this.lblN.TabIndex = 0;
            this.lblN.Text = "Общее число возникших ошибок (N):";
            // 
            // lblNobn
            // 
            this.lblNobn.AutoSize = true;
            this.lblNobn.Location = new System.Drawing.Point(20, 80);
            this.lblNobn.Name = "lblNobn";
            this.lblNobn.Size = new System.Drawing.Size(310, 20);
            this.lblNobn.TabIndex = 1;
            this.lblNobn.Text = "Обнаружено контролем (N_обн):";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(320, 27);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(100, 27);
            this.txtN.TabIndex = 2;
            this.txtN.Text = "50";
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNobn
            // 
            this.txtNobn.Location = new System.Drawing.Point(320, 77);
            this.txtNobn.Name = "txtNobn";
            this.txtNobn.Size = new System.Drawing.Size(100, 27);
            this.txtNobn.TabIndex = 3;
            this.txtNobn.Text = "40";
            this.txtNobn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnCalculate.FlatAppearance.BorderSize = 0;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(20, 270);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(150, 45);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(190, 270);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 45);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.FromArgb(230, 250, 230);
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(0, 100, 0);
            this.lblResult.Location = new System.Drawing.Point(20, 340);
            this.lblResult.Name = "lblResult";
            this.lblResult.Padding = new System.Windows.Forms.Padding(15);
            this.lblResult.Size = new System.Drawing.Size(450, 80);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "Результат появится здесь...";
            this.lblResult.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFormula);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Практическая работа №7 — Вариант 8";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNobn;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.TextBox txtNobn;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResult;
    }
}

