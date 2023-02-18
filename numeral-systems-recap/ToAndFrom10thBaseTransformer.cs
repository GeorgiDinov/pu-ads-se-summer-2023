using System;
using System.Collections.Generic;

namespace numeral_systems_recap
{
    internal class ToAndFrom10thBaseTransformer
    {

        public string From10thToOtherBasis(long number, int basis)
        {
            string numberRepresentation = "";
            while (number > 0)
            {
                long reminder = number % basis;
                char currentSymbol = (char)(reminder < 10 ? '0' + reminder : 'A' + reminder - 10);
                numberRepresentation = currentSymbol + numberRepresentation;
                number = number / basis;
            }
            return numberRepresentation;
        }

        public long FromOtherBasisTo10th(string numberRepresentation, int basis)
        {
            long numberIn10thBasis = 0;
            foreach (char currentSymbol in numberRepresentation)
            {
                numberIn10thBasis = numberIn10thBasis * basis + (currentSymbol >= 'A' ? currentSymbol - 'A' + 10 : currentSymbol - '0');
            }

            return numberIn10thBasis;
        }




        //Examples from the guide book
        //        Преобразуване на число от десетична в p-ична бройна система
        //За да преобразуваме едно число от десетична бройна система в бройна
        //система с основа p използваме следния алгоритъм: Започваме да делим
        //числото на основата p с частно и остатък.Остатъците добавяме в списък.
        //След това частното става изходното число и продължаваме да делим на p,
        //докато частното стане равно на 0. Обръщаме списъка с остатъците обратно
        //и това са цифрите на числото в p-ична бройна система.Когато основата на
        //новата бройна система е по-голяма от 10, за цифри използваме
        //последователно големите латински букви, като A = 10, B= 11, C= 12 и т.н.
        //Буквите получаваме, като към буквата А добавяме остатъкът минус 10 и
        //получаваме (кода на) съответната буква.За целите числа в десетична
        //бройна система използваме типа long, а резултатът се записва в списък от
        //символи.
        static void Num10toOtherBasis()
        {
            long num10;
            Console.Write("Number: ");
            num10 = Int64.Parse(Console.ReadLine());
            int basis;
            Console.Write("Basis: ");
            basis = int.Parse(Console.ReadLine());
            List<char> num_b = new List<char>();
            long priv, rem;
            do
            {
                priv = num10 / basis;
                rem = num10 % basis;
                num_b.Add((char)(rem < 10 ? '0' + rem : 'A' + rem - 10));
                num10 = priv;
            }
            while (num10 > 0);
            Console.Write("The number in new basis is: ");
            num_b.Reverse();
            foreach (char ch in num_b) Console.Write(ch);
            Console.WriteLine();
        }

        static long Num10fromOtherBasis(string num_b, int basis)
        {
            long num10 = 0;
            foreach (char ch in num_b)
                num10 = num10 * basis + (int)(ch >= 'A' ? ch - 'A' + 10 : ch - '0');
            return num10;
        }

    }
}
