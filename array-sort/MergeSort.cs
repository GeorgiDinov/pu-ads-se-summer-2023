
namespace array_sort
{
    internal class MergeSort : IArraySort
    {
        public void Sort(int[] array)
        {
            PerformMergeSort(array, 0, array.Length);
        }

        private void PerformMergeSort(int[] array, int start, int end)
        {
            if (end - start < 2)
            {
                return;
            }
            int mid = (start + end) / 2;
            PerformMergeSort(array, start, mid);
            PerformMergeSort(array, mid, end);
            Merge(array, start, mid, end);
        }

        private void Merge(int[] array, int start, int mid, int end)
        {
            if (array[mid - 1] <= array[mid])
            {
                return;
            }
            int i = start;
            int j = mid;
            int tempIndex = 0;
            int[] tempArray = new int[end - start];
            while (i < mid && j < end)
            {
                tempArray[tempIndex++] = array[i] <= array[j] ? array[i++] : array[j++];
            }
            System.Array.Copy(array, i, array, start + tempIndex, mid - i);
            System.Array.Copy(tempArray, 0, array, start, tempIndex);
        }

    }
}
