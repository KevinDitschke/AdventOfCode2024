using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day3;

public static class Part2
{
    public static void Run()
    {
        var text = File.ReadAllText("Day3/Input.txt");
        Console.WriteLine(FindMultiplication(text));
    }

    private static int FindMultiplication(string text)
    {
        var regex = new Regex(@"(do\(\))|(don't\(\))|mul\((\d{1,3}),(\d{1,3})\)");
        var sum = 0;
        var matches = regex.Matches(text);
        var isEnabled = true;

        foreach (Match match in matches)
        {
            if (match.Groups[1].Success)
            {
                isEnabled = true;
            }
            else if (match.Groups[2].Success)
            {
                isEnabled = false;
            }
            else if (isEnabled && match.Groups[3].Success && match.Groups[4].Success)
            {
                var num1 = int.Parse(match.Groups[3].Value);
                var num2 = int.Parse(match.Groups[4].Value);
                sum += num1 * num2;
            }
        }

        return sum;
    }
}