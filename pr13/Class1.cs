using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr13
{
    public class Soluiton
    {
        public static int GetResult(int[,] matrix)
        {
            int count1, count2, result = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                count1 = 0; count2 = 0;
                
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] < 0) count1++;
                    else count2++;
                }

                if (count1 == count2) result = j + 1;
            }

            return result;
        }
    }

    public class ArrayMod
    {
        public static void FillRandon(ref int[,] matrix)
        {
            Random rnd = new();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(-10, 10);
                }
            }
        }

        public static void Save(int[,] mas)
        {
            SaveFileDialog save = new();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                StreamWriter file = new(save.FileName);
                file.WriteLine(mas.GetLength(0));
                file.WriteLine(mas.GetLength(1));

                foreach (int i in mas)
                {
                    file.WriteLine(i);
                }
                file.Close();
            }
        }

        public static int[,]? Open()
        {
            OpenFileDialog open = new();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                StreamReader file = new(open.FileName);

                int length1 = Convert.ToInt32(file.ReadLine());
                int length2 = Convert.ToInt32(file.ReadLine());

                int[,] mas = new int[length1, length2];

                for (int i = 0; i < length1; i++)
                {
                    for (int j = 0; j < length2; j++)
                    {
                        mas[i, j] = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
                return mas;
            }
            return null;

        }
    }
}
