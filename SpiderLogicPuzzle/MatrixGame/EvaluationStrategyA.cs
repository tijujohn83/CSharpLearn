using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGame
{
    public class EvaluationStrategyA : IEvaluationStrategy
    {
        public int Evaluate(IList<Cell> cells, Cell cel)
        {
            int count = 0;
            foreach (var cell in cells)
            {
                if (!ReferenceEquals(cell, cel) && cell.IsNearTo(cel))
                    if (cell.GetPlayer() == cel.GetPlayer())
                        count++;
            }

            //Console.WriteLine(_player + " : Cell [" + X + ", " + Y + "] :" + count);
            return count;
        }
    }
}
