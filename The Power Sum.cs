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
     * Complete the 'powerSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER X
     *  2. INTEGER N
     */

    public static int powerSum(int X, int N)
    {
         return CountWays(X, N, 1);
}

private static int CountWays(int remaining, int power, int current)
{
    // Base case: if remaining becomes 0, we found a valid combination
    if (remaining == 0)
        return 1;
    
    // Base case: if remaining becomes negative or current^power exceeds remaining, no solution
    if (remaining < 0 || Math.Pow(current, power) > remaining)
        return 0;
    
    // Two choices:
    // 1. Include current^power in the sum
    int include = CountWays(remaining - (int)Math.Pow(current, power), power, current + 1);
    
    // 2. Exclude current^power from the sum
    int exclude = CountWays(remaining, power, current + 1);
    
    return include + exclude;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int X = Convert.ToInt32(Console.ReadLine().Trim());

        int N = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.powerSum(X, N);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
