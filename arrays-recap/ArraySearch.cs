using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_recap
{
    internal class ArraySearch
    {


        //Linear search
        private static int LinearSearch(int[] arrayToSearchIn, int numberToSearchFor)
        {
            for (int i = 0; i < arrayToSearchIn.Length; i++)
            {
                if (arrayToSearchIn[i] == numberToSearchFor)
                {
                    return i;
                }
            }
            return -1;
        }// end of method LinearSearch


        //Binary search
        //*** remeber, works only on sorted array/collection
        private static int BinarySearch(int[] arrayToSearchIn, int numberToSearchFor)
        {
            int first = 0;
            int last = arrayToSearchIn.Length - 1;
            while (first <= last)
            {
                int mid = (first + last) / 2;
                if (arrayToSearchIn[mid] == numberToSearchFor)
                {
                    return mid;
                }

                if (arrayToSearchIn[mid] < numberToSearchFor)
                {
                    first = mid + 1;
                }
                else
                {
                    last = mid - 1;
                }
            }
            return -1;
        }// end of method BinarySearch


    }// end of class ArraySearch
}
