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
    public static string caesarCipher(string s, int k)
    {
        string result = "";
            List<string> list = new List<string>();
            for (int i = 0; i < 26; i++)
            {
                list.Add(string.Format("{0}", Convert.ToChar('A' + i)));
            }
            int asciiNumber;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsUpper(s[i]))
                {
                    asciiNumber = ((int)s[i] - 65 + k) % 26;
                    result += list[asciiNumber].ToUpper();
                }
                else if (Char.IsLower(s[i]))
                {
                    asciiNumber = ((int)s[i] - 97 + k) % 26;
                    result += list[asciiNumber].ToLower();
                }
                else
                    result += s[i];
            }
            return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
