using System;

namespace Labb
{
    internal class Labb1
    {      
        public static void Run(string input)
        {          
            Index[] index = InputIndexer(input);

            LineColorAndPrint(input, index);                             
            Console.WriteLine($"Everything marked red added together: {NumberAdder(input, index)}");
        }

        private static Index[] InputIndexer(string input)
        {
            Index[] index = new Index[input.Length];
            bool isEntireStringChecked = false;
            int lineCounter = 0;
            int newIndexSize = 0;

            while (!isEntireStringChecked)
            {   
                if (lineCounter == (input.Length - 1))
                {
                    isEntireStringChecked = true;
                }

                char nextNumToCheck = input[lineCounter];

                for (int charCount = lineCounter; charCount < input.Length; charCount++)
                {
                    if (char.IsLetter(input[charCount]) || charCount == input.Length)
                    {
                        break;
                    }
                    else if (nextNumToCheck == input[charCount] && charCount > lineCounter)
                    {                                    
                        index[newIndexSize].startIndex = lineCounter;
                        index[newIndexSize].stopIndex = charCount + 1;
                        newIndexSize++;
                        break;
                    }               
                }

                lineCounter++;
            }

            Index[] newIndex = new Index[newIndexSize];
            Array.Copy(index, newIndex, newIndexSize);
            return newIndex;
        }

        private static void LineColorAndPrint(string input, Index[] index)
        {
            ConsoleColor color(int charNum, int row) 
                => charNum >= index[row].startIndex && charNum < index[row].stopIndex ? Console.ForegroundColor = ConsoleColor.Red : Console.ForegroundColor = ConsoleColor.Gray;

            for (int row = 0; row < index.Length; row++)
            {
                for (int charNum = 0; charNum < input.Length; charNum++)
                {                  
                    Console.ForegroundColor = color(charNum, row);                    
                    Console.Write(input[charNum]);
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }   

        private static Int64 NumberAdder(string input, Index[] index)
        {
            string combinedNumber = "0";
            Int64 totalSum = 0;
            bool addNumber(int charNum, int row) => charNum >= index[row].startIndex && charNum < index[row].stopIndex ? true : false;

            for (int row = 0; row < index.Length; row++)
            {
                for (int charNum = 0; charNum < input.Length; charNum++)
                {
                    if (addNumber(charNum, row))
                    {
                        combinedNumber = combinedNumber + input[charNum];                   
                    }
                }
                try
                {
                    totalSum = totalSum + Convert.ToInt64(combinedNumber);
                }
                catch
                {
                    Console.WriteLine("Invalid character in string. Some numbers wont be added to total.");
                }
                
                combinedNumber = "0";
            }

            return totalSum;
        }
    } 
}
