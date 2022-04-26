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
        private static UserInterface userInterface = new UserInterface();
        private static int column = userInterface.GetValueInRange(inputColumnMessage, 5, 200);
        private static int row = userInterface.GetValueInRange(inputRowMessage, 5, 200);
        private GameData gameData = new GameData(row, column);

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Play()
        {
            while (true)
            {
                gameData.GetNewGeneration();
                userInterface.Print(gameData.gameField);
                Thread.Sleep(1000);
            }
        }
    }
}
