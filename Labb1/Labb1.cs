﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb
{
    internal class Labb1
    {
        static bool endIndexSet;
        static bool pathHasLetter;    
        static int lineCount;
        static int startIndex;
        static int endIndex;       
        static Int64 allNumbersAdded;

        static bool isEntireStringIndexed = false;
        public static void Run(string readInput)
        {
            lineCount = 0;
            startIndex = 0;

            while (!isEntireStringIndexed)
            {
                InputIndexer(readInput);

                if (!pathHasLetter && endIndexSet)
                {
                    LinePrinter(readInput, startIndex, endIndex);
                    NumberAdder(readInput, startIndex, endIndex);
                }

                pathHasLetter = false;
                endIndexSet = false;
                lineCount++;
            }

            Console.ResetColor();
            Console.WriteLine("Everything marked in red added together:");
            Console.WriteLine(allNumbersAdded);

        }
        private static void InputIndexer(string input)
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

        private static void LinePrinter(string input, int startIndex, int endIndex)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (i >= startIndex && i < endIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.Write(input[i]);
            }

            Console.WriteLine();
        }

        private static void NumberAdder(string input, int startIndex, int endIndex)
        {
            string fullNumber = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (i >= startIndex && i < endIndex)
                {
                    fullNumber = fullNumber + input[i];
                }
                
            }

            allNumbersAdded = allNumbersAdded + Convert.ToInt64(fullNumber);
        }
       
    }
}
