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
        readonly public int[,] data;
        readonly public int[,] newData;

        /// <summary>
        /// Data of application.
        /// </summary>
        public GameData()
        {
            int column = UserInterface.GetValueInRange("Input amount of columns", 5, 200);
            int row = UserInterface.GetValueInRange("Input amount of rows", 5, 200);
            data = new int[row, column];
            newData = new int[row, column];
            FillDefault();
        }

        /// <summary>
        /// Fills gameboard with random alive cells.
        /// </summary>
        void FillDefault()
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
        /// Iterates to the next generation.
        /// </summary>
        public void Iterate()
        {
            for (int row = 0; row < data.GetLength(0); row++)
            {
                for (int column = 0; column < data.GetLength(1); column++)
                {
                    newData[row, column] = IsLiveCell(row, column) ? 1 : 0;
                }
            }
            TransferData();
        }

        /// <summary>
        /// Gets number of neighbors for given cell.
        /// </summary>
        /// <param name="actualRow">Row for cell in question.</param>
        /// <param name="actualColumn">Column for cell in question.</param>
        /// <returns>Returns number of neighbors.</returns>
        int GetCountOfNeighbors(int actualRow, int actualColumn)
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
        /// Checks if cell is alive next iteration.
        /// </summary>
        /// <param name="row">Row of cell in question</param>
        /// <param name="column">Column of cell in question</param>
        /// <returns>True or false cell in question is alive next iteration.</returns>
        bool IsLiveCell(int row, int column)
        {
            int neighbors = GetCountOfNeighbors(row,column);
            bool cellLive = data[row, column] == 1;
            if (neighbors == 3)
            {
                return true;
            }
            else if(neighbors == 2 && cellLive)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Assigns new iteration values to current iteration.
        /// </summary>
        public void TransferData()
        {
            for(int row = 0; row < data.GetLength(0); row++)
            {
                for(int column = 0; column < data.GetLength(1); column++)
                {
                    data[row, column] = newData[row, column];
                }
            }
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Play()
        {
            while (true)
            {
                Iterate();
                UserInterface.Print(data);
                Thread.Sleep(1000);
            }
        }
    }
}
