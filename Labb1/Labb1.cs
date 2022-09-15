using System;

namespace Labb
{
    internal class Labb1
    {      
        public static void Run(string input)
        {          
            Index[] subStringIndex = SubStringFinder(input);

            StringColorAndPrint(input, subStringIndex);                             
            Console.WriteLine($"Everything marked red added together: {SubStringNumberAdder(input, subStringIndex)}");
        }

        private static Index[] SubStringFinder(string input)
        {
            Index[] index = new Index[input.Length];
            bool isEntireStringChecked = false;
            int lineCounter = 0;
            int i = 0;

            while (!isEntireStringChecked)
            {   
                if (lineCounter == (input.Length - 1))
                {
                    isEntireStringChecked = true;
                }

                char nextNumToCheck = input[lineCounter];

                for (int charNum = lineCounter; charNum < input.Length; charNum++)
                {
                    if (!char.IsNumber(input[charNum]) || charNum == input.Length)
                    {
                        break;
                    }
                    else if (nextNumToCheck == input[charNum] && charNum > lineCounter)
                    {                                    
                        index[i].startIndex = lineCounter;
                        index[i].stopIndex = charNum + 1;
                        i++;
                        break;
                    }               
                }

                lineCounter++;
            }
           
            Index[] newIndex = new Index[i];
            Array.Copy(index, newIndex, i);
            return newIndex;
        }

        private static void StringColorAndPrint(string input, Index[] index)
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

        private static Int64 SubStringNumberAdder(string input, Index[] index)
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
                catch(OverflowException)
                {
                    Console.WriteLine("Limit of total sum reached! Unable to add more, result may be inaccurate.");
                }
                catch(FormatException)
                {
                    Console.WriteLine("Unknown character in path, unable to add to total sum.");
                }
                
                combinedNumber = "0";
            }

            return totalSum;
        }
    } 
}
