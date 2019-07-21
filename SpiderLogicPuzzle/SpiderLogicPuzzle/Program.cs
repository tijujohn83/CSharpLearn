using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatrixGame;

namespace SpiderLogicPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixGame = new Matrix(4, PlayerCount.Two);
            matrixGame.SimulateRandomGame();

            Console.WriteLine("The Winner is : " + matrixGame.ComputeWinner());
            Console.ReadKey();
        }
    }
}

