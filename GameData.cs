using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Data of application.
    /// </summary>
    public class GameData
    {
        public int[,] data;
        private const string inputColumnMessage = "Input amount of columns.";
        private const string inputRowMessage = "Input amount of rows.";
        UserInterface userInterface = new UserInterface();

        /// <summary>
        /// Data of application.
        /// </summary>
        public GameData()
        {
            int column = userInterface.GetValueInRange(inputColumnMessage, 5, 200);
            int row = userInterface.GetValueInRange(inputRowMessage, 5, 200);
            data = new int[row, column];
            SetRandomFirstGen();
        }

        /// <summary>
        /// Fills gameboard with random alive cells for the first generation.
        /// </summary>
        private void SetRandomFirstGen()
        {
            Random random = new Random();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = random.Next(0, 4) == 0 ? 1 : 0;
                }
            }
        }
        
        /// <summary>
        /// Advances game board by one generation.
        /// </summary>
        private void GetNewGeneration()
        {
            int[,] newData = new int[data.GetLength(0), data.GetLength(1)];
            for (int row = 0; row < data.GetLength(0); row++)
            {
                for (int column = 0; column < data.GetLength(1); column++)
                {
                    newData[row, column] = HasCellSurvived(row, column) ? 1 : 0;
                }
            }
            Array.Copy(newData, 0, data, 0, newData.Length);
        }

        /// <summary>
        /// Gets number of neighbors for given cell.
        /// </summary>
        /// <param name="actualRow">Row for cell in question.</param>
        /// <param name="actualColumn">Column for cell in question.</param>
        /// <returns>Returns number of neighbors.</returns>
        private int GetCountOfNeighbors(int actualRow, int actualColumn)
        {
            int count = 0;
            int previousRow = actualRow - 1 < 0 ? data.GetLength(0) - 1 : actualRow - 1;
            int nextRow = actualRow + 1 > data.GetLength(0) - 1 ? 0 : actualRow + 1;
            int previousColumn = actualColumn - 1 < 0 ? data.GetLength(1) - 1 : actualColumn - 1;
            int nextColumn = actualColumn + 1 > data.GetLength(1) - 1 ? 0 : actualColumn + 1;

            count = data[previousRow, previousColumn];
            count += data[previousRow, actualColumn];
            count += data[previousRow, nextColumn];
            count += data[actualRow, previousColumn];
            count += data[actualRow, nextColumn];
            count += data[nextRow, previousColumn];
            count += data[nextRow, actualColumn];
            count += data[nextRow, nextColumn];

            return count;
        }

        /// <summary>
        /// Checks if cell will be alive next generation.
        /// </summary>
        /// <param name="row">Row of cell in question</param>
        /// <param name="column">Column of cell in question</param>
        /// <returns>True or false cell in question is alive next generation.</returns>
        private bool HasCellSurvived(int row, int column)
        {
            int neighbors = GetCountOfNeighbors(row,column);
            bool cellAlive = data[row, column] == 1;
            if (neighbors == 3)
            {
                return true;
            }
            else if(neighbors == 2 && cellAlive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Play()
        {
            while (true)
            {
                GetNewGeneration();
                userInterface.Print(data);
                Thread.Sleep(1000);
            }
        }
    }
}
