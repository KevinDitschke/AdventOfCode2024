namespace AdventOfCode2024.Day4;

public static class Part1
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
        if (array[i][j] != 'X')
            return 0;

        var target = "XMAS";
        var len = target.Length;
        var sum = 0;

        // Check horizontally (left to right)
        if (j + len <= array[i].Length && new string(array[i][j..(j + len)]) == target)
            sum++;

        // Check horizontally (right to left)
        if (j - len + 1 >= 0 && new string(array[i][(j - len + 1)..(j + 1)].Reverse().ToArray()) == target)
            sum++;

        // Check vertically (top to bottom)
        if (i + len <= array.Length && new string(array[i..(i + len)].Select(row => row[j]).ToArray()) == target)
            sum++;

        // Check vertically (bottom to top)
        if (i - len + 1 >= 0 && new string(array[(i - len + 1)..(i + 1)].Select(row => row[j]).Reverse().ToArray()) ==
            target)
            sum++;

        // Check diagonally (top left to bottom right)
        if (i + len <= array.Length && j + len <= array[i].Length)
        {
            var diagonal = new char[len];
            for (int k = 0; k < len; k++)
            {
                diagonal[k] = array[i + k][j + k];
            }

            if (new string(diagonal) == target)
                sum++;
        }

        // Check diagonally (bottom right to top left)
        if (i - len + 1 >= 0 && j - len + 1 >= 0)
        {
            var diagonal = new char[len];
            for (int k = 0; k < len; k++)
            {
                diagonal[k] = array[i - k][j - k];
            }

            if (new string(diagonal) == target)
                sum++;
        }

        // Check diagonally (top right to bottom left)
        if (i + len <= array.Length && j - len + 1 >= 0)
        {
            var diagonal = new char[len];
            for (int k = 0; k < len; k++)
            {
                diagonal[k] = array[i + k][j - k];
            }

            if (new string(diagonal) == target)
                sum++;
        }

        // Check diagonally (bottom left to top right)
        if (i - len + 1 >= 0 && j + len <= array[i].Length)
        {
            var diagonal = new char[len];
            for (int k = 0; k < len; k++)
            {
                diagonal[k] = array[i - k][j + k];
            }

            if (new string(diagonal) == target)
                sum++;
        }

        return sum;
    }
}