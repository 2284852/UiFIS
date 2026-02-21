namespace pr_3
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalItems = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTargetTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAvgWork = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxWork = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMinWork = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCoefficientValue = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblVarianceValue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblMeanTimeValue = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblUValue = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblFailedItemsValue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblProbFailureValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblProbReliableValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSigmaValue = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotalItems);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTargetTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAvgWork);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaxWork);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMinWork);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные данные";
            // 
            // txtTotalItems
            // 
            this.txtTotalItems.Location = new System.Drawing.Point(140, 185);
            this.txtTotalItems.Name = "txtTotalItems";
            this.txtTotalItems.Size = new System.Drawing.Size(100, 22);
            this.txtTotalItems.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Всего изделий, шт:";
            // 
            // txtTargetTime
            // 
            this.txtTargetTime.Location = new System.Drawing.Point(140, 150);
            this.txtTargetTime.Name = "txtTargetTime";
            this.txtTargetTime.Size = new System.Drawing.Size(100, 22);
            this.txtTargetTime.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Наработка, ч:";
            // 
            // txtAvgWork
            // 
            this.txtAvgWork.Location = new System.Drawing.Point(140, 115);
            this.txtAvgWork.Name = "txtAvgWork";
            this.txtAvgWork.Size = new System.Drawing.Size(100, 22);
            this.txtAvgWork.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Средняя, ч (μ):";
            // 
            // txtMaxWork
            // 
            this.txtMaxWork.Location = new System.Drawing.Point(140, 80);
            this.txtMaxWork.Name = "txtMaxWork";
            this.txtMaxWork.Size = new System.Drawing.Size(100, 22);
            this.txtMaxWork.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Максимальная, ч:";
            // 
            // txtMinWork
            // 
            this.txtMinWork.Location = new System.Drawing.Point(140, 45);
            this.txtMinWork.Name = "txtMinWork";
            this.txtMinWork.Size = new System.Drawing.Size(100, 22);
            this.txtMinWork.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Минимальная, ч:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(12, 238);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(140, 35);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(172, 238);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 35);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCoefficientValue);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblVarianceValue);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblMeanTimeValue);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblUValue);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblFailedItemsValue);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblProbFailureValue);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblProbReliableValue);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblSigmaValue);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(325, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 260);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результаты расчета";
            // 
            // lblCoefficientValue
            // 
            this.lblCoefficientValue.AutoSize = true;
            this.lblCoefficientValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCoefficientValue.Location = new System.Drawing.Point(180, 225);
            this.lblCoefficientValue.Name = "lblCoefficientValue";
            this.lblCoefficientValue.Size = new System.Drawing.Size(17, 18);
            this.lblCoefficientValue.TabIndex = 15;
            this.lblCoefficientValue.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 17);
            this.label12.TabIndex = 14;
            this.label12.Text = "Коэффициент вариации:";
            // 
            // lblVarianceValue
            // 
            this.lblVarianceValue.AutoSize = true;
            this.lblVarianceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVarianceValue.Location = new System.Drawing.Point(180, 200);
            this.lblVarianceValue.Name = "lblVarianceValue";
            this.lblVarianceValue.Size = new System.Drawing.Size(17, 18);
            this.lblVarianceValue.TabIndex = 13;
            this.lblVarianceValue.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Дисперсия:";
            // 
            // lblMeanTimeValue
            // 
            this.lblMeanTimeValue.AutoSize = true;
            this.lblMeanTimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMeanTimeValue.Location = new System.Drawing.Point(180, 175);
            this.lblMeanTimeValue.Name = "lblMeanTimeValue";
            this.lblMeanTimeValue.Size = new System.Drawing.Size(17, 18);
            this.lblMeanTimeValue.TabIndex = 11;
            this.lblMeanTimeValue.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Средняя наработка:";
            // 
            // lblUValue
            // 
            this.lblUValue.AutoSize = true;
            this.lblUValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUValue.Location = new System.Drawing.Point(180, 150);
            this.lblUValue.Name = "lblUValue";
            this.lblUValue.Size = new System.Drawing.Size(17, 18);
            this.lblUValue.TabIndex = 9;
            this.lblUValue.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "Квантиль U:";
            // 
            // lblFailedItemsValue
            // 
            this.lblFailedItemsValue.AutoSize = true;
            this.lblFailedItemsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFailedItemsValue.ForeColor = System.Drawing.Color.Red;
            this.lblFailedItemsValue.Location = new System.Drawing.Point(180, 125);
            this.lblFailedItemsValue.Name = "lblFailedItemsValue";
            this.lblFailedItemsValue.Size = new System.Drawing.Size(17, 18);
            this.lblFailedItemsValue.TabIndex = 7;
            this.lblFailedItemsValue.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Отказавшие изделия:";
            // 
            // lblProbFailureValue
            // 
            this.lblProbFailureValue.AutoSize = true;
            this.lblProbFailureValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProbFailureValue.ForeColor = System.Drawing.Color.Red;
            this.lblProbFailureValue.Location = new System.Drawing.Point(180, 100);
            this.lblProbFailureValue.Name = "lblProbFailureValue";
            this.lblProbFailureValue.Size = new System.Drawing.Size(17, 18);
            this.lblProbFailureValue.TabIndex = 5;
            this.lblProbFailureValue.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Вероятность отказа:";
            // 
            // lblProbReliableValue
            // 
            this.lblProbReliableValue.AutoSize = true;
            this.lblProbReliableValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblProbReliableValue.ForeColor = System.Drawing.Color.Green;
            this.lblProbReliableValue.Location = new System.Drawing.Point(180, 75);
            this.lblProbReliableValue.Name = "lblProbReliableValue";
            this.lblProbReliableValue.Size = new System.Drawing.Size(17, 18);
            this.lblProbReliableValue.TabIndex = 3;
            this.lblProbReliableValue.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Вероятность безотказной:";
            // 
            // lblSigmaValue
            // 
            this.lblSigmaValue.AutoSize = true;
            this.lblSigmaValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSigmaValue.Location = new System.Drawing.Point(180, 50);
            this.lblSigmaValue.Name = "lblSigmaValue";
            this.lblSigmaValue.Size = new System.Drawing.Size(17, 18);
            this.lblSigmaValue.TabIndex = 1;
            this.lblSigmaValue.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Стандартное отклонение:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 285);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Расчет показателей долговечности (Вариант 8)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMinWork;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaxWork;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAvgWork;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTargetTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSigmaValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblProbReliableValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblProbFailureValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblFailedItemsValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblUValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMeanTimeValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblVarianceValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCoefficientValue;
        private System.Windows.Forms.Label label12;
    }
}

