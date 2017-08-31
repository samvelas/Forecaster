using System;
using CustomLib;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Company_Shares_Forecaster
{
    public partial class Forecaster : Form
    {
        static bool opened = false;
        double[] coeffs1, coeffs2, coeffs3;
        int dateFormat;
        double[] dates, values;

        public Forecaster()
        {
            InitializeComponent();
        }
        

        private void Forecaster_Load(object sender, EventArgs e)
        {
            //Отключить функцию Restore Down
            MaximizeBox = false;

            //Задают размеры графика
            Chart.Width = Width;
            Chart.Height = Height * 2 / 3;
            Chart.Top = menuStrip1.Height + 10;

            //Отрывает файл для ввода данных
            //Methods.openFile();

            calculate.Left = Width - calculate.Width - 50;
            calculate.Top = Height - calculate.Height - 60;

            openFile.Left = calculate.Left - 30 - calculate.Width;
            openFile.Top = calculate.Top;

            comboBox1.Left = 50;
            comboBox1.Top = calculate.Top;
            comboBox1.Enabled = false;
            comboBox1.Height = predict.Height;

            predict.Left = 80 + comboBox1.Width;
            predict.Top = calculate.Top;
            predict.Enabled = false;



            //Chart.ChartAreas[0].AxisX.LabelStyle.Angle = 45; // this works        
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            predict.Enabled = true;
            comboBox1.Enabled = true;



            //Date[] dates;
            //Сортированные входные данные

            try
            {
                Methods.sortDates(out dates, out values, out dateFormat);


                Chart.Series["Series1"].Points.Clear();
                Chart.Series["model_1"].Points.Clear();
                Chart.Series["model_2"].Points.Clear();
                Chart.Series["model_3"].Points.Clear();
                //Series mySeries = new Series();
                ChartArea chartArea;
                if (!opened)
                {
                    chartArea = new ChartArea();
                    chartArea.Position.Height = 100;
                    opened = true;
                    
                    
                    Chart.ChartAreas.Add(chartArea);
                    Chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false; 
                    Chart.ChartAreas[0].AxisX.Title = "Дата";
                    Chart.ChartAreas[0].AxisY.Title = "Стоимость";
                }

                //Chart.Legends.Add(new Legend());
                //Chart.Legends[0].Enabled = true;

                //Убирает решетку графика
                Chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightGray;
                Chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;
                
                Chart.Series["Series1"].ChartType = SeriesChartType.Point;

                LSM model1 = new LSM(dates, values);
                LSM model2 = new LSM(dates, values);
                LSM model3 = new LSM(dates, values);

                model1.Polynomial(3);
                model2.Polynomial(2);
                model3.Polynomial(4);

                coeffs1 = model1.Theta;
                coeffs2 = model2.Theta;
                coeffs3 = model3.Theta;

                for (double i = 0.0; i <= dates[dates.Length - 1]; i += 0.05)
                {
                    Chart.Series["model_1"].Points.AddXY(i, calculateFunctionInPoint(i, coeffs1));
                    Chart.Series["model_2"].Points.AddXY(i, calculateFunctionInPoint(i, coeffs2));
                    Chart.Series["model_3"].Points.AddXY(i, calculateFunctionInPoint(i, coeffs3));
                }

                
                for (int i = 0; i < dates.Length; i++)
                {
                    Chart.Series["Series1"].Points.AddXY(dates[i], values[i]);
                }

                Chart.Series["Series1"].MarkerStyle = MarkerStyle.Circle;
                Chart.Series["Series1"].MarkerSize = 7;

                Chart.Series["model_1"].ChartType = SeriesChartType.FastLine;
                Chart.Series["model_1"].BorderWidth = 2;

                Chart.Series["model_2"].ChartType = SeriesChartType.FastLine;
                Chart.Series["model_2"].BorderWidth = 2;

                Chart.Series["model_3"].ChartType = SeriesChartType.FastLine;
                Chart.Series["model_3"].BorderWidth = 2;

                setComboBoxValues(dateFormat);

                

                string message = "Коэффициенты успешно рассчитаны. Среднеквадратические отклонения:\n" + String.Format("Кубическая модель: {0:F3}\n", model1.error) + String.Format("Квадратическая модель: {0:F3}\n", model2.error) + String.Format("Многочлен 4-ой степени: {0:F3}\n", model3.error);
                string caption = "Успешно";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons);

            }
            catch(Exception er)
            {
                string message = er.Message;
                string caption = "Неправильные значения";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons);
                
                
            }


        }

        private void setComboBoxValues(int dateFormat)
        {
            comboBox1.Items.Clear();

            if (dateFormat == 2) {
                for (int i = 1; i <= 24; i++)
                {
                    comboBox1.Items.Add(i.ToString());
                }
            }
            else if (dateFormat == 3)
            {
                for (int i = 1; i <= 150; i++)
                {
                    comboBox1.Items.Add(i.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Methods.openFile();
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart.Series["model_1"].Points.Clear();
            Chart.Series["model_2"].Points.Clear();
            Chart.Series["model_3"].Points.Clear();
            Chart.Series["Series1"].Points.Clear();

            for (double i = 0.0; i <= dates[dates.Length - 1]; i += 0.1)
            {
                Chart.Series["model_1"].Points.AddXY(i, calculateFunctionInPoint(i, coeffs1));
                Chart.Series["model_2"].Points.AddXY(i, calculateFunctionInPoint(i, coeffs2));
                Chart.Series["model_3"].Points.AddXY(i, calculateFunctionInPoint(i, coeffs3));
            }


            for (int i = 0; i < dates.Length; i++)
            {
                Chart.Series["Series1"].Points.AddXY(dates[i], values[i]);
            }

        }

        private void predict_Click(object sender, EventArgs e)
        {
            int selectedPeriod;
            string measurment = dateFormat == 2 ? " месяцев " : " дней ";
            string count = dateFormat == 2 ? "1 и 24." : "1 и 150.";

            bool res = Int32.TryParse(comboBox1.Text, out selectedPeriod);

            if(!res || selectedPeriod <= 0 || selectedPeriod > 150)
            {
                string message = "Пожалуйста выберите количество" + measurment + "между " + count;
                string caption = "Неправильное значение";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons);
            }
            else
            {
                double newDate = dates[dates.Length - 1] + selectedPeriod;

                Chart.Series["Series1"].Points.AddXY(newDate, calculateFunctionInPoint(newDate, coeffs1));
                Chart.Series["Series1"].Points.AddXY(newDate, calculateFunctionInPoint(newDate, coeffs2));
                Chart.Series["Series1"].Points.AddXY(newDate, calculateFunctionInPoint(newDate, coeffs3));


                for (double i = dates[dates.Length - 1] + 0.00; i < newDate; i += 0.1)
                {
                    Chart.Series["model_1"].Points.AddXY(i, calculateFunctionInPoint(i, coeffs1));
                    Chart.Series["model_2"].Points.AddXY(i, calculateFunctionInPoint(i, coeffs2));
                    Chart.Series["model_3"].Points.AddXY(i, calculateFunctionInPoint(i, coeffs3));
                }

                string message = "Предсказанная стоимость после " + selectedPeriod + measurment + "будет:\n" + String.Format("Кубическая модель: {0:F3}\n", calculateFunctionInPoint(newDate, coeffs1)) + String.Format("Квадратическая модель: {0:F3}\n", calculateFunctionInPoint(newDate, coeffs2)) + String.Format("Многочлен 4-ой степени: {0:F3}\n", calculateFunctionInPoint(newDate, coeffs3));
                string caption = "Предсказанная стоимость";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons);

            }

        }
        

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Программа для прогнозирования биржевой стоимости акций \nкомпании на основе алгоритма нелинейной регрессии \n\nВыполнил: Асатрян Самвел Ваганович\nСтудент первого курса НИУ ВШЭ\n\nsvasatryan@edu.hse.ru";
            string caption = "О программе";
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption);
        }

        private void регрессияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Регрессионный анализ — метод моделирования измеряемых данных и исследования их свойств.\nРегрессионный анализ - раздел машинного обучения.\nЕго суть - поиск такой функции, которая описывает некоторую зависимость";
            string caption = "Регрессия";
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption);
        }

        private void вводДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Для ввода данных выполняйте следующие действия:\n1. Нажмите на кнопку 'Входной файл'.\n2. Вводите данные в формате ДАТА СТОИМОСТЬ, где:\n    ДАТА - Дата в формате ДД.ММ.ГГГГ либо ММ.ГГГГ,\n    СТОИМОСТЬ - Численное значение стоимости\n\nСохраняйте файл. Рекомендуется закрыть файл.\n\nПримечание: У всех дат при одном запуске должен быть одинаковый формат";
            string caption = "Ввод данных";
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption);
        }

        private void предсказываниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Для предсказывания стоимости выполняйте следующие действия.\n1. Выберите количество дней или месяцев, после которого хотите увидеть результат.\n2. Нажмите на кнопку 'Предсказывать'";
            string caption = "Ввод данных";
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption);
        }

        double calculateFunctionInPoint(double point, double[] coeffs)
        {
            double sum = 0;
            for(int i = 0; i < coeffs.Length; i++)
            {
                sum += coeffs[i] * Math.Pow(point, i);
            }
            return sum;
        }

    }
}
