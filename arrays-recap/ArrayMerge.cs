﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrays_recap
{
    internal class ArrayMerge
    {


        //Note this implementation, because it is very close to merge sort algorithm
        public static int[] MergeTwoSortedArrays(int[] leftArray, int[] rightArray)
        {
            int resultArrayLength = leftArray.Length + rightArray.Length;
            int[] resultArray = new int[resultArrayLength];

            int leftCursor = 0;
            int rightCursor = 0;
            int resultCursor = 0;

            while (leftCursor < leftArray.Length && rightCursor < rightArray.Length)
            {
                if (leftArray[leftCursor] < rightArray[rightCursor])
                {
                    resultArray[resultCursor++] = leftArray[leftCursor++];
                }
                else
                {
                    resultArray[resultCursor++] = rightArray[rightCursor++];
                }
            }

            while (leftCursor < leftArray.Length)
            {
                resultArray[resultCursor++] = leftArray[leftCursor++];
            }

            while (rightCursor < rightArray.Length)
            {
                resultArray[resultCursor++] = rightArray[rightCursor++];
            }

            return resultArray;
        }

    }// end of class ArrayMerge
}
