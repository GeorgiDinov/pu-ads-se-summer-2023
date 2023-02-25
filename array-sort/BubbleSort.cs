
namespace array_sort
{
    internal class BubbleSort : IArraySort
    {

        public void Sort(int[] array)
        {
            for (int last = array.Length - 1; last > 0; last--)
            {
                bool isSorted = true;
                for (int current = 0; current < last; current++)
                {
                    int next = current + 1;
                    if (array[current] > array[next])
                    {
                        isSorted = false;
                        int temp = array[current];
                        array[current] = array[next];
                        array[next] = temp;
                    }
                }
                if (isSorted)
                {
                    break;
                }
            }
        }

    }
}
