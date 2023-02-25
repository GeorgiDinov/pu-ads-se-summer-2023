using System;

namespace array_sort
{
    internal class Program
    {

        private static Func<int, int, int[]> ArrayProducer = (capacity, randomValueUpperBoundary) =>
        {
            int[] array = new int[capacity];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(randomValueUpperBoundary);
            }
            return array;
        };

        private static Func<int[], string> ArrayToStringConverter = (array) =>
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result += (i < array.Length - 1) ? array[i] + ", " : array[i] + "";
            }
            return "[" + result + "]";
        };

        private static Action<string, int[]> ArrayPrinter = (prefix, array) =>
        {
            string result = prefix + ArrayToStringConverter(array);
            Console.WriteLine(result);
        };

        static void Main(string[] args)
        {
            int[] array = ArrayProducer(4, 100);
            ProcessArraySort(array);
            Console.WriteLine();

            array = ArrayProducer(5, 100);
            ProcessArraySort(array);
            Console.WriteLine();

            array = ArrayProducer(10, 100);
            ProcessArraySort(array);
            Console.WriteLine();

            array = ArrayProducer(15, 100);
            ProcessArraySort(array);
            Console.WriteLine();

            array = ArrayProducer(20, 100);
            ProcessArraySort(array);
            Console.WriteLine();

            array = ArrayProducer(25, 100);
            ProcessArraySort(array);
            Console.WriteLine();

        }// end of Main method

        private static void ProcessArraySort(int[] array)
        {
            ArrayPrinter("Unsorted Array = ", array);
            PerformStrategicSort(array);
            ArrayPrinter("Sorted Array   = ", array);
        }

        private static void PerformStrategicSort(int[] array)
        {
            IArraySort sortStrategy = SorterFactoryMethod(array.Length);
            if (sortStrategy != null)
            {
                string strategyName = sortStrategy.GetType().Name;
                Console.WriteLine("Selected sorting strategy is " + strategyName);
                sortStrategy.Sort(array);
            }
        }

        private static IArraySort SorterFactoryMethod(int arrayLenght)
        {
            if (arrayLenght >= 0 && arrayLenght < 5)
            {
                return new BubbleSort();
            }
            else if (arrayLenght >= 5 && arrayLenght < 10)
            {
                return new SelectionSort();
            }
            else if (arrayLenght >= 10 && arrayLenght < 15)
            {
                return new InsertionSort();
            }
            else if (arrayLenght >= 15 && arrayLenght < 20)
            {
                return new ShellSort();
            }
            else if (arrayLenght >= 20 && arrayLenght < 25)
            {
                return new MergeSort();
            }
            else if (arrayLenght >= 25)
            {
                return new QuickSort();
            }
            else
            {
                return null;
            }
        }


    }// end of class 

}// end of namespace
