using MatrixGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MatrixGameUnitTests
{
    
    
    /// <summary>
    ///This is a test class for MatrixTest and is intended
    ///to contain all MatrixTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MatrixTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        ///A test for SimulateRandomGame
        ///</summary>
        [TestMethod()]
        public void SimulateRandomGameTest()
        {
            int sideLength = 4;
            PlayerCount playerCount = PlayerCount.Two;
            Matrix target = new Matrix(sideLength, playerCount);
            target.SimulateRandomGame();

            foreach (var cell in target.Cells)
            {
                Assert.IsTrue(cell.GetPlayer() != Player.Draw);
            }
            Assert.IsTrue(target.PlayerCount == PlayerCount.Two);
        }

        /// <summary>
        ///A test for ComputeWinner
        ///</summary>
        [TestMethod()]
        public void ComputeWinnerTest()
        {
            int sideLength = 3;
            PlayerCount playerCount = PlayerCount.Two;
            Matrix target = new Matrix(sideLength, playerCount);
            Player expected = new Player();
            Player actual;
            actual = target.ComputeWinner();
            Assert.AreEqual(expected, actual);
        }
    }
}
