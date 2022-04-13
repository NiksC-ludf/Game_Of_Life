namespace GameOfLife;

public class Program
{
    static void Main()
    {
        void Print(int[,] args)
        {
            Console.WriteLine();// just for cosmetics
            Console.WriteLine("Your field:");
            for (int i = 0; i < args.GetLength(0); i++)
            {
                for (int j = 0; j < args.GetLength(1); j++)
                {
                    Console.Write(args[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine("Game of Life!");
        Console.WriteLine("Please input the amount of columns for your field: ");
        int columns = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please input the amount of rows for your field: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        int[,] data = new int[rows, columns];
        int num = 1;
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                data[i, j] = num;
                num++;
            }
        }
        Print(data);
    }
}
