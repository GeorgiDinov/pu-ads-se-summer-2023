
namespace array_sort
{
    internal class ShellSort : IArraySort
    {
        public void Sort(int[] array)
        {
            for (int step = array.Length / 2; step > 0; step /= 2)
            {
                for (int forward = step; forward < array.Length; forward++)
                {
                    int candidateToInsert = array[forward];
                    int backward;
                    for (backward = forward; backward >= step && array[backward - step] > candidateToInsert; backward -= step)
                    {
                        array[backward] = array[backward - step];
                    }
                    array[backward] = candidateToInsert;
                }
            }
        }

    }
}
