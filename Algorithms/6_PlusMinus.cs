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

class Solution {

    // Complete the plusMinus function below.
    static void plusMinus(int[] arr) {
        decimal positive = 0;
        decimal negative = 0;
        decimal zero = 0;
        foreach (int i in arr)
        {
            if (i > 0)
                positive++;
            else if (i < 0)
                negative++;
            else
                zero++;                    
        }

        Console.WriteLine($"{positive/arr.Count():F6}");
        Console.WriteLine($"{negative/arr.Count():F6}");
        Console.WriteLine($"{zero/arr.Count():F6}");
    }

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
        ;
        plusMinus(arr);
    }
}
