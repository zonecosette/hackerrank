using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static string pangrams(string s)
    {
        var uniqueString = new string(s.Replace(" ", "").ToLower().Distinct().ToArray());
            int count = 0;
            foreach (var item in uniqueString)
            {
                if ((int)item >= 97 && (int)item <= 122)
                    count++;
                if (count >= 26)
                    return "pangram";
            }
            return "not pangram";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.pangrams(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
