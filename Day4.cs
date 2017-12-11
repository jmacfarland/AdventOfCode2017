using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Day4
{
    private static string alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static void solve()
    {
        var data = getInput();
        int count = 0;
        foreach(string[] arr in data)
        {
            if(containsAnagrams(arr) == false) count++;
        }
        Console.WriteLine("Number of valid passphrases: " + count);
    }

    static bool containsAnagrams(string[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            for(int n = i + 1; n < arr.Length; n++)
            {
                if(areAnagrams(arr[i], arr[n])) return true;
            }
        }
        return false;
    }

    //checks how many of each letter are in each string. If the amounts are the same, they are anagrams.
    static bool areAnagrams(string s1, string s2)
    {
        var f1 = getNumLetterOccurrences(s1);
        var f2 = getNumLetterOccurrences(s2);

        for(int i = 0; i < 26; i++)
        {
            if(f1[i] != f2[i]) return false;
        }
        return true;
    }

    public static int[] getNumLetterOccurrences(string text)
        {
            int[] frequency = new int[26];

            for(int i = 0; i < text.Length; i++)
            {
                for(int n = 0; n < alphabet.Length; n++)
                {
                    if(text[i] == alphabet[n])
                    {
                        frequency[n]++;
                    }
                }
            }

            return frequency;
        }

    static bool containsDuplicates(string[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            for(int n = i + 1; n < arr.Length; n++)
            {
                //Console.WriteLine(arr[i] + ", " + arr[n] + ": " + arr[i].Equals(arr[n]));
                if(arr[i].Equals(arr[n])) return true;
            }
        }
        return false;
    }

    static List<string[]> getInput()
    {
        string text = System.IO.File.ReadAllText(@"C:\Users\JMacfarland\adventOfCode2017\day4_input.txt");
        //string text = System.IO.File.ReadAllText(@"C:\Users\JMacfarland\adventOfCode2017\day4_test.txt");
        string[] temp = text.Split('\n');
        List<string[]> data = new List<string[]>();

        foreach(string str in temp)
        {
            string[] split = str.Split(' ');
            for(int i = 0; i < split.Length; i++)
            {
                split[i] = Regex.Replace(split[i],  "[^a-zA-Z ' ']", "");
            }
            data.Add(split);
        }

        return data;
    }
}