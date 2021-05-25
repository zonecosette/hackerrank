using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hackerrank2
{
    static class Result
    {
        // Complete the miniMaxSum function below.
        public static int minimumNumber(int n, string password)
        {
            int count = 0;
            var checkNumber = Regex.Match(password, @"^(?=.*?[0-9])");
            var checkSpecial = Regex.Match(password, @"^(?=.*?[#?!@$%^&*-])");
            var checkUppercase = Regex.Match(password, @"^(?=.*?[A-Z])");
            var checkLowercase = Regex.Match(password, @"^(?=.*?[a-z])");

            
            if (!checkNumber.Success)
                count++;
            if (!checkSpecial.Success)
                count++;
            if (!checkUppercase.Success)
                count++;
            if (!checkLowercase.Success)
                count++;

            if (n + count < 6)
                return 6 - n;
            else return count;

        }

        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

			int n = Convert.ToInt32(Console.ReadLine().Trim());

			string password = Console.ReadLine();

			int answer = Result.minimumNumber(n, password);

			textWriter.WriteLine(answer);

			textWriter.Flush();
			textWriter.Close();
        }
    }
}
