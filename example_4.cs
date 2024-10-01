using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int jnum = 0, N = 20;
            int jAA = 0, jBB = 0;
            int j, k, temp;
            Random rnd = new Random();
            int[] iArray = new int[N];
            int[] jA = new int[N];
            int[] jB = new int[N];

            for (j = 0; j < N; j++)
            {
                iArray[j] = rnd.Next(1, 101);
            }

            Console.WriteLine("\n вихiдний масив \n\n");
            foreach (int jj in iArray)
            {
                Console.Write(" " + jj);
            }
            Console.WriteLine("\n\n");

            for (j = 0; j < N; j++)
            {
                jnum = iArray[j] / 2;
                iArray[j] = Convert.ToInt32(iArray[j]);

                if (iArray[j] == jnum * 2)
                {
                    jA[jAA] = iArray[j];
                    jAA += 1;
                }
                else
                {
                    jB[jBB] = iArray[j];
                    jBB += 1;
                }
            }

            Console.WriteLine("\n масив A[ ] \n\n");
            foreach (int jj in jA)
            {
                Console.Write(" " + jj);
            }
            Console.WriteLine("\n\n");

            Console.WriteLine("\n масив B[ ] \n\n");
            foreach (int jj in jB)
            {
                Console.Write(" " + jj);
            }
            Console.WriteLine("\n\n");

            // Сортування масиву А
            jAA -= 1;
            for (k = 0; k < jAA; k++)
            {
                for (j = 0; j < jAA; j++)
                {
                    if (jA[j + 1] < jA[j])
                    {
                        temp = jA[j];
                        jA[j] = jA[j + 1];
                        jA[j + 1] = temp;
                    }
                }
            }

            // Сортування масиву B
            jBB -= 1;
            for (k = 0; k < jBB; k++)
            {
                for (j = 0; j < jBB; j++)
                {
                    if (jB[j + 1] < jB[j])
                    {
                        temp = jB[j];
                        jB[j] = jB[j + 1];
                        jB[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\n вiдсортований масив A[ ] \n\n");
            foreach (int jj in jA)
            {
                Console.Write(" " + jj);
            }
            Console.WriteLine("\n\n");

            Console.WriteLine("\n вiдсортований масив B[ ] \n\n");
            foreach (int jj in jB)
            {
                Console.Write(" " + jj);
            }
            Console.WriteLine("\n\n");

            Console.ReadKey();
        }
    }
}