using System;
using System.IO;
using System.Diagnostics;

namespace Company_Shares_Forecaster
{
    public class Methods
    {
        //Путь к входному файлу
        static string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\data.txt";
        //static string resPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\res.txt";

        static Process fileProcess;
        
        /// <summary>
        /// Открыает или создает файл
        /// </summary>
        static public void openFile()
        {
            //Создает файл с помощью потока
            FileStream fs = new FileStream(dataPath, FileMode.OpenOrCreate);
            
            //Запускает файл
            fileProcess = Process.Start(dataPath);

            //fileProcess.Close();
            
            //Закрывает поток
            fs.Close();
            
        }

        /// <summary>
        /// Читает из файла данные
        /// </summary>
        /// <param name="dates"></param>
        static public void readData(out Date[] dates)
        {
            int it = 0;
            
            //Входные данные
            string[] data = File.ReadAllLines(dataPath);
            

            //Возращаемый массив
            dates = new Date[data.Length];
            

            foreach(string line in data)
            {
                //Разбивает на части строку
                string[] parts = line.Split(new char[] {' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);


                if (parts.Length != 2) //Проверяет количество частей в строке
                {
                    throw new ArgumentException("Пожалуйста введите одну пару значений в одной строке");
                }
                else
                {
                    try
                    {
                        //Создает новый объект класса Date с значениями текущей строки
                        Date cur = new Date(parts[0], parts[1]);

                        //Добавляет в массив
                        dates[it] = cur;

                        //Прверяет все ли даты имеют один и тот же формат
                        if(cur.DateFormat != dates[0].DateFormat)
                        {
                            throw new ArgumentException("Все даты должны иметь одинаковый формат");
                        }

                        it++;

                    }
                    catch(ArgumentException e)
                    {
                        throw new ArgumentException(e.Message);
                    }
                }
                
            }

        }

        /// <summary>
        /// Сортирует входные данные по возрастанию даты
        /// </summary>
        /// <param name="dates">Ссылка на сортированный массив</param>
        static public void sortDates(out double[] dates, out double[] values,  out int dateFormat)
        {

            //Читает данные
            readData(out Date[] data);

            dates = new double[data.Length];
            values = new double[data.Length];
           


            if (values.Length <= 4)
            {
                throw new ArgumentException("Необходимо ввести минимум 5 данных");
            }

            //Сортирует данные
            Array.Sort(data);
            
            string[] sorted = new string[data.Length];

            //Переписывает в файл сортированные данные
            for(int i = 0; i < data.Length; i++)
            {
                sorted[i] = data[i].stringDate + '\t' + data[i].stringCost;

                //Вычитывает от всех дат самую раннюю дату
                data[i].refreshedIntValue -= data[0].convertToNumber();

               
                dates[i] = data[i].refreshedIntValue;
                values[i] = data[i].cost;

            }

            dateFormat = data[0].DateFormat;

            File.WriteAllLines(dataPath, sorted);

            //Закрывает файл
            //fileProcess.CloseMainWindow();
            //fileProcess.Close();
        }

    }
}
