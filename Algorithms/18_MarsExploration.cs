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

    /*
     * Complete the 'marsExploration' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int marsExploration(string s)
    {
            int count = 0;
            List<string> triplets = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                if (i % 3 == 0)
                    triplets.Add(s.Substring(i, 3));
            }
            foreach (string sos in triplets)
            {
                if (sos[0].ToString() != "S")
                    count++;
                if (sos[1].ToString() != "O")
                    count++;
                if (sos[2].ToString() != "S")
                    count++;
            }
            return count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = Result.marsExploration(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
