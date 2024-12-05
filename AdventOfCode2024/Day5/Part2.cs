using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2024.Day5
{
    public static class Part2
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

            var invalidUpdates = updates.Where(update => !IsValidUpdate(update, rules)).ToList();
            var correctedUpdates = invalidUpdates.Select(update => CorrectUpdate(update, rules)).ToList();
            var middlePageNumbers = correctedUpdates.Select(update => update[update.Count / 2]).ToList();
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

        private static List<int> CorrectUpdate(List<int> update, List<(int, int)> rules)
        {
            var graph = new Dictionary<int, List<int>>();
            var inDegree = new Dictionary<int, int>();

            foreach (var page in update)
            {
                graph[page] = new List<int>();
                inDegree[page] = 0;
            }

            foreach (var (before, after) in rules)
            {
                if (graph.ContainsKey(before) && graph.ContainsKey(after))
                {
                    graph[before].Add(after);
                    inDegree[after]++;
                }
            }

            var queue = new Queue<int>(inDegree.Where(kv => kv.Value == 0).Select(kv => kv.Key));
            var sortedList = new List<int>();

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                sortedList.Add(current);

                foreach (var neighbor in graph[current])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return sortedList;
        }
    }
}