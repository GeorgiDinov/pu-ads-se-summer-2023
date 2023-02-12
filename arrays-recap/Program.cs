using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_recap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintArrayDeclarations();
        }

        private static void PrintArrayDeclarations()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            PrintSingleDimentionArray(array, "Array declaration 'int[] array = { 1, 2, 3, 4, 5 };'   = ");
            array = new int[] { 1, 2 };
            PrintSingleDimentionArray(array, "Array declaration 'int[] array = new int[] { 1, 2 };'  = ");
            array = new int[5];
            PrintSingleDimentionArray(array, "Array declaration 'int[] array = new int[5];'          = ");
        }

        private static void PrintSingleDimentionArray(int[] array, string prefix)
        {
            string arrString = GetArrayAsString(array);
            string message = prefix + arrString;
            Console.WriteLine(message);
        }

        private static string GetArrayAsString(int[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += (i < array.Length - 1) ? array[i] + ", " : array[i] + "";
            }
            return "[" + result + "]";
        }
    }
}
