using System;
using System.Collections.Generic;

class Day9
{
    public static void solve()
    {
        string input = Utils.getInputString("day9_input.txt");
        char[] data = input.ToCharArray();
        Stack<char> groups = new Stack<char>();
        int score = 0;

        data = removeGarbage(data);

        foreach(char c in data)
        {
            //Console.Write(c);
            if(c == '{') groups.Push('.');
            if(c == '}')
            {
                score += groups.Count;
                groups.Pop();
            }
        }
        //Console.WriteLine();

        Console.WriteLine(score);
    }

    static char[] removeGarbage(char[] data)
    {
        bool inGarbage = false;
        bool prevWasEscapeChar = false;
        string result = "";
        int amountOfGarbage = 0;

        foreach(char c in data)
        {
            if(!prevWasEscapeChar)
            {
                //we are out of the garbage if char is > but not !>
                if(inGarbage)
                {
                    if(c == '>')
                        inGarbage = false;
                    else if(c != '!')
                    {
                        amountOfGarbage++;
                    }
                }

                if(!inGarbage)
                {
                    if(c == '<')
                        inGarbage = true;

                    if(c == '{' || c == '}')
                        result += c;
                }
            }

            if(c == '!' && !prevWasEscapeChar) prevWasEscapeChar = true;
            else prevWasEscapeChar = false;
        }

        Console.WriteLine("Amount of garbage: " + amountOfGarbage);
        return result.ToCharArray();
    }
}