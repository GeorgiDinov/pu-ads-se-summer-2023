using Microsoft.SqlServer.Server;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace internship_tasks_examples
{
    //    Computer Science Internship Assignments
    //            Milestone Systems
    //
    //
    //****Recursively print a number as a string
    //
    //Write a recursive method that prints out the name(as a string) of each digit in a number.
    //For example, if the number is 3581, the method should print: “three, five, eight, one”.
    //The number (an integer) must be the only parameter to the method.
    //Hint: To print the names of 3581, first print the names of 358 followed by the name of the last digit (“one” ).
    //Note: Please use a programming language of your choice.Upload your solution to GitHub.
    //Bonus: Write a unit test, which verifies the correct execution of your method.
    //
    //----------------------------------------------------------------------------------------------------------------------
    //
    //****Design a set of types that represent the items that can be borrowed at a library
    //
    //This library offers books, CDs, DVDs and Blue-ray discs, and some titles can be downloaded into a file as e-books, audio or video files.
    //All kinds of items share a title and an ISBN. Books have an author and contain a number of pages,
    //whereas CDs, DVDs and Blue-ray discs can hold multiple tracks of audio or video each having a separate title and artist as well as a duration.
    //Your task is to design a set of types that can be used to retrieve the information mentioned above representing these various kinds of items.
    //Please use constructs such as inheritance, interfaces and virtual functions as you deem appropriate and focus on
    //public members defining the accessible surface of each type.
    //Note: You do not need to code the implementation of any methods and you also do not need to deal with the different file formats for downloading.
    //Diagrams are requested.

    internal class MilestoneSystems
    {


        //* this is not a coplete solution
        public static int PrintNumberInDigitWords(int number)
        {
            string[] digits = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            if (number < 10)
            {
                Console.WriteLine(digits[number]);
                return number;
            }
            int reminder = number % 10;
            number /= 10;
            Console.Write(digits[reminder] + ", ");
            return PrintNumberInDigitWords(number);
        }

    }
}
