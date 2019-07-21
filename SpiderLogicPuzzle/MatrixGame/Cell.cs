using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGame
{
    public class Cell
    {
        private Player _player;
        private readonly int _x;
        private readonly int _y;

        public int X
        {
            get
            {
                return _x;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }

        public Cell(Player player, int x, int y)
        {
            _player = player;
            _x = x;
            _y = y;
        }

        public Cell(int x, int y)
        {
            _player = Player.Draw;
            _x = x;
            _y = y;
        }

        public bool IsCellEmpty()
        {
            return _player == Player.Draw;
        }

        public void SetPlayer(Player player)
        {
            if (player == Player.Draw)
                throw new ArgumentOutOfRangeException("Cannot assign empty Flag");

            _player = player;
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public bool IsNearTo(Cell cell)
        {
            if (Math.Abs(cell.X - this.X) <= 1
                && Math.Abs(cell.Y - this.Y) <= 1)
                return true;

            return false;
        }

        public int Evaluate(IList<Cell> cells, IEvaluationStrategy strategy)
        {
            return strategy.Evaluate(cells, this);
        }
    }
}
