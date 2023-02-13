using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_recap
{
    internal class ArrayCopy
    {
        public static int[] CopyArrayAndIncrementLenght(int[] array)
        {
            int incrementedLength = array.Length + 1;
            int[] copy = new int[incrementedLength];

            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            return copy;
        }

        public static int[] CopyArrayAndDoubleLenght(int[] array)
        {
            int doubledLenght = array.Length * 2;
            int[] copy = new int[doubledLenght];

            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            return copy;
        }

    }// end of class ArrayCopy
}
