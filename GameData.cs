using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameData
    {
        readonly public int[,] data;
        readonly public int[,] newData;
        public GameData()
        {
            int column = UserInterface.GetValueInRange("Input amount of columns", 5, 200);
            int row = UserInterface.GetValueInRange("Input amount of rows", 5, 200);
            data = new int[column, row];
            newData = new int[column, row];
            FillDefault();
        }

        void FillDefault()
        {
            Random random = new Random();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j] = random.Next(0,6) == 0 ? 1 : 0;
                }
            }
        }
        public void Iterate()
        {
            for (int row = 0; row < data.GetLength(0); row++)
            {
                for (int column = 0; column < data.GetLength(1); column++)
                {
                    newData[row, column] = GetLiveCell(row, column);
                }
            }

            TransferData();
        }

        int GetCountOfNeighbors(int row, int column)
        {

        }
        bool GetLiveCell(int row, int column)
        {
            int neighbors = GetCountOfNeighbors(row,column);

        }

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
    }
}
