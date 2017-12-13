using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Utils
{

    public static List<string[]> getInput(string fileName, char delimiter = '\n', bool sanitized = true)
    {
        string text = getInputString(fileName);
        string[] temp = text.Split(delimiter);
        List<string[]> data = new List<string[]>();

        foreach(string str in temp)
        {
            string[] split = str.Split(' ');

            if(sanitized)
            {
                for(int i = 0; i < split.Length; i++)
                {
                    split[i] = sanitize(split[i]);
                }
            }

            data.Add(split);
        }

        return data;
    }

    public static string getInputString(string fileName)
    {
        string path;
        if(isLinux()) path = "/home/jamison/Projects/AdventOfCode2017/txt/";
        else path = @"C:\Users\JMacfarland\adventOfCode2017\txt\";
        return System.IO.File.ReadAllText(String.Format("{0}{1}", path, fileName));
    }

    public static string sanitize(string input)
    {
        return Regex.Replace(input,  "[^a-zA-Z ' ']", "");
    }

    public static bool isLinux()
    {
        int p = (int) Environment.OSVersion.Platform;
        return (p == 4) || (p == 6) || (p == 128);
    }
}