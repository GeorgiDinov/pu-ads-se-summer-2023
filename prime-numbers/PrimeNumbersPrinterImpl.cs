using System;

namespace prime_numbers
{
    internal class PrimeNumbersPrinterImpl : IPrimeNumberPrinter
    {


        public void PrintPrimeNumbersTo(int upperBoundary)
        {
            string primesString = "";
            for (int i = 2; i < upperBoundary + 1; i++)
            {
                if (IsPrime(i))
                {
                    primesString += i + " ";
                }
            }
            Console.WriteLine("Primes = " + primesString);
        }

        private bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for (int i = 2; i < number; i++)//spot for optimization e.g. EITHER 'i <= number/2' OR 'i <= Math.Sqrt(number)' see prof. Golev book page-11
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
