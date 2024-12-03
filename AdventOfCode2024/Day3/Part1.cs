using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3;

public static class Part1
{
    public static void Run()
    {
        var text = File.ReadAllText("Day3/Input.txt");
        Console.WriteLine(FindMultiplication(text));
    }

    private static int FindMultiplication(string text)
    {
        var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
        var sum = 0;
        var matches = regex.Matches(text);

        foreach (Match match in matches)
        {
            if (match.Groups.Count == 3 &&
                !string.IsNullOrEmpty(match.Groups[1].Value) &&
                !string.IsNullOrEmpty(match.Groups[2].Value))
            {
                var num1 = int.Parse(match.Groups[1].Value);
                var num2 = int.Parse(match.Groups[2].Value);
                sum += num1 * num2;
            }
        }

        return sum;
    }
}