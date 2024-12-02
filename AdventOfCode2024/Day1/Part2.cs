namespace AdventOfCode2024.Day1;

public static class Part2
{
    internal static void Run()
    {
        var (firstNumbers, secondNumbers) = Helper.ReadAllNumbers();
        var calculation = 0;
        foreach (var firstNumber in firstNumbers.Distinct())
        {
            calculation += firstNumber * secondNumbers.Count(x => x == firstNumber);
        }
        Console.WriteLine(calculation);
    }
}