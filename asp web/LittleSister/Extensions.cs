using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleSister
{
    static class Extensions
        {
            public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
            {
                foreach (var i in ie)
                {
                    action(i);
                }
            }
        }
}
