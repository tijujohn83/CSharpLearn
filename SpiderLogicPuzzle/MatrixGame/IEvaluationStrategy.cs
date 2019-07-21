using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGame
{
    public interface IEvaluationStrategy
    {
        int Evaluate(IList<Cell> cells, Cell cel);
    }
}
