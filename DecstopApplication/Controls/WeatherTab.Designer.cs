namespace DesktopApplication
{
    partial class WeatherTab
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPartOfDay = new System.Windows.Forms.Label();
            this.labelTitleTemperature = new System.Windows.Forms.Label();
            this.labelTitlePressure = new System.Windows.Forms.Label();
            this.labelTitleHumidity = new System.Windows.Forms.Label();
            this.labelTitleWind = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelPressure = new System.Windows.Forms.Label();
            this.labelHumidity = new System.Windows.Forms.Label();
            this.labelWindSpeed = new System.Windows.Forms.Label();
            this.labelWind = new System.Windows.Forms.Label();
            this.labelCloudiness = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPartOfDay
            // 
            this.labelPartOfDay.AutoSize = true;
            this.labelPartOfDay.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPartOfDay.Location = new System.Drawing.Point(13, 66);
            this.labelPartOfDay.Name = "labelPartOfDay";
            this.labelPartOfDay.Size = new System.Drawing.Size(51, 25);
            this.labelPartOfDay.TabIndex = 0;
            this.labelPartOfDay.Text = "Утро";
            // 
            // labelTitleTemperature
            // 
            this.labelTitleTemperature.AutoSize = true;
            this.labelTitleTemperature.Location = new System.Drawing.Point(88, 21);
            this.labelTitleTemperature.Name = "labelTitleTemperature";
            this.labelTitleTemperature.Size = new System.Drawing.Size(79, 15);
            this.labelTitleTemperature.TabIndex = 1;
            this.labelTitleTemperature.Text = "Температура";
            // 
            // labelTitlePressure
            // 
            this.labelTitlePressure.AutoSize = true;
            this.labelTitlePressure.Location = new System.Drawing.Point(193, 21);
            this.labelTitlePressure.Name = "labelTitlePressure";
            this.labelTitlePressure.Size = new System.Drawing.Size(60, 15);
            this.labelTitlePressure.TabIndex = 1;
            this.labelTitlePressure.Text = "Давление";
            // 
            // labelTitleHumidity
            // 
            this.labelTitleHumidity.AutoSize = true;
            this.labelTitleHumidity.Location = new System.Drawing.Point(286, 21);
            this.labelTitleHumidity.Name = "labelTitleHumidity";
            this.labelTitleHumidity.Size = new System.Drawing.Size(67, 15);
            this.labelTitleHumidity.TabIndex = 1;
            this.labelTitleHumidity.Text = "Влажность";
            // 
            // labelTitleWind
            // 
            this.labelTitleWind.AutoSize = true;
            this.labelTitleWind.Location = new System.Drawing.Point(404, 21);
            this.labelTitleWind.Name = "labelTitleWind";
            this.labelTitleWind.Size = new System.Drawing.Size(38, 15);
            this.labelTitleWind.TabIndex = 1;
            this.labelTitleWind.Text = "Ветер";
            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTemperature.Location = new System.Drawing.Point(88, 52);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(94, 54);
            this.labelTemperature.TabIndex = 2;
            this.labelTemperature.Text = "+30";
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPressure.Location = new System.Drawing.Point(193, 52);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(73, 25);
            this.labelPressure.TabIndex = 3;
            this.labelPressure.Text = "775 мм";
            // 
            // labelHumidity
            // 
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHumidity.Location = new System.Drawing.Point(297, 52);
            this.labelHumidity.Name = "labelHumidity";
            this.labelHumidity.Size = new System.Drawing.Size(47, 25);
            this.labelHumidity.TabIndex = 3;
            this.labelHumidity.Text = "35%";
            // 
            // labelWindSpeed
            // 
            this.labelWindSpeed.AutoSize = true;
            this.labelWindSpeed.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWindSpeed.Location = new System.Drawing.Point(452, 82);
            this.labelWindSpeed.Name = "labelWindSpeed";
            this.labelWindSpeed.Size = new System.Drawing.Size(55, 25);
            this.labelWindSpeed.TabIndex = 3;
            this.labelWindSpeed.Text = "3 м/с";
            this.labelWindSpeed.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelWind
            // 
            this.labelWind.AutoSize = true;
            this.labelWind.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWind.Location = new System.Drawing.Point(365, 52);
            this.labelWind.Name = "labelWind";
            this.labelWind.Size = new System.Drawing.Size(142, 25);
            this.labelWind.TabIndex = 3;
            this.labelWind.Text = "юго-восточный";
            // 
            // labelCloudiness
            // 
            this.labelCloudiness.AutoSize = true;
            this.labelCloudiness.Location = new System.Drawing.Point(188, 88);
            this.labelCloudiness.Name = "labelCloudiness";
            this.labelCloudiness.Size = new System.Drawing.Size(112, 15);
            this.labelCloudiness.TabIndex = 4;
            this.labelCloudiness.Text = "Облачно с дождем";
            // 
            // WeatherTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCloudiness);
            this.Controls.Add(this.labelWind);
            this.Controls.Add(this.labelWindSpeed);
            this.Controls.Add(this.labelHumidity);
            this.Controls.Add(this.labelPressure);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.labelTitleWind);
            this.Controls.Add(this.labelTitleHumidity);
            this.Controls.Add(this.labelTitlePressure);
            this.Controls.Add(this.labelTitleTemperature);
            this.Controls.Add(this.labelPartOfDay);
            this.Name = "WeatherTab";
            this.Size = new System.Drawing.Size(525, 132);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPartOfDay;
        private System.Windows.Forms.Label labelTitleTemperature;
        private System.Windows.Forms.Label labelTitlePressure;
        private System.Windows.Forms.Label labelTitleHumidity;
        private System.Windows.Forms.Label labelTitleWind;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelPressure;
        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.Label labelWindSpeed;
        private System.Windows.Forms.Label labelWind;
        private System.Windows.Forms.Label labelCloudiness;
    }
}
