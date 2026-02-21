namespace pr_4
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

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.lblLambda = new System.Windows.Forms.Label();
            this.txtLambda = new System.Windows.Forms.TextBox();
            this.lblMu = new System.Windows.Forms.Label();
            this.txtMu = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEquations = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblKp = new System.Windows.Forms.Label();
            this.lblKg = new System.Windows.Forms.Label();
            this.lblP2Time = new System.Windows.Forms.Label();
            this.lblP1Time = new System.Windows.Forms.Label();
            this.lblP2Stationary = new System.Windows.Forms.Label();
            this.lblP1Stationary = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLambda
            // 
            this.lblLambda.AutoSize = true;
            this.lblLambda.Location = new System.Drawing.Point(12, 15);
            this.lblLambda.Name = "lblLambda";
            this.lblLambda.Size = new System.Drawing.Size(166, 13);
            this.lblLambda.TabIndex = 0;
            this.lblLambda.Text = "λ (интенсивность отказов, 1/ч):";
            // 
            // txtLambda
            // 
            this.txtLambda.Location = new System.Drawing.Point(184, 12);
            this.txtLambda.Name = "txtLambda";
            this.txtLambda.Size = new System.Drawing.Size(39, 20);
            this.txtLambda.TabIndex = 1;
            // 
            // lblMu
            // 
            this.lblMu.AutoSize = true;
            this.lblMu.Location = new System.Drawing.Point(228, 15);
            this.lblMu.Name = "lblMu";
            this.lblMu.Size = new System.Drawing.Size(209, 13);
            this.lblMu.TabIndex = 2;
            this.lblMu.Text = "μ (интенсивность восстановления, 1/ч):";
            // 
            // txtMu
            // 
            this.txtMu.Location = new System.Drawing.Point(435, 12);
            this.txtMu.Name = "txtMu";
            this.txtMu.Size = new System.Drawing.Size(45, 20);
            this.txtMu.TabIndex = 3;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(12, 88);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(459, 28);
            this.btnCalculate.TabIndex = 6;
            this.btnCalculate.Text = "Рассчитать систему уравнений Колмогорова и вероятности состояний";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEquations);
            this.groupBox1.Location = new System.Drawing.Point(12, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Система дифференциальных уравнений Колмогорова";
            // 
            // txtEquations
            // 
            this.txtEquations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEquations.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtEquations.Location = new System.Drawing.Point(3, 16);
            this.txtEquations.Multiline = true;
            this.txtEquations.Name = "txtEquations";
            this.txtEquations.ReadOnly = true;
            this.txtEquations.Size = new System.Drawing.Size(453, 81);
            this.txtEquations.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblKp);
            this.groupBox2.Controls.Add(this.lblKg);
            this.groupBox2.Controls.Add(this.lblP2Time);
            this.groupBox2.Controls.Add(this.lblP1Time);
            this.groupBox2.Controls.Add(this.lblP2Stationary);
            this.groupBox2.Controls.Add(this.lblP1Stationary);
            this.groupBox2.Location = new System.Drawing.Point(12, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 137);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результаты расчёта";
            // 
            // lblKp
            // 
            this.lblKp.AutoSize = true;
            this.lblKp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblKp.ForeColor = System.Drawing.Color.Red;
            this.lblKp.Location = new System.Drawing.Point(6, 111);
            this.lblKp.Name = "lblKp";
            this.lblKp.Size = new System.Drawing.Size(162, 15);
            this.lblKp.TabIndex = 5;
            this.lblKp.Text = "Коэффициент простоя";
            // 
            // lblKg
            // 
            this.lblKg.AutoSize = true;
            this.lblKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblKg.ForeColor = System.Drawing.Color.Green;
            this.lblKg.Location = new System.Drawing.Point(6, 91);
            this.lblKg.Name = "lblKg";
            this.lblKg.Size = new System.Drawing.Size(184, 15);
            this.lblKg.TabIndex = 4;
            this.lblKg.Text = "Коэффициент готовности";
            // 
            // lblP2Time
            // 
            this.lblP2Time.AutoSize = true;
            this.lblP2Time.Location = new System.Drawing.Point(6, 71);
            this.lblP2Time.Name = "lblP2Time";
            this.lblP2Time.Size = new System.Drawing.Size(128, 13);
            this.lblP2Time.TabIndex = 3;
            this.lblP2Time.Text = "P₂(t) в момент времени:";
            // 
            // lblP1Time
            // 
            this.lblP1Time.AutoSize = true;
            this.lblP1Time.Location = new System.Drawing.Point(6, 51);
            this.lblP1Time.Name = "lblP1Time";
            this.lblP1Time.Size = new System.Drawing.Size(128, 13);
            this.lblP1Time.TabIndex = 2;
            this.lblP1Time.Text = "P₁(t) в момент времени:";
            // 
            // lblP2Stationary
            // 
            this.lblP2Stationary.AutoSize = true;
            this.lblP2Stationary.Location = new System.Drawing.Point(6, 36);
            this.lblP2Stationary.Name = "lblP2Stationary";
            this.lblP2Stationary.Size = new System.Drawing.Size(134, 13);
            this.lblP2Stationary.TabIndex = 1;
            this.lblP2Stationary.Text = "Стационарная P₂ (отказ):";
            // 
            // lblP1Stationary
            // 
            this.lblP1Stationary.AutoSize = true;
            this.lblP1Stationary.Location = new System.Drawing.Point(6, 21);
            this.lblP1Stationary.Name = "lblP1Stationary";
            this.lblP1Stationary.Size = new System.Drawing.Size(205, 13);
            this.lblP1Stationary.TabIndex = 0;
            this.lblP1Stationary.Text = "Стационарная P₁ (работоспособность):";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(12, 45);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(148, 13);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Время наблюдения t (часы):";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(166, 42);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 5;
            // 
            // chartPanel
            // 
            this.chartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chartPanel.Location = new System.Drawing.Point(12, 354);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(459, 216);
            this.chartPanel.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 582);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtMu);
            this.Controls.Add(this.lblMu);
            this.Controls.Add(this.txtLambda);
            this.Controls.Add(this.lblLambda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Практическая работа №4 — Надёжность системы (Вариант 8)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLambda;
        private System.Windows.Forms.TextBox txtLambda;
        private System.Windows.Forms.Label lblMu;
        private System.Windows.Forms.TextBox txtMu;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEquations;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblP1Stationary;
        private System.Windows.Forms.Label lblP2Stationary;
        private System.Windows.Forms.Label lblP1Time;
        private System.Windows.Forms.Label lblP2Time;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblKg;
        private System.Windows.Forms.Label lblKp;
        private System.Windows.Forms.Panel chartPanel;
    }
}

