using System;

namespace numeral_systems_recap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ToAndFrom10thBaseTransformer transformer = new ToAndFrom10thBaseTransformer();

            //string representation = transformer.From10thToOtherBasis(1000, 8);
            //Console.WriteLine(representation);

            //long numberIn10th = transformer.FromOtherBasisTo10th(representation, 8);
            //Console.WriteLine(numberIn10th);

            PrintAsciis();
        }

        private static void PrintAsciis()
        {
            Console.WriteLine("\t\tDigits");
            for (int i = '0'; i <= '9'; i++)
            {
                char ch = (char)i;
                Console.WriteLine("\t'" + ch + "'" + " decimal ascii code is = " + i);
            }

            Console.WriteLine("\t\tUpper case letters");
            for (int i = 'A'; i <= 'Z'; i++)
            {
                char ch = (char)i;
                Console.WriteLine("\t'" + ch + "'" + " decimal ascii code is = " + i);
            }

            Console.WriteLine("\t\tLower case letters");
            for (int i = 'a'; i <= 'z'; i++)
            {
                char ch = (char)i;
                Console.WriteLine("\t'" + ch + "'" + " decimal ascii code is = " + i);
            }
        }
    }
}
