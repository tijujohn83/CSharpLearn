using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixGame
{
    public class Matrix
    {
        private readonly IList<Cell> _cells;

        public IList<Cell> Cells
        {
            get { return _cells; }
        }

        private readonly PlayerCount _playerCount;

        public PlayerCount PlayerCount
        {
            get { return _playerCount; }
        }

        public Matrix(int sideLength, PlayerCount playerCount)
        {
            _playerCount = playerCount;
            _cells = new List<Cell>();

            for (int i = 0; i < sideLength; i++)
            {
                for (int j = 0; j < sideLength; j++)
                {
                    _cells.Add(new Cell(i, j));
                }
            }
        }

        public void SimulateRandomGame()
        {
            _cells.Shuffle();
            int index = 0;

            while (index < _cells.Count())
                for (int currentPlayer = 1; currentPlayer <= (int)_playerCount; currentPlayer++)
                {
                    if (index < _cells.Count())
                        _cells[index].SetPlayer((Player)currentPlayer);

                    index++;
                }
            PrintMatrix();
        }

        private void PrintMatrix()
        {
            var rowCells = _cells.GroupBy(cell => cell.X).OrderBy(x => x.Key);

            foreach (var row in rowCells)
            {
                foreach (var cell in row.OrderBy(x => x.Y))
                    Console.Write(" " + cell.GetPlayer() + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public Player ComputeWinner()
        {
            Player returnVal = Player.Draw;

            var groupedPlayers = _cells
                .GroupBy(x => x.GetPlayer());

            var playersAndTheirScores = groupedPlayers
                .Select(grp => new { Player = grp.Key, TotalPoints = grp.Select(x => x.Evaluate(_cells, new EvaluationStrategyA())).Aggregate((sum, weight) => sum + weight) })
                .OrderByDescending(x => x.TotalPoints).ToList();

            if (playersAndTheirScores.Count > 1)
                if (playersAndTheirScores[0].TotalPoints != playersAndTheirScores[1].TotalPoints)
                    returnVal = playersAndTheirScores.FirstOrDefault().Player;

            foreach (var playersAndTheirScore in playersAndTheirScores)
                Console.WriteLine(playersAndTheirScore.Player + " : " + playersAndTheirScore.TotalPoints);

            return returnVal;
        }
    }
}
