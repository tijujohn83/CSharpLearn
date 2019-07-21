using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpiderLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[8, 8];

            int refx = 3, refy = 4;

            var neighbours = from x in Enumerable.Range(0, array.GetLength(0)).Where(x => Math.Abs(x - refx) <= 1)
                             from y in Enumerable.Range(0, array.GetLength(1)).Where(y => Math.Abs(y - refy) <= 1)
                             select new { x, y };

            neighbours.ToList().ForEach(Console.WriteLine);
        }
    }
}
