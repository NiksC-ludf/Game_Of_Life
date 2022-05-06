using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameOfLife
{
    /// <summary>
    /// Management class of the game.
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Play()
        {
            UserInterface userInterface = new UserInterface();
            ConsoleKeyInfo consoleKeyInfo;
            GameData gameData;
            userInterface.PrintRules();

            if (userInterface.GetValueInRange(Repository.choice, (int)MenuOptions.optionNewRandomGame, (int)MenuOptions.optionLoadSavedGame) == (int)MenuOptions.optionNewRandomGame)
            {
                int column = userInterface.GetValueInRange(Repository.inputColumnMessage, Repository.minColumnCount, Repository.maxColumnCount);
                int row = userInterface.GetValueInRange(Repository.inputRowMessage, Repository.minRowCount, Repository.maxRowCount);
                gameData = new GameData(row, column);
            }
            else
            {
                gameData = LoadGame(Repository.filePath);
            }

            do
            {
                while (Console.KeyAvailable == false)
                {
                    gameData.GetNewGeneration();
                    userInterface.Print(gameData.gameField);
                    userInterface.Print(Repository.iterationCounterMessage, gameData.countOfIteration);
                    userInterface.Print(Repository.aliveCellMessage, gameData.countOfAliveCells);
                    Console.WriteLine(Repository.exitOrSaveMessage);
                    Thread.Sleep(1000);
                }

                consoleKeyInfo = Console.ReadKey(true);

                if(consoleKeyInfo.Key == ConsoleKey.S)
                {
                    SaveGame(gameData);
                }

            } while (consoleKeyInfo.Key != ConsoleKey.Z);
        }

        /// <summary>
        /// Save game information to file.
        /// </summary>
        /// <param name="gameData">Generation object to save.</param>
        public void SaveGame(GameData gameData)
        {
            DataSerialization dataSerialization = new DataSerialization();
            dataSerialization.SerializeObject(gameData, Repository.filePath);
        }

        /// <summary>
        /// Load saved game from file.
        /// </summary>
        /// <param name="fileName">Saved game file path.</param>
        /// <returns></returns>
        public GameData LoadGame(string fileName)
        {
            DataSerialization dataSerialization = new DataSerialization();
            GameData data = dataSerialization.DeSerializeObject(fileName);
            return data;
        }
    }
}
