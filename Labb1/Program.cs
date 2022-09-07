using System;
using System.Data;

string input = "29535123p48723487597645723645";
bool endIndexSet = false;
bool pathHasLetter = false;
bool isEntireStringIndexed = false;
int startIndex = 0;
int endIndex = 0;

int lineCount = 0;
while (!isEntireStringIndexed)
{
    LineIndexer();
    LinePrinter(startIndex, endIndex);
    pathHasLetter = false;
    endIndexSet = false;
    lineCount++;
}

void LineIndexer()
{
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

    for(int i = 0 + startIndex; i < endIndex; i++)
    {
        if (char.IsLetter(input[i]))
        {
            pathHasLetter = true;
        }                 
    }

    if(endIndex == input.Length)
    {
        isEntireStringIndexed = true;
    }
}

void LinePrinter(int startIndex, int endIndex)
{
    if (!pathHasLetter)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if(i >= startIndex && i < endIndex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.Write(input[i]);

        }

        Console.WriteLine();
    }
}

