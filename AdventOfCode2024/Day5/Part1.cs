namespace AdventOfCode2024.Day5
{
    public static class Part1
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("Day5/Input.txt");
            var rules = new List<(int, int)>();
            var updates = new List<List<int>>();
            var isUpdateSection = false;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    isUpdateSection = true;
                    continue;
                }

                if (!isUpdateSection)
                {
                    var parts = line.Split('|');
                    rules.Add((int.Parse(parts[0]), int.Parse(parts[1])));
                }
                else
                {
                    var update = line.Split(',').Select(int.Parse).ToList();
                    updates.Add(update);
                }
            }

            var validUpdates = updates.Where(update => IsValidUpdate(update, rules)).ToList();
            var middlePageNumbers = validUpdates.Select(update => update[update.Count / 2]).ToList();
            var sumOfMiddlePageNumbers = middlePageNumbers.Sum();

            Console.WriteLine(sumOfMiddlePageNumbers);
        }

        private static bool IsValidUpdate(List<int> update, List<(int, int)> rules)
        {
            var indexMap = update.Select((page, index) => (page, index)).ToDictionary(x => x.page, x => x.index);

            foreach (var (before, after) in rules)
            {
                if (indexMap.ContainsKey(before) && indexMap.ContainsKey(after))
                {
                    if (indexMap[before] > indexMap[after])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}