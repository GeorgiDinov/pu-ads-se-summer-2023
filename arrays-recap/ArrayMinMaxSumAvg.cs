using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_recap
{
    internal class ArrayMinMaxSumAvg
    {
        public static int GetMinValueInSingleDimentionalArray(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        public static int GetMaxValueInSingleDimentionalArray(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public static int SumAllElementsInSingleDimentionalArray(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public static double GetAverageOfSingleDimentionalArray(int[] array)
        {
            int sum = SumAllElementsInSingleDimentionalArray(array);
            return sum / array.Length;
        }

    }// end of class ArrayMinMaxSumAvg
}
