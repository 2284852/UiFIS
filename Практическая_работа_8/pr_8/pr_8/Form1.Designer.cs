namespace pr_8
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
            this.grpFrom = new System.Windows.Forms.GroupBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.grpTo = new System.Windows.Forms.GroupBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.grpTransport = new System.Windows.Forms.GroupBox();
            this.cmbTransport = new System.Windows.Forms.ComboBox();
            this.lblRate = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpResult = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpFrom.SuspendLayout();
            this.grpTo.SuspendLayout();
            this.grpTransport.SuspendLayout();
            this.grpResult.SuspendLayout();
            this.grpHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Калькулятор доставки";
            // 
            // grpFrom
            // 
            this.grpFrom.Controls.Add(this.txtFrom);
            this.grpFrom.Location = new System.Drawing.Point(20, 70);
            this.grpFrom.Name = "grpFrom";
            this.grpFrom.Size = new System.Drawing.Size(450, 70);
            this.grpFrom.TabIndex = 1;
            this.grpFrom.TabStop = false;
            this.grpFrom.Text = "Пункт отправления (адрес или координаты)";
            // 
            // txtFrom
            // 
            this.txtFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFrom.Location = new System.Drawing.Point(3, 23);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Text = "Например: Москва, Красная площадь или 55.7558, 37.6173";
            this.txtFrom.Size = new System.Drawing.Size(444, 30);
            this.txtFrom.TabIndex = 0;
            // 
            // grpTo
            // 
            this.grpTo.Controls.Add(this.txtTo);
            this.grpTo.Location = new System.Drawing.Point(20, 150);
            this.grpTo.Name = "grpTo";
            this.grpTo.Size = new System.Drawing.Size(450, 70);
            this.grpTo.TabIndex = 2;
            this.grpTo.TabStop = false;
            this.grpTo.Text = "Пункт назначения (адрес или координаты)";
            // 
            // txtTo
            // 
            this.txtTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTo.Location = new System.Drawing.Point(3, 23);
            this.txtTo.Name = "txtTo";
            this.txtTo.Text = "Например: Санкт-Петербург, Невский проспект или 59.9343, 30.3351";
            this.txtTo.Size = new System.Drawing.Size(444, 30);
            this.txtTo.TabIndex = 1;
            // 
            // grpTransport
            // 
            this.grpTransport.Controls.Add(this.lblRate);
            this.grpTransport.Controls.Add(this.cmbTransport);
            this.grpTransport.Location = new System.Drawing.Point(20, 230);
            this.grpTransport.Name = "grpTransport";
            this.grpTransport.Size = new System.Drawing.Size(450, 70);
            this.grpTransport.TabIndex = 3;
            this.grpTransport.TabStop = false;
            this.grpTransport.Text = "Тип транспорта";
            // 
            // cmbTransport
            // 
            this.cmbTransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTransport.FormattingEnabled = true;
            this.cmbTransport.Items.AddRange(new object[] {
            "Автомобиль (40 руб./км)",
            "Грузовик (60 руб./км)",
            "Мотоцикл (25 руб./км)"});
            this.cmbTransport.Location = new System.Drawing.Point(6, 25);
            this.cmbTransport.Name = "cmbTransport";
            this.cmbTransport.Size = new System.Drawing.Size(300, 31);
            this.cmbTransport.TabIndex = 0;
            this.cmbTransport.SelectedIndexChanged += new System.EventHandler(this.cmbTransport_SelectedIndexChanged);
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.lblRate.Location = new System.Drawing.Point(320, 28);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(90, 23);
            this.lblRate.TabIndex = 1;
            this.lblRate.Text = "40 руб./км";
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnCalculate.FlatAppearance.BorderSize = 0;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(20, 320);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(220, 45);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "🚚 Рассчитать доставку";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(250, 320);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(220, 45);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "🗑 Очистить";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpResult
            // 
            this.grpResult.Controls.Add(this.lblResult);
            this.grpResult.Location = new System.Drawing.Point(490, 70);
            this.grpResult.Name = "grpResult";
            this.grpResult.Size = new System.Drawing.Size(350, 295);
            this.grpResult.TabIndex = 6;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "Результат расчета";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.FromArgb(240, 250, 240);
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(0, 100, 0);
            this.lblResult.Location = new System.Drawing.Point(3, 23);
            this.lblResult.Name = "lblResult";
            this.lblResult.Padding = new System.Windows.Forms.Padding(10);
            this.lblResult.Size = new System.Drawing.Size(344, 269);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Результат появится здесь...";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // grpHistory
            // 
            this.grpHistory.Controls.Add(this.btnClearHistory);
            this.grpHistory.Controls.Add(this.lstHistory);
            this.grpHistory.Location = new System.Drawing.Point(20, 380);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(820, 200);
            this.grpHistory.TabIndex = 7;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "История расчетов (кликните для загрузки)";
            // 
            // lstHistory
            // 
            this.lstHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 20;
            this.lstHistory.Location = new System.Drawing.Point(3, 23);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(814, 144);
            this.lstHistory.TabIndex = 0;
            this.lstHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHistory_MouseDoubleClick);
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.BackColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnClearHistory.FlatAppearance.BorderSize = 0;
            this.btnClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearHistory.ForeColor = System.Drawing.Color.Black;
            this.btnClearHistory.Location = new System.Drawing.Point(700, 170);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(117, 27);
            this.btnClearHistory.TabIndex = 1;
            this.btnClearHistory.Text = "Очистить историю";
            this.btnClearHistory.UseVisualStyleBackColor = false;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(20, 595);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 20);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Готов";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 630);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.grpResult);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.grpTransport);
            this.Controls.Add(this.grpTo);
            this.Controls.Add(this.grpFrom);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор доставки - Практическая работа №8";
            this.grpFrom.ResumeLayout(false);
            this.grpFrom.PerformLayout();
            this.grpTo.ResumeLayout(false);
            this.grpTo.PerformLayout();
            this.grpTransport.ResumeLayout(false);
            this.grpTransport.PerformLayout();
            this.grpResult.ResumeLayout(false);
            this.grpResult.PerformLayout();
            this.grpHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpFrom;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.GroupBox grpTo;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.GroupBox grpTransport;
        private System.Windows.Forms.ComboBox cmbTransport;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClearHistory;
    }
}

