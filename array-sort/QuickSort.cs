
namespace array_sort
{
    internal class QuickSort : IArraySort
    {
        public void Sort(int[] array)
        {
            PerformQuickSort(array, 0, array.Length);
        }

        private void PerformQuickSort(int[] array, int start, int end)
        {
            if (end - start < 2)
            {
                return;
            }
            int pivotIndex = Partition(array, start, end);
            PerformQuickSort(array, start, pivotIndex);
            PerformQuickSort(array, pivotIndex + 1, end);
        }

        private int Partition(int[] array, int start, int end)
        {
            int pivot = array[start];
            int i = start;
            int j = end;
            while (i < j)
            {
                while (i < j && array[--j] > pivot) ;
                if (i < j)
                {
                    array[i] = array[j];
                }
                while (i < j && array[++i] < pivot) ;
                if (i < j)
                {
                    array[j] = array[i];
                }
            }
            array[j] = pivot;
            return j;
        }

    }
}
