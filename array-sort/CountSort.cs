
namespace array_sort
{
    internal class CountSort : IArraySort
    {
        public void Sort(int[] array)
        {
            //this is for automation, leads to decreased performance
            int min = Min(array);
            int max = Max(array);   
            //*consider the range between min and max not to result in too large counting array
            PerformCountSort(array, min, max);
        }

        private void PerformCountSort(int[] array, int min, int max)
        {
            int countArrayLenght = (max - min) + 1;
            int[] countArray = new int[countArrayLenght];

            for (int i = 0; i < array.Length; i++)
            {
                int countArrayIndex = array[i] - min;
                countArray[countArrayIndex]++;
            }


            int j = 0;
            for (int i = min; i <= max; i++)
            {
                int countArrayIndex = i - min;
                while (countArray[countArrayIndex] > 0)
                {
                    array[j++] = i;
                    countArray[countArrayIndex]--;
                }
            }
        }

        private int Min(int[] array)
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

        private int Max(int[] array)
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

    }
}
