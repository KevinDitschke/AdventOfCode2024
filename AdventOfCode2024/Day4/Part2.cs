namespace AdventOfCode2024.Day4;

public static class Part2
{
    public static void Run()
    {
        var text = File.ReadAllLines("Day4/Input.txt");
        var array = text.Select(x => x.ToCharArray()).ToArray();
        var sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                sum += FoundXmas(array, i, j);
            }
        }

        Console.WriteLine(sum);
    }

    private static int FoundXmas(char[][] array, int i, int j)
    {
        if (array[i][j] != 'A')
            return 0;

        var target = "MAS";
        var target2 = "SAM";
        var sum = 0;
        try
        {
            var topLeftToBottomRight = new string(new[] { array[i - 1][j - 1], array[i][j], array[i + 1][j + 1] });
            var bottomLeftToTopRight = new string(new[] { array[i + 1][j - 1], array[i][j], array[i - 1][j + 1] });

            if ((topLeftToBottomRight == target || topLeftToBottomRight == target2) &&
                (bottomLeftToTopRight == target || bottomLeftToTopRight == target2))
            {
                Console.WriteLine($"{topLeftToBottomRight} {bottomLeftToTopRight}");
                sum++;
            }

            
        }
        catch (IndexOutOfRangeException)
        {
        }

        return sum;
    }
}