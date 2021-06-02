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
    public static int alternate(string s)
        {
            string t = deleteAdjacentChars(s);

            IList<string> result = new List<string>();
            var newstr = String.Join(String.Empty, t.Distinct());
            List<string> distinctChars = newstr.ToCharArray().Select(_ => _.ToString()).ToList();
            var result2 = combination(distinctChars, 2, ",", String.Empty, result); 
            List<string> stringCompared = new List<string>();
            foreach (string chars in result)
            {
                string string1 = chars.Substring(0, 1);
                string string2 = chars.Substring(1, 1);

                List<string> charsAllowed = new List<string>();
                charsAllowed.Add(string1);
                charsAllowed.Add(string2);

                string newString2 = Regex.Replace(t, "[^" + Regex.Escape(string.Join("", charsAllowed) + "]"), delegate (Match m)
                {
                    if (!m.Success) { return m.Value; }
                    return "";
                });
                if (isTwoAlter(newString2))
                    stringCompared.Add(newString2);
            }
            if (stringCompared.Any())
                return stringCompared.OrderByDescending(_ => _.Length).First().Length;
            else
                return 0;
        }
        
    public static bool isTwoAlter(string s)
        {
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (s[i] != s[i + 2])
                {
                    return false;
                }
            }
            
            if (s[0] == s[1])
                return false;

            return true;
        }    
    public static IList<string> combination(List<string> strs, int k, string delimiter, string current, IList<string> result)
        {
            for (int i = 0; i < strs.Count; i++)
            {
                string s = strs[i];
                List<string> nextStrs = strs.FindAll((_s) => !_s.Equals(s));
                if (current.Length + 1 == k)
                {
                    if (!exist(current + s, result))
                        result.Add(current + s);
                }
                else
                {
                    combination(nextStrs, k, delimiter, current + s, result);
                }
            }

            return result;
        }

        public static bool exist(string s, IList<string> l)
        {
            foreach (string i in l)
            {
                if (sortStringAlphabet(i).Equals(sortStringAlphabet(s)))
                {
                    return true;
                }
            }
            return false;
        }

        public static string sortStringAlphabet(string s)
        {
            char[] fromS = s.ToCharArray();
            Array.Sort<char>(fromS);
            return new string(fromS);
        }
    public static string deleteAdjacentChars(string s)
        {
            var sb = new StringBuilder();
            List<string> charsNeedDeleted = new List<string>();
            sb.Append(s[0]);
            for (var i = 1; i < s.Length; i++)
            {
                if (sb.Length > 0 && s[i] == sb[sb.Length - 1]) //
                {
                    //sb = sb.Remove(sb.Length - 1, 1);
                    charsNeedDeleted.Add(s[i].ToString());
                }
                else
                    sb.Append(s[i]);
            }
            foreach (var item in charsNeedDeleted)
            {
                sb = sb.Replace(item, String.Empty);
            }

            return sb.ToString();
        }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int l = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int result = Result.alternate(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
