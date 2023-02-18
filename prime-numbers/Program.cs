using System;
using System.Threading;


namespace prime_numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LargestPrimeFactorExampleDemo();

            PrimeNumbers();

            //Console.ReadKey(); // if needed
        }

        private static void PrimeNumbers()
        {
            IPrimeNumberPrinter erathosteneSieve = new ErathosteneSieve();
            IPrimeNumberPrinter primeNumberPrinter = new PrimeNumbersPrinterImpl();
            IPrimeNumberPrinter primePrinterListExample = new PrimePrinterListExample();

            while (true)
            {
                Console.WriteLine("Print all prime numbers up to...");
                Console.Write("Enter upper boundary = ");
                int primeNumbersUpperBoundary = Convert.ToInt32(Console.ReadLine());
                if (primeNumbersUpperBoundary <= 1)
                {
                    Console.WriteLine("Number should be '> 1'");
                    Thread.Sleep(1000);
                    continue;
                }


                Console.WriteLine("Selected upper boundary to print primes to is = {0}\n", primeNumbersUpperBoundary);

                Console.WriteLine("Using the Sieve of Erathostene");
                Thread.Sleep(2000);
                erathosteneSieve.PrintPrimeNumbersTo(primeNumbersUpperBoundary);
                Console.WriteLine();

                Console.WriteLine("Using the straght forward approach");
                Thread.Sleep(2000);
                primeNumberPrinter.PrintPrimeNumbersTo(primeNumbersUpperBoundary);
                Console.WriteLine();

                Console.WriteLine("Using the list example");
                Thread.Sleep(2000);
                primePrinterListExample.PrintPrimeNumbersTo(primeNumbersUpperBoundary);
                Console.WriteLine();

                Console.Write("Do you want to continue? y/n ");
                string response = Console.ReadLine();
                if (!"y".Equals(response))
                {
                    Console.WriteLine("Exiting the application...");
                    Thread.Sleep(1000);
                    break;
                }

                Console.WriteLine("Clearing the console...");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        private static void LargestPrimeFactorExampleDemo()
        {
            LargestPrimeFactor factor = new LargestPrimeFactor();
            Console.WriteLine("GetLargestPrimeFactor(21) = " + factor.GetLargestPrimeFactor(21));
            Console.WriteLine("GetLargestPrimeFactor(217) = " + factor.GetLargestPrimeFactor(217));
            Console.WriteLine("GetLargestPrimeFactor(0) = " + factor.GetLargestPrimeFactor(0));
            Console.WriteLine("GetLargestPrimeFactor(45) = " + factor.GetLargestPrimeFactor(45));
            Console.WriteLine("GetLargestPrimeFactor(-1) = " + factor.GetLargestPrimeFactor(-1));
            Console.WriteLine("GetLargestPrimeFactor(3) = " + factor.GetLargestPrimeFactor(3));
            Console.WriteLine("GetLargestPrimeFactor(1) = " + factor.GetLargestPrimeFactor(1));
        }

    }
}
