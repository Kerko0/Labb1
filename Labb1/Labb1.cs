using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb
{
    internal class Labb1
    {
        static bool endIndexSet = false;
        static bool pathHasLetter = false;
        static bool isEntireStringIndexed = false;
        static int startIndex = 0;
        static int endIndex = 0;
        static int lineCount = 0;
        static string input;
        static Int64 allNumbersAdded = 0;

        public static void Run()
        {
            Console.Write("Please input a random string of letters and numbers: ");
            input = Console.ReadLine();

            while (!isEntireStringIndexed)
            {
                LineIndexer();
                LinePrinter();
                pathHasLetter = false;
                endIndexSet = false;
                lineCount++;
            }

            Console.ResetColor();
            Console.WriteLine("Everything marked in red added together:");
            Console.WriteLine(allNumbersAdded);

        }
        private static void LineIndexer()
        {
            if (lineCount == (input.Length - 1))
            {
                isEntireStringIndexed = true;
            }

            startIndex = lineCount;
            char nextNumToCheck = input[lineCount];
            for (int letterCount = 0; letterCount < input.Length; letterCount++)
            {
                if (nextNumToCheck == input[letterCount])
                {
                    if (letterCount > startIndex && !endIndexSet)
                    {
                        endIndexSet = true;
                        endIndex = letterCount + 1;
                    }
                }
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    pathHasLetter = true;
                }
            }
        }

        private static void LinePrinter()
        {
            string fullNumber = "";

            if (!pathHasLetter && endIndexSet)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (i >= startIndex && i < endIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        fullNumber = fullNumber + input[i];
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.Write(input[i]);

                }

                allNumbersAdded = allNumbersAdded + Convert.ToInt64(fullNumber);
                Console.WriteLine();
            }
        }
    }
}
