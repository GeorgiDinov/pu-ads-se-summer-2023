using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime_numbers
{
    internal class PrimePrinterListExample : IPrimeNumberPrinter
    {

        //        Другият начин за намиране на всички прости числа по-малки от
        //зададено е следният: за всяко следващо число k от зададения интервал
        //проверяваме дали k се дели на простите числа, които са намерени до
        //момента.Ако числото k е просто, го добавяме в списъка от прости числа и
        //продължаваме нататък. В програмата използваме списък от тип List<int>,
        //за да съхраним намерените до момента прости числа:


        public void PrintPrimeNumbersTo(int upperBoundary)
        {
            List<int> primeNumbers = new List<int>() { 2 };
            bool isPrime;
            for (int i = 3; i <= upperBoundary; i++)
            {
                isPrime = true;
                foreach (int prime in primeNumbers)
                {
                    if (i % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeNumbers.Add(i);
                }
            }

            string primesString = "";
            foreach (int prime in primeNumbers)
            {
                primesString += prime + " ";
            }
            Console.WriteLine("Primes = " + primesString);
        }

    }
}
