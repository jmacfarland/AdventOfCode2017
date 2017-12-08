using System.Collections.Generic;
class Day6
{
    public static void solve()
    {
        int[] data = getInput();
        int count = 0;
        IDictionary<string, int> history = new Dictionary<string, int>();
        history.Add(buildString(data), count);

        while(true)
        {
            count++;

            //find highest in data
            int indexOfHighest = getHighest(data);

            //redistribute
            int valueToRedistribute = data[indexOfHighest];
            int nextIndex = (indexOfHighest + 1) % data.Length;
            data[indexOfHighest] = 0;
            for(int i = 0; i < valueToRedistribute; i++)
            {
                data[nextIndex]++;
                nextIndex = (nextIndex + 1) % data.Length;
            }

            if(history.ContainsKey(buildString(data)))
            {
                System.Console.WriteLine("Day 6: " + count);
                break;
            }
            else 
            {
                history.Add(buildString(data), count);
            }
        }

        int firstIndex;
        history.TryGetValue(buildString(data), out firstIndex);
        int loopSize = count - firstIndex;
        System.Console.WriteLine("  Loop size: " + loopSize);
    }

    static string buildString(int[] input)
    {
        string result = "";

        for(int i = 0; i < input.Length; i++)
        {
            result += input[i];
        }
        return result;
    }

    static int getHighest(int[] input)
    {
        int highest = 0;
        for(int i = 0; i < input.Length; i++)
        {
            if(input[i] > input[highest]) highest = i;
        }

        return highest;
    }

    static int[] getInput()
    {
        string input = "0	5	10	0	11	14	13	4	11	8	8	7	1	4	12	11";
        //string input = "0	2	7	0";
        string[] temp = input.Split('\t');
        int[] data = new int[temp.Length];

        for(int i = 0; i < temp.Length; i++)
        {
            int.TryParse(temp[i], out data[i]);
        }

        return data;
    }
}