using System;
using System.Collections.Generic;
using System.IO;

namespace dz0710
{
    internal class Program
    {
        static int CountGlasn(char[] ab)
        {
            List<char> gl = new List<char>() { 'а', 'е', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            int k = 0;
            foreach (char c in ab)
            {
                if (gl.Contains(char.ToLower(c)))
                {
                    k++;
                }
            }
            return k;
        }

        static int CountSogl(char[] ab)
        {
            List<char> sg = new List<char>()
            {
                'б','в','г','д','ж','з','й','к','л','м','н','п','р','с',
                'т','ф','х','ц','ч','ш','щ'
            };
            int k = 0;
            foreach (char c in ab)
            {
                if (sg.Contains(char.ToLower(c)))
                {
                    k++;
                }
            }
            return k;
        }

        static int[,] Product(int[,] matrix, int[,] matrix2)
        {
            int str = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int str2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);

            if (cols != str2)
            {
                throw new ArgumentException("Количество столбцов в первой матрице и строк во второй матрице должны совпадать");
            }

            int[,] product = new int[str, cols2];

            for (int i = 0; i < str; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        product[i, j] += matrix[i, k] * matrix2[k, j];
                    }
                }
            }

            return product;
        }

        static void Result(int[,] newmatrix)
        {
            int strs = newmatrix.GetLength(0);
            int colses = newmatrix.GetLength(1);

            for (int i = 0; i < strs; i++)
            {
                for (int j = 0; j < colses; j++)
                {
                    Console.Write(newmatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] EXPERIMENT)
            //Посчитать кол-во гласных и согласных букв 
        {
            Console.WriteLine("Задание 6.1");
            Console.WriteLine("Введите название файла");
            string path = Console.ReadLine();

            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                Console.WriteLine("Файл не найден");

                return;
            }

            string fl = File.ReadAllText(path);
            char[] ab = fl.ToCharArray();
            int glscount = CountGlasn(ab);
            int soglcount = CountSogl(ab);

            Console.WriteLine("Количество гласных букв: " + glscount);
            Console.WriteLine("Количество согласных букв: " + soglcount);

            Console.WriteLine("Задание 6.2");
            //Перемножить 2 матрицы 

            int[,] matrix =
            {
                {1, 2, 3 },
                {4, 5, 6 },
                {6, 7, 8 },
            };

            int[,] matrix2 =
            {
                {9, 10 },
                {11, 12 },
                {13, 14 },
            };

            int[,] result = Product(matrix, matrix2);

            Result(matrix);
            Console.WriteLine();
            Result(matrix2);
            Console.WriteLine();
            Result(result);

            Console.ReadKey();
        }
    }
}