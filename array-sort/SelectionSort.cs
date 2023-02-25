
namespace array_sort
{
    internal class SelectionSort : IArraySort
    {
        public void Sort(int[] array)
        {
            for (int last = array.Length - 1; last > 0; last--)
            {
                int indexHoldingMaxValue = last;
                for (int current = 0; current < last; current++)
                {
                    if (array[current] > array[indexHoldingMaxValue])
                    {
                        indexHoldingMaxValue = current;
                    }
                }
                int temp = array[last];
                array[last] = array[indexHoldingMaxValue];
                array[indexHoldingMaxValue] = temp;
            }
        }

    }
}
