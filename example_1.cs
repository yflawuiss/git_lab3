﻿using System;

namespace example_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int j, num1, num2;
            string str;
            double db1, db2;
            Random rnd = new Random();
            int[] iArray1 = new int[10];
            int[] iArray2 = new int[10];
            double[] dArray1 = new double[10];
            double[] dArray2 = new double[10];

            for (j = 0; j < 10; j++)
            {
                iArray1[j] = rnd.Next(1, 101);
                iArray2[j] = 50 - rnd.Next(1, 101);
            }

            for (j = 0; j < 10; j++)
            {
                num1 = rnd.Next(1, 101);
                db1 = Convert.ToDouble(num1);
                dArray1[j] = db1 + Convert.ToDouble(rnd.Next(1, 101)) / 100;

                num2 = 50 - rnd.Next(1, 101);
                db2 = Convert.ToDouble(num2);
                dArray2[j] = db2 - Convert.ToDouble(rnd.Next(1, 101)) / 100;
            }

            Console.WriteLine("\n-----------------------------------------------");
            Console.WriteLine("\n     Масиви типу int        Масиви типу double ");
            Console.WriteLine("\n-----------------------------------------------");

            for (j = 0; j < 10; j++)
            {
                str = string.Format("\n {0, 2:D} {1, 6:D} {2, 6:D} {3, 8:D} {4, 8:F2} {5, 8:F2}",
                    j, iArray1[j], iArray2[j], j, dArray1[j], dArray2[j]);
                Console.WriteLine(str);
                Console.WriteLine("\n-----------------------------------------------");
            }

            Console.ReadKey();
        }
    }
}