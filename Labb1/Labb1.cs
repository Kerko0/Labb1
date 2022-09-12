using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb
{
    internal class Labb1
    {
        static int lineCounter;
        static int[,] index; //column 1: which row. column 2: start or end index ([x,0] = start index, [x,1] = end index)
        static bool isEntireStringChecked = false;

        public static void Run(string input)
        {                                
            LineColorAndPrint(input, InputIndexer(input));                     
            Console.WriteLine("Everything marked in red added together:");
            Console.WriteLine(NumberAdder(input, InputIndexer(input)));

        }

        private static int[,] InputIndexer(string input)
        {
            lineCounter = 0;
            int indexNum = 0;
            index = new int[input.Length - 1, 2];

            while (!isEntireStringChecked)
            {   
                if (lineCounter == (input.Length - 1))
                {
                    isEntireStringChecked = true;
                }

                char nextNumToCheck = input[lineCounter];

                for (int letterCount = lineCounter; letterCount < input.Length; letterCount++)
                {
                    if (char.IsLetter(input[letterCount]) || letterCount == input.Length)
                    {
                        break;
                    }
                    else if (nextNumToCheck == input[letterCount] && letterCount > lineCounter)
                    {                                    
                        SetIndex(lineCounter, letterCount + 1, indexNum);
                        indexNum++;
                        break;
                    }               
                }

                lineCounter++;
            }

            int[,] newIndex = new int[indexNum, 2];
            Array.Copy(index, newIndex, indexNum * 2);
            isEntireStringChecked = false;
            return newIndex;
        }

       private static void SetIndex(int indexStart, int indexEnd, int indexNum)
       {
            index[indexNum, 0] = indexStart;
            index[indexNum, 1] = indexEnd;
       }

        private static void LineColorAndPrint(string input, int[,] index)
        {
            ConsoleColor color(int letterNum, int row) 
                => letterNum >= index[row, 0] && letterNum < index[row, 1] ? Console.ForegroundColor = ConsoleColor.Red : Console.ForegroundColor = ConsoleColor.Gray;

            for (int row = 0; row < index.GetLength(0); row++)
            {
                for (int letterNum = 0; letterNum < input.Length; letterNum++)
                {                  
                    Console.ForegroundColor = color(letterNum, row);                    
                    Console.Write(input[letterNum]);
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }   

        private static Int64 NumberAdder(string input, int[,] index)
        {
            string bigNumbers = "0";
            Int64 totalSum = 0;
            bool addNumber(int letterNum, int row) => letterNum >= index[row, 0] && letterNum < index[row, 1] ? true : false;

            for (int row = 0; row < index.GetLength(0); row++)
            {
                for (int letterNum = 0; letterNum < input.Length; letterNum++)
                {
                    if (addNumber(letterNum, row))
                    {
                        bigNumbers = bigNumbers + input[letterNum];                   
                    }
                }

                try
                {
                    totalSum = totalSum + Convert.ToInt64(bigNumbers);
                }
                catch
                {
                    Console.WriteLine($"Invalid character in string. Some numbers wont be added to total.");
                }

                
                bigNumbers = "0";
            }

            return totalSum;
        }
    } 
}
