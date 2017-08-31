using System;
using System.Linq;

namespace CustomLib
{
    public class LSM
    {
        // Массивы значений Х и У 
        public double[] X { get; set; }
        public double[] Y { get; set; }

        // коэффициенты
        private double[] theta;
        public double[] Theta { get { return theta; } }

        // Суммарная ошибка
        public double error { get { return getError(); } }

        // Конструктор класса.
        public LSM(double[] x, double[] y)
        {
            X = new double[x.Length];
            Y = new double[y.Length];

            for (int i = 0; i < x.Length; i++)
            {
                X[i] = x[i];
                Y[i] = y[i];
            }
        }
        
        public void Polynomial(int degree)
        {
            // массив для хранения значений
            double[,] mass = new double[X.Length, degree + 1];

            // заполнение массива для базисных функций
            for (int i = 0; i < mass.GetLength(0); i++)
                for (int j = 0; j < mass.GetLength(1); j++)
                    mass[i, j] = Math.Pow(X[i], j);
            
            Matrix xMatrix = new Matrix(mass);
            
            Matrix xTranspose = xMatrix.Transposition();
            
            //Домножим обе сторона уравнения на Х транспонированную

            Matrix helpMatrix = xTranspose * xMatrix;
            
            Matrix helpMatrix2 = xTranspose * new Matrix(Y);
            
            Matrix thetaMatrix = helpMatrix.InverseMatrix() * helpMatrix2;
            
            theta = new double[thetaMatrix.Row];
            for (int i = 0; i < theta.Length; i++)
            {
                theta[i] = thetaMatrix.Args[i, 0];
            }
        }
        
        private double getError()
        {
            double[] difference = new double[Y.Length];
            double[] function = new double[X.Length];
            for (int i = 0; i < X.Length; i++)
            {
                for (int j = 0; j < theta.Length; j++)
                {
                    function[i] += theta[j] * Math.Pow(X[i], j);
                }
                difference[i] = Math.Sqrt(Math.Pow((function[i] - Y[i]), 2));
            }

            return difference.Sum();
        }
    }
}
