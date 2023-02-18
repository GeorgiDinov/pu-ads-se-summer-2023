using System;

namespace prime_numbers
{
    internal class LargestPrimeFactor
    {

        //Write a method named getLargestPrime with one parameter of type int named number.
        //If the number is negative or does not have any prime numbers,
        //the method should return -1 to indicate an invalid value.
        //The method should calculate the largest prime factor of a given number and return it.
        //
        //  EXAMPLE INPUT/OUTPUT:
        //* GetLargestPrimeFactor(21);  should return  7 since 7 is the largest prime (3 * 7 = 21)
        //* GetLargestPrimeFactor(217); should return 31 since 31 is the largest prime (7 * 31 = 217)
        //* GetLargestPrimeFactor(0);   should return -1 since 0 does not have any prime numbers
        //* GetLargestPrimeFactor(45);  should return  5 since 5 is the largest prime (3 * 3 * 5 = 45)
        //* GetLargestPrimeFactor(-1);  should return -1 since the parameter is negative

        //HINT: Since the numbers 0 and 1 are not considered prime numbers, they cannot contain prime numbers.


        public int GetLargestPrimeFactor(int number)
        {
            if (number <= 1)
            {
                return -1;
            }
            int i;
            for (i = 2; i <= number; i++)
            {
                if (number % i == 0)
                {
                    number /= i;
                    i--;
                }
            }
            return i;
        }

    }
}
