using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internship_tasks_examples
{
    internal class MentorMateMMPrinter
    {

        private static int letterWidth;
        private static string logo;
        private static StringBuilder logoBuilder = new StringBuilder();

        public static void PrintLogoPrompt()
        {
            Console.Write("The number must be an odd integer between 2 and 10000: ");
            string input = Console.ReadLine();
            int n;
            bool parseCheck = int.TryParse(input, out n);
            while (parseCheck == false || n % 2 == 0 || n < 2 || n > 10000)
            {
                Console.Write("Invalid input entered. Input must be an odd integer between 2 and 10000: ");
                input = Console.ReadLine();
                parseCheck = int.TryParse(input, out n);
            }
            letterWidth = n;
            GenerateLogo(letterWidth);
            Console.WriteLine(logo);
        }


        private static void GenerateLogo(int number)
        {
            UpperHalfLogoGenerator(number, number, number);
        }

        private static void UpperHalfLogoGenerator(int endDash, int middleDash, int stars)
        {
            if (middleDash >= 1)
            {
                StringBuilder lineBuilder = new StringBuilder();
                lineBuilder.Append(DashSegmentBuilder(endDash));
                lineBuilder.Append(StarSegmentBuilder(stars));
                lineBuilder.Append(DashSegmentBuilder(middleDash));
                lineBuilder.Append(StarSegmentBuilder(stars));
                lineBuilder.Append(DashSegmentBuilder(endDash));
                string halfLine = lineBuilder.ToString();
                lineBuilder.Append(halfLine);
                logoBuilder.Append(lineBuilder.ToString() + '\n');
                UpperHalfLogoGenerator(endDash - 1, middleDash - 2, stars + 2);
            }
            else
            {
                LowerHalfLogoGenerator(endDash, letterWidth, 1, (letterWidth * 2) - 1);
            }
        }

        private static void LowerHalfLogoGenerator(int endDash, int endStar, int middleDash, int middleStar)
        {
            if (endDash >= 0)
            {
                StringBuilder lineBuilder = new StringBuilder();
                lineBuilder.Append(DashSegmentBuilder(endDash));
                lineBuilder.Append(StarSegmentBuilder(endStar));
                lineBuilder.Append(DashSegmentBuilder(middleDash));
                lineBuilder.Append(StarSegmentBuilder(middleStar));
                lineBuilder.Append(DashSegmentBuilder(middleDash));
                lineBuilder.Append(StarSegmentBuilder(endStar));
                lineBuilder.Append(DashSegmentBuilder(endDash));
                string halfLine = lineBuilder.ToString();
                lineBuilder.Append(halfLine);
                logoBuilder.Append(lineBuilder.ToString());
                if (endDash > 0)
                {
                    logoBuilder.Append("\n");
                }
                LowerHalfLogoGenerator(endDash - 1, endStar, middleDash + 2, middleStar - 2);
            }
            else
            {
                logo = logoBuilder.ToString();
                logoBuilder.Clear();
            }
        }


        private static string DashSegmentBuilder(int dashCount)
        {
            StringBuilder dashSegmentBuilder = new StringBuilder();
            for (int i = 0; i < dashCount; i++)
            {
                dashSegmentBuilder.Append('-');
            }
            string result = dashSegmentBuilder.ToString();
            return result;
        }

        private static string StarSegmentBuilder(int starCount)
        {
            StringBuilder starSegmentBuilder = new StringBuilder();
            for (int i = 0; i < starCount; i++)
            {
                starSegmentBuilder.Append('*');
            }
            string result = starSegmentBuilder.ToString();
            return result;
        }

    }
}
