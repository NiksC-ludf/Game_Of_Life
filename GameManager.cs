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
                Thread.Sleep(1000);
            }
        }
    }
}
