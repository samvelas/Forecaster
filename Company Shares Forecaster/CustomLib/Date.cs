using System;

namespace Company_Shares_Forecaster
{
    public class Date: IComparable
    {
        //Массив для хранения частей
        string[] dateParts;

        //Поля для хранения дня, месяца и даты соответственно
        int day;
        int month;
        int year;

        public double cost;

        //Дата в виде строки
        public string stringDate
        {
            get;
        }

        //Цена в виде строки
        public string stringCost
        {
            get;
        }

        public int refreshedIntValue
        {
            get;
            set;
        }

        /// <summary>
        /// Возвращает количество чисел в дате. Если оно не равно 2 или 3 возвращает -1
        /// </summary>
        public int DateFormat
        {
            get
            {
                switch (dateParts.Length)
                {
                    case 2:
                        return 2;
                    case 3:
                        return 3;
                    default:
                        return -1;
                }
            }
        }


        /// <summary>
        /// Тип для хранения даты
        /// </summary>
        /// <param name="date">Параметр в виде ДД.ММ.ГГГГ или ММ.ГГГГ</param>
        /// <param name="cost">Параметр задающий цену</param>
        public Date(string date, string cost)
        {

            if (!double.TryParse(cost.Replace(',', '.'), out this.cost))
            {
                throw new ArgumentException("Не допускаются не численные значения");
            }

            if(this.cost <= 0)
            {
                throw new ArgumentException("Стоимость должна быть положительной.");
            }

            //Разбивает дату на части
            dateParts = date.Split(new char[] { ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (DateFormat == 2)
            {
                if (!Int32.TryParse(dateParts[0], out month) || !Int32.TryParse(dateParts[1], out year))
                {
                    throw new ArgumentException("Некорректная дата");
                }
                

                if (month <= 0 || month >= 13 || year <=0 || year >= 2500)
                {
                    throw new ArgumentException("Некорректная дата");
                }

            }
            else if (DateFormat == 3)
            {
                if(!Int32.TryParse(dateParts[0], out day) || !Int32.TryParse(dateParts[1], out month) || !Int32.TryParse(dateParts[2], out year))
                {
                    throw new ArgumentException("Некорректная дата");
                }



                if (month <= 0 || month >= 13 || year < 2000 || year >= 2500 || day <= 0 || day >= 32)
                {
                    throw new ArgumentException("Некорректная дата");
                }
            }
            else
            {
                throw new ArgumentException("Некорректная дата");
            }

            

            stringDate = date;
            stringCost = cost;
            refreshedIntValue = convertToNumber();
        }

        

        /// <summary>
        /// Перегруженный оператор <
        /// </summary>
        /// <param name="first">Первая дата</param>
        /// <param name="second">Вторая дата</param>
        /// <returns>true если первая дата былы раньше второй. false в противном случии</returns>
        public static bool operator <(Date first, Date second)
        {

            if (first.year < second.year)
            {
                return true;
            }
            else if (first.year == second.year)
            {
                if (first.month < second.month)
                {
                    return true;
                }
                else if (first.month == second.month)
                {
                    if (first.DateFormat == 3)
                    {
                        if (first.day < second.day)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Перегруженный оператор >
        /// </summary>
        /// <param name="first">Первая дата</param>
        /// <param name="second">Вторая дата</param>
        /// <returns>true если первая дата былы после второй. false в противном случии</returns>
        public static bool operator >(Date first, Date second)
        {

            if (first.year > second.year)
            {
                return true;
            }
            else if (first.year == second.year)
            {
                if (first.month > second.month)
                {
                    return true;
                }
                else if (first.month == second.month)
                {
                    if (first.DateFormat == 3)
                    {
                        if (first.day > second.day)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Считает количество дней или месяцев с 1 года
        /// </summary>
        /// <returns>Количество дней или месяцев с 1 года</returns>
        public int convertToNumber()
        {
            int res = 0;
            int[] daysInMonths = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (DateFormat == 3)
            {
                int longYears = (year - 1) / 4;
                int normalYears = year - longYears - 1;

                res += longYears * 366 + normalYears * 365;

                if (year % 4 == 0)
                {
                    daysInMonths[1] = 29;
                }

                for (int i = 0; i < month - 1; i++)
                {
                    res += daysInMonths[i];
                }

                res += day - 1;

            }

            if (DateFormat == 2)
            {
                res += (year - 1) * 12 + month;
            }

            return res;
        }

        public int CompareTo(object obj)
        {
            Date second = (Date)obj;

            if(this.convertToNumber() < second.convertToNumber())
            {
                return -1;
            }
            else if (this.convertToNumber() > second.convertToNumber())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
