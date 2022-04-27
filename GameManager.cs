using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Management class of the game.
    /// </summary>
    public class GameManager
    {
        private const string inputColumnMessage = "Input amount of columns.";
        private const string inputRowMessage = "Input amount of rows.";
        private const string aliveCellMessage = "Amount of alive cells: ";
        private const string iterationCounterMessage = "Current iteration: ";

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Play()
        {
            UserInterface userInterface = new UserInterface();
            int column = userInterface.GetValueInRange(inputColumnMessage, 5, 200);
            int row = userInterface.GetValueInRange(inputRowMessage, 5, 200);
            GameData gameData = new GameData(row, column);

            while (true)
            {
                gameData.GetNewGeneration();
                userInterface.Print(gameData.gameField);
                userInterface.Print(iterationCounterMessage, gameData.countOfIteration);
                userInterface.Print(aliveCellMessage, gameData.countOfAliveCells);
                Thread.Sleep(1000);
            }
        }
    }
}
