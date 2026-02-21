namespace pr_5
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
            this.networkPanel = new System.Windows.Forms.Panel();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.speedValueLabel = new System.Windows.Forms.Label();
            this.controlGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.controlGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // networkPanel
            // 
            this.networkPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.networkPanel.Location = new System.Drawing.Point(12, 12);
            this.networkPanel.Name = "networkPanel";
            this.networkPanel.Size = new System.Drawing.Size(620, 420);
            this.networkPanel.TabIndex = 0;
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(12, 438);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(620, 150);
            this.logTextBox.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(15, 25);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 30);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(111, 25);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(90, 30);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(207, 25);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(90, 30);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(310, 32);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(69, 15);
            this.speedLabel.TabIndex = 5;
            this.speedLabel.Text = "Скорость:";
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Location = new System.Drawing.Point(385, 25);
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(104, 45);
            this.speedTrackBar.TabIndex = 6;
            this.speedTrackBar.Scroll += new System.EventHandler(this.speedTrackBar_Scroll);
            // 
            // speedValueLabel
            // 
            this.speedValueLabel.AutoSize = true;
            this.speedValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.speedValueLabel.Location = new System.Drawing.Point(495, 32);
            this.speedValueLabel.Name = "speedValueLabel";
            this.speedValueLabel.Size = new System.Drawing.Size(15, 16);
            this.speedValueLabel.TabIndex = 7;
            this.speedValueLabel.Text = "5";
            // 
            // controlGroupBox
            // 
            this.controlGroupBox.Controls.Add(this.startButton);
            this.controlGroupBox.Controls.Add(this.speedValueLabel);
            this.controlGroupBox.Controls.Add(this.stopButton);
            this.controlGroupBox.Controls.Add(this.speedTrackBar);
            this.controlGroupBox.Controls.Add(this.clearButton);
            this.controlGroupBox.Controls.Add(this.speedLabel);
            this.controlGroupBox.Location = new System.Drawing.Point(12, 594);
            this.controlGroupBox.Name = "controlGroupBox";
            this.controlGroupBox.Size = new System.Drawing.Size(620, 70);
            this.controlGroupBox.TabIndex = 8;
            this.controlGroupBox.TabStop = false;
            this.controlGroupBox.Text = "Управление";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 676);
            this.Controls.Add(this.controlGroupBox);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.networkPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Сетевой терминал — Имитация ЛВС";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.controlGroupBox.ResumeLayout(false);
            this.controlGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel networkPanel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Label speedValueLabel;
        private System.Windows.Forms.GroupBox controlGroupBox;
    }
}

