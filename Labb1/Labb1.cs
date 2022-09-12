namespace Labb
{
    internal class Labb1
    {
        public static void Run(string input)
        {
            int[,] index = InputIndexer(input);

            LineColorAndPrint(input, index);                              
            Console.WriteLine(NumberAdder(input, index));
        }

        private static int[,] InputIndexer(string input)
        {
            //[x,0] is start index
            //[x,1] is end index
            // x is row number

            bool isEntireStringChecked = false;
            int lineCounter = 0;
            int indexNum = 0;
            int[,] tempIndex = new int[input.Length - 1, 2];

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
                        tempIndex[indexNum, 0] = lineCounter;
                        tempIndex[indexNum, 1] = letterCount + 1;
                        indexNum++;
                        break;
                    }               
                }

                lineCounter++;
            }

            int[,] newIndex = new int[indexNum, 2];
            Array.Copy(tempIndex, newIndex, indexNum * 2);
            return newIndex;
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
            string combinedNumber = "0";
            Int64 totalSum = 0;
            bool addNumber(int letterNum, int row) => letterNum >= index[row, 0] && letterNum < index[row, 1] ? true : false;

            for (int row = 0; row < index.GetLength(0); row++)
            {
                for (int letterNum = 0; letterNum < input.Length; letterNum++)
                {
                    if (addNumber(letterNum, row))
                    {
                        combinedNumber = combinedNumber + input[letterNum];                   
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

            Console.WriteLine("Everything marked in red added together:");
            return totalSum;
        }
    } 
}
