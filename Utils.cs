using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Utils
{

    public static List<string[]> getInput(string fileName, bool sanitized = true)
    {
        string text = System.IO.File.ReadAllText(String.Format(@"C:\Users\JMacfarland\adventOfCode2017\{0}", fileName));
        string[] temp = text.Split('\n');
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

    public static string sanitize(string input)
    {
        return Regex.Replace(input,  "[^a-zA-Z ' ']", "");
    }
}