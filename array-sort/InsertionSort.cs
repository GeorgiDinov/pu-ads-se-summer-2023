
namespace array_sort
{
    internal class InsertionSort : IArraySort
    {

        public void Sort(int[] array)
        {
            for (int forward = 1; forward < array.Length; forward++)
            {
                int candidateToInsert = array[forward];
                int backward;
                for (backward = forward; backward > 0 && array[backward - 1] > candidateToInsert; backward--)
                {
                    array[backward] = array[backward - 1];
                }
                array[backward] = candidateToInsert;
            }
        }

    }
}
