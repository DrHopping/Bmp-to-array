using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BmpToArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap bmp = new Bitmap("image.bmp");
            int[,] image = BmpTo2D(bmp);
            FileCheck();
            Save(ArrayToFormatString(image), "Array.txt");
        }

        static void Save(string str, string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine(str);
            sw.Close();
        }

        static void FileCheck()
        {
            if (!File.Exists("Array.txt"))
                File.Create("Array.txt").Dispose();
        }

        static string ArrayToFormatString(int[,] array)
        {
            string arrayStr = "{";

            for (int i = 0; i < array.GetLength(0); i++)
            {
                arrayStr += "{";

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j < array.GetLength(1) - 1)
                        arrayStr += array[i, j] + ",";
                    else
                        arrayStr += array[i, j];

                }

                if (i < array.GetLength(0) - 1)
                    arrayStr += "},";
                else
                    arrayStr += "}";
            }
            arrayStr += "}";

            return arrayStr;
        }

        static int[,] BmpTo2D(Bitmap bmp)
        {
            int[,] array = new int[bmp.Height, bmp.Width];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (bmp.GetPixel(j, i).B == 0)
                        array[i, j] = 0;
                    else
                        array[i, j] = 1;
                }
            }
            return array;
        }

    }
}
