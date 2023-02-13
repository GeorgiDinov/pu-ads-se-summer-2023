using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_recap
{
    internal class ArrayTwoDimentional
    {

        public static int[,] GetRandomMatrix(int height, int width)
        {
            int[,] matrix = new int[height, width];
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)// arr.GetLength(0) - gives the number of rows in a 2D array
            {
                for (int j = 0; j < matrix.GetLength(1); j++)// arr.GetLength(1) - gives the number of elements in the row
                {
                    matrix[i, j] = random.Next(0, 10);
                }
            }
            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            string line = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                line += "[";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += (j < matrix.GetLength(1) - 1) ? matrix[i, j] + ", " : matrix[i, j] + "";
                }
                line += "]\n";
            }
            Console.WriteLine(line);
        }

    }// end of class ArrayTwoDimentional
}
