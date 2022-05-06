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
    [Serializable]
    public class GameData
    {
        public int[,] gameField;
        public int countOfIteration;
        public int countOfAliveCells;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GameData() { }

        /// <summary>
        /// Data of application.
        /// </summary>
        public GameData(int row, int column)
        {
            countOfIteration = 0;
            countOfAliveCells = 0;
            gameField = new int[row, column];
            SetRandomFirstGeneration();
        }

        /// <summary>
        /// Fills gameboard with random alive cells for the first generation.
        /// </summary>
        private void SetRandomFirstGeneration()
        {
            Random random = new Random();
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    gameField[i, j] = random.Next(0, 4) == 0 ? 1 : 0;
                }
            }
        }
        
        /// <summary>
        /// Advances game board by one generation.
        /// </summary>
        public void GetNewGeneration()
        {
            int[,] newGameField = new int[gameField.GetLength(0), gameField.GetLength(1)];
            countOfAliveCells = 0;
            for (int row = 0; row < gameField.GetLength(0); row++)
            {
                for (int column = 0; column < gameField.GetLength(1); column++)
                {
                    newGameField[row, column] = HasCellSurvived(row, column) ? 1 : 0;
                    countOfAliveCells += newGameField[row, column];
                }
            }

            Array.Copy(newGameField, gameField, newGameField.Length);
            countOfIteration++;
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
            int previousRow = actualRow - 1 < 0 ? gameField.GetLength(0) - 1 : actualRow - 1;
            int nextRow = actualRow + 1 > gameField.GetLength(0) - 1 ? 0 : actualRow + 1;
            int previousColumn = actualColumn - 1 < 0 ? gameField.GetLength(1) - 1 : actualColumn - 1;
            int nextColumn = actualColumn + 1 > gameField.GetLength(1) - 1 ? 0 : actualColumn + 1;

            count = gameField[previousRow, previousColumn];
            count += gameField[previousRow, actualColumn];
            count += gameField[previousRow, nextColumn];
            count += gameField[actualRow, previousColumn];
            count += gameField[actualRow, nextColumn];
            count += gameField[nextRow, previousColumn];
            count += gameField[nextRow, actualColumn];
            count += gameField[nextRow, nextColumn];

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
            bool cellAlive = gameField[row, column] == 1;

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
    }
}
