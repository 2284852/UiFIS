using System.Windows.Forms;

namespace pr_2
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblInstr1 = new System.Windows.Forms.Label();
            this.txtTimes1 = new System.Windows.Forms.TextBox();
            this.btnCalc1 = new System.Windows.Forms.Button();
            this.lblResult1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblInstr2 = new System.Windows.Forms.Label();
            this.txtSystems2 = new System.Windows.Forms.TextBox();
            this.btnCalc2 = new System.Windows.Forms.Button();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblSys1 = new System.Windows.Forms.Label();
            this.txtT0_1 = new System.Windows.Forms.TextBox();
            this.txtTv_1 = new System.Windows.Forms.TextBox();
            this.lblSys2 = new System.Windows.Forms.Label();
            this.txtT0_2 = new System.Windows.Forms.TextBox();
            this.txtTv_2 = new System.Windows.Forms.TextBox();
            this.btnCalc3 = new System.Windows.Forms.Button();
            this.lblResult3 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(550, 350);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblInstr1);
            this.tabPage1.Controls.Add(this.txtTimes1);
            this.tabPage1.Controls.Add(this.btnCalc1);
            this.tabPage1.Controls.Add(this.lblResult1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(542, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Задание 1";
            // 
            // lblInstr1
            // 
            this.lblInstr1.AutoSize = true;
            this.lblInstr1.Location = new System.Drawing.Point(10, 10);
            this.lblInstr1.Name = "lblInstr1";
            this.lblInstr1.Size = new System.Drawing.Size(415, 13);
            this.lblInstr1.TabIndex = 0;
            this.lblInstr1.Text = "Введите времена до отказов (часы), разделённые пробелом, запятой или Enter:";
            // 
            // txtTimes1
            // 
            this.txtTimes1.Location = new System.Drawing.Point(10, 30);
            this.txtTimes1.Multiline = true;
            this.txtTimes1.Name = "txtTimes1";
            this.txtTimes1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTimes1.Size = new System.Drawing.Size(300, 100);
            this.txtTimes1.TabIndex = 1;
            // 
            // btnCalc1
            // 
            this.btnCalc1.Location = new System.Drawing.Point(10, 140);
            this.btnCalc1.Name = "btnCalc1";
            this.btnCalc1.Size = new System.Drawing.Size(100, 30);
            this.btnCalc1.TabIndex = 2;
            this.btnCalc1.Text = "Рассчитать";
            this.btnCalc1.UseVisualStyleBackColor = true;
            this.btnCalc1.Click += new System.EventHandler(this.btnCalc1_Click);
            // 
            // lblResult1
            // 
            this.lblResult1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult1.Location = new System.Drawing.Point(10, 180);
            this.lblResult1.Name = "lblResult1";
            this.lblResult1.Size = new System.Drawing.Size(500, 40);
            this.lblResult1.TabIndex = 3;
            this.lblResult1.Text = "Результат здесь";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblInstr2);
            this.tabPage2.Controls.Add(this.txtSystems2);
            this.tabPage2.Controls.Add(this.btnCalc2);
            this.tabPage2.Controls.Add(this.lblResult2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(542, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Задание 2";
            // 
            // lblInstr2
            // 
            this.lblInstr2.AutoSize = true;
            this.lblInstr2.Location = new System.Drawing.Point(10, 10);
            this.lblInstr2.Name = "lblInstr2";
            this.lblInstr2.Size = new System.Drawing.Size(232, 78);
            this.lblInstr2.TabIndex = 0;
            this.lblInstr2.Text = "Введите данные по системам:\r\nКаждая строка: \"наработка, число отказов\"\r\nПример:\r\n" +
    "358,4\r\n385,3\r\n400,2";
            // 
            // txtSystems2
            // 
            this.txtSystems2.Location = new System.Drawing.Point(262, 10);
            this.txtSystems2.Multiline = true;
            this.txtSystems2.Name = "txtSystems2";
            this.txtSystems2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSystems2.Size = new System.Drawing.Size(244, 151);
            this.txtSystems2.TabIndex = 1;
            // 
            // btnCalc2
            // 
            this.btnCalc2.Location = new System.Drawing.Point(6, 162);
            this.btnCalc2.Name = "btnCalc2";
            this.btnCalc2.Size = new System.Drawing.Size(100, 30);
            this.btnCalc2.TabIndex = 2;
            this.btnCalc2.Text = "Рассчитать";
            this.btnCalc2.UseVisualStyleBackColor = true;
            this.btnCalc2.Click += new System.EventHandler(this.btnCalc2_Click);
            // 
            // lblResult2
            // 
            this.lblResult2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult2.Location = new System.Drawing.Point(6, 202);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(500, 40);
            this.lblResult2.TabIndex = 3;
            this.lblResult2.Text = "Результат здесь";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblSys1);
            this.tabPage3.Controls.Add(this.txtT0_1);
            this.tabPage3.Controls.Add(this.txtTv_1);
            this.tabPage3.Controls.Add(this.lblSys2);
            this.tabPage3.Controls.Add(this.txtT0_2);
            this.tabPage3.Controls.Add(this.txtTv_2);
            this.tabPage3.Controls.Add(this.btnCalc3);
            this.tabPage3.Controls.Add(this.lblResult3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(542, 324);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Задание 3";
            // 
            // lblSys1
            // 
            this.lblSys1.AutoSize = true;
            this.lblSys1.Location = new System.Drawing.Point(10, 10);
            this.lblSys1.Name = "lblSys1";
            this.lblSys1.Size = new System.Drawing.Size(63, 13);
            this.lblSys1.TabIndex = 0;
            this.lblSys1.Text = "Система 1:";
            // 
            // txtT0_1
            // 
            this.txtT0_1.Location = new System.Drawing.Point(100, 10);
            this.txtT0_1.Name = "txtT0_1";
            this.txtT0_1.Size = new System.Drawing.Size(100, 20);
            this.txtT0_1.TabIndex = 1;
            this.txtT0_1.Text = "24";
            // 
            // txtTv_1
            // 
            this.txtTv_1.Location = new System.Drawing.Point(220, 10);
            this.txtTv_1.Name = "txtTv_1";
            this.txtTv_1.Size = new System.Drawing.Size(100, 20);
            this.txtTv_1.TabIndex = 2;
            this.txtTv_1.Text = "16";
            // 
            // lblSys2
            // 
            this.lblSys2.AutoSize = true;
            this.lblSys2.Location = new System.Drawing.Point(10, 40);
            this.lblSys2.Name = "lblSys2";
            this.lblSys2.Size = new System.Drawing.Size(63, 13);
            this.lblSys2.TabIndex = 3;
            this.lblSys2.Text = "Система 2:";
            // 
            // txtT0_2
            // 
            this.txtT0_2.Location = new System.Drawing.Point(100, 40);
            this.txtT0_2.Name = "txtT0_2";
            this.txtT0_2.Size = new System.Drawing.Size(100, 20);
            this.txtT0_2.TabIndex = 4;
            this.txtT0_2.Text = "400";
            // 
            // txtTv_2
            // 
            this.txtTv_2.Location = new System.Drawing.Point(220, 40);
            this.txtTv_2.Name = "txtTv_2";
            this.txtTv_2.Size = new System.Drawing.Size(100, 20);
            this.txtTv_2.TabIndex = 5;
            this.txtTv_2.Text = "32";
            // 
            // btnCalc3
            // 
            this.btnCalc3.Location = new System.Drawing.Point(10, 70);
            this.btnCalc3.Name = "btnCalc3";
            this.btnCalc3.Size = new System.Drawing.Size(100, 30);
            this.btnCalc3.TabIndex = 6;
            this.btnCalc3.Text = "Сравнить";
            this.btnCalc3.UseVisualStyleBackColor = true;
            this.btnCalc3.Click += new System.EventHandler(this.btnCalc3_Click);
            // 
            // lblResult3
            // 
            this.lblResult3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult3.Location = new System.Drawing.Point(10, 110);
            this.lblResult3.Name = "lblResult3";
            this.lblResult3.Size = new System.Drawing.Size(500, 100);
            this.lblResult3.TabIndex = 7;
            this.lblResult3.Text = "Результат здесь";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 350);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Показатели безотказности системы";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        private TabControl tabControl;
        private TabPage tabPage1, tabPage2, tabPage3;
        private Label lblInstr1, lblInstr2;
        private TextBox txtTimes1, txtSystems2;
        private Button btnCalc1, btnCalc2, btnCalc3;
        private Label lblResult1, lblResult2, lblResult3;
        private Label lblSys1, lblSys2;
        private TextBox txtT0_1, txtTv_1, txtT0_2, txtTv_2;
    }
}

