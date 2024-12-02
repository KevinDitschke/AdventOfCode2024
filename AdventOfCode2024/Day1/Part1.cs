using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day1;

internal static class Part1
{
    internal static void Run()
    {
        var (firstNumbers, secondNumbers) = Helper.ReadAllNumbers();
        firstNumbers.Sort();
        secondNumbers.Sort();
        var sum = 0;
        for (int i = 0; i < firstNumbers.Count; i++)
        {
            sum += Math.Abs(firstNumbers[i] - secondNumbers[i]);
        }
        Console.WriteLine(sum);
    }
    
   
}