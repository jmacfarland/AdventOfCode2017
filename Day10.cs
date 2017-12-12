#pragma warning disable 0219 //disable "assigned to but value never used" warnings

using System;
using System.Linq;
using System.Collections.Generic;

class Day10 //Knot Hash implementation
{
    public static void solve()
    {
        string real = "106,16,254,226,55,2,1,166,177,247,93,0,255,228,60,36";
        string test = "AoC 2017";
        int[] inputs = getInput(real);

        int length = 256;

        int[] data = new int[length];

        for(int i = 0; i < length; i++)
        {
            data[i] = i;
        }
        //print(inputs);
        Console.WriteLine();

        int skipSize = 0;
        int currentPos = 0;

        for(int n = 0; n < 64; n++)
        {
            foreach(int i in inputs)
            {
                data = knot(data, i, currentPos);
                //print(list);
                currentPos = (currentPos + skipSize + i) % length;
                skipSize++;
            }
        }
        
        string hash = "";
        for(int block = 0; block < 16; block++)
        {
            int temp = 0;
            for(int place = 0; place < 16; place++)
            {
                int index = (block * 16) + place;
                temp ^= data[index];
            }
            hash += temp.ToString("x2");
        }

        Console.WriteLine(hash);
    }

    static int[] getInput(string input)
    {
        int[] append = { 17, 31, 73, 47, 23 };

        List<int> inputs = new List<int>();
        foreach(char c in input)
        {
            inputs.Add((int)c);
        }

        foreach(int i in append)
        {
            inputs.Add(i);
        }

        return inputs.ToArray();
    }

    static int[] knot(int[] list, int length, int offset)
    {
        List<int> temp = new List<int>();

        for(int i = offset; i < offset + length; i++)
        {
            //Console.WriteLine(i);
            temp.Add(list[i % (list.Length)]);
        }

        temp.Reverse();

        for(int i = offset; i < offset + length; i++)
        {
            //Console.WriteLine(i);
            list[i % (list.Length)] = temp.First();
            temp.RemoveAt(0);
        }

        return list;
    }

    static void print(int[] list)
    {
        foreach(int i in list)
        {
            Console.Write(i + ", ");
        }
        Console.WriteLine();
    }
}