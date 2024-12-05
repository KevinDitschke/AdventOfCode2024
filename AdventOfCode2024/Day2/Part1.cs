using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day2;

public static class Part1
{
    public static void Run()
    {
        var lines = File.ReadAllLines("Day2/Input.txt");
        var regex = new Regex(@"\d+");
        var sum = 0;

        foreach (var line in lines)
        {
            var numbers = regex.Matches(line).Select(x => int.Parse(x.Value)).ToList();
            if (IsSafe(numbers))
                sum++;
        }
        Console.WriteLine(sum);
    }

    private static bool IsSafe(List<int> numbers)
    {
        var allFine = true;
        var allSameDirection = numbers[0] > numbers[1];
        for (int i = 1; i < numbers.Count; i++)
        {
            if(numbers[i] == numbers [i-1])
                allFine = false;
            if (Math.Abs(numbers[i] - numbers[i - 1]) > 3)
                allFine = false;
            if((numbers[i] > numbers[i-1]) == allSameDirection)
                allFine = false;
        }
        // Console.Write("Numbers: ");
        // numbers.ForEach(x => Console .Write( x + " "));
        // Console.Write(" is " + (allFine ? "safe" : "not safe"));
        // Console.WriteLine();
        return allFine;
    }
}