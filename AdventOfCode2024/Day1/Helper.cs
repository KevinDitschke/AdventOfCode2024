using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day1;

internal static class Helper
{
    internal static (List<int>, List<int>) ReadAllNumbers()
    {
        var lines = File.ReadAllLines("Day1/Input.txt");
        var regex = new Regex(@"\d+");
        var firstNumbers = new List<int>();
        var secondNumbers = new List<int>();
        foreach (var line in lines)
        {
            var numbers = regex.Matches(line).Select(x => int.Parse(x.Value)).ToList();
            firstNumbers.Add(numbers[0]);
            secondNumbers.Add(numbers[1]);
        }

        return (firstNumbers, secondNumbers);
    }
}