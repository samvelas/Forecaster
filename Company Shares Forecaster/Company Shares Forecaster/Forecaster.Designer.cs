namespace Company_Shares_Forecaster
{
    partial class Forecaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Forecaster));
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.calculate = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.predict = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.регрессияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вводДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предсказываниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Модели";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(0, 46);
            this.Chart.Name = "Chart";
            this.Chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.Chart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Gold};
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Модели";
            series1.LegendText = "Кубическая модель";
            series1.Name = "model_1";
            series2.ChartArea = "ChartArea1";
            series2.IsVisibleInLegend = false;
            series2.Legend = "Модели";
            series2.Name = "Series1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Модели";
            series3.LegendText = "Квадратическая модель";
            series3.Name = "model_2";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Модели";
            series4.LegendText = "Многочлен 4-ой степени";
            series4.Name = "model_3";
            this.Chart.Series.Add(series1);
            this.Chart.Series.Add(series2);
            this.Chart.Series.Add(series3);
            this.Chart.Series.Add(series4);
            this.Chart.Size = new System.Drawing.Size(300, 300);
            this.Chart.TabIndex = 0;
            this.Chart.Text = "Chart";
            title1.Name = "Title1";
            this.Chart.Titles.Add(title1);
            
            // 
            // calculate
            // 
            this.calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculate.Location = new System.Drawing.Point(576, 366);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(186, 54);
            this.calculate.TabIndex = 1;
            this.calculate.Text = "Рассчитать";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // openFile
            // 
            this.openFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFile.Location = new System.Drawing.Point(384, 366);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(186, 54);
            this.openFile.TabIndex = 2;
            this.openFile.Text = "Входной файл";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 366);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 34);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // predict
            // 
            this.predict.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predict.Location = new System.Drawing.Point(127, 366);
            this.predict.Name = "predict";
            this.predict.Size = new System.Drawing.Size(195, 54);
            this.predict.TabIndex = 4;
            this.predict.Text = "Предсказывать";
            this.predict.UseVisualStyleBackColor = true;
            this.predict.Click += new System.EventHandler(this.predict_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleName = "mainMenu";
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(10, 10);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 33);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "mainMenu";
           
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.регрессияToolStripMenuItem,
            this.вводДанныхToolStripMenuItem,
            this.предсказываниеToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(96, 29);
            this.toolStripMenuItem1.Text = "Помощь";
            // 
            // регрессияToolStripMenuItem
            // 
            this.регрессияToolStripMenuItem.Name = "регрессияToolStripMenuItem";
            this.регрессияToolStripMenuItem.Size = new System.Drawing.Size(235, 30);
            this.регрессияToolStripMenuItem.Text = "Регрессия";
            this.регрессияToolStripMenuItem.Click += new System.EventHandler(this.регрессияToolStripMenuItem_Click);
            // 
            // вводДанныхToolStripMenuItem
            // 
            this.вводДанныхToolStripMenuItem.Name = "вводДанныхToolStripMenuItem";
            this.вводДанныхToolStripMenuItem.Size = new System.Drawing.Size(235, 30);
            this.вводДанныхToolStripMenuItem.Text = "Ввод данных";
            this.вводДанныхToolStripMenuItem.Click += new System.EventHandler(this.вводДанныхToolStripMenuItem_Click);
            // 
            // предсказываниеToolStripMenuItem
            // 
            this.предсказываниеToolStripMenuItem.Name = "предсказываниеToolStripMenuItem";
            this.предсказываниеToolStripMenuItem.Size = new System.Drawing.Size(235, 30);
            this.предсказываниеToolStripMenuItem.Text = "Предсказывание";
            this.предсказываниеToolStripMenuItem.Click += new System.EventHandler(this.предсказываниеToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(137, 29);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // Forecaster
            // 
            this.AccessibleName = "window";
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 433);
            this.Controls.Add(this.predict);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.Chart);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Forecaster";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Shares Forecaster";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Forecaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button predict;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem регрессияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вводДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem предсказываниеToolStripMenuItem;
    }
}

