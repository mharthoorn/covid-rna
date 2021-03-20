using System;
using System.Collections.Generic;
using System.Linq;

namespace RnaAnalysis
{
    public class Patterns
    {
        public static int CountPattern(ReadOnlySpan<char> range, ReadOnlySpan<char> pattern)
        {
            int index = 0, count = 0;
            while (true)
            {
                index = range.IndexOf(pattern);
                if (index > -1)
                {
                    count++;
                    range = range[(index+pattern.Length)..];
                }
                else break;
            };
            return count;
        }

        public static IOrderedEnumerable<KeyValuePair<string, int>> Tally(string range)
        {
            Dictionary<string, int> dict = new();
            for(int i = 0; i < range.Length; i++)
            {
                for (int j = 1; j < 100; j++)
                {
                    if (i + j > range.Length) continue;
                    var span = range[i..(i+j)].ToString();
                    if (dict.ContainsKey(span)) continue;
                    var count = CountPattern(range, span);
                    dict.Add(span, count);
                }
            }
            return dict.Where(i => i.Value > 1).OrderByDescending(i => i.Value); ;
        }
    }
}
