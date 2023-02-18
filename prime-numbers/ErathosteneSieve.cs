using System;

namespace prime_numbers
{
    internal class ErathosteneSieve : IPrimeNumberPrinter
    {

        public void PrintPrimeNumbersTo(int upperBoundary)
        {
            bool[] sieve = new bool[upperBoundary + 1];

            for (int i = 0; i < sieve.Length; i++)
            {
                sieve[i] = true;
            }


            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i] == true)
                {
                    for (int j = i + i; j < sieve.Length; j += i)
                    {
                        sieve[j] = false;
                    }
                }

            }

            string primesString = "";
            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    primesString += i + " ";
                }
            }
            Console.WriteLine("Primes = " + primesString);
        }

    }
}
