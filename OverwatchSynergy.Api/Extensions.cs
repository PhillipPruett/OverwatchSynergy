using System;
using System.Collections.Generic;

namespace OverwatchSynergy.Api
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence)
            {
                action(item);
            }
        }
    }
}