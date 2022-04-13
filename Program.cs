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
            Console.WriteLine();
        }
        void FillDefault(int[,] args)
        {
            int num = 1;
            for (int i = 0; i < args.GetLength(0); i++)
            {
                for (int j = 0; j < args.GetLength(1); j++)
                {
                    args[i, j] = num;
                    num++;
                }
            }
        }
        void MarkAlive(int[,] args, int[] nums)
        {
            int num = 0;
            int max = nums.GetLength(0);
            for(int i = 0; i < args.GetLength(0); i++)
            {
                for( int j = 0; j < args.GetLength(1); j++)
                {
                    if(args[i, j] == nums[num])
                    {
                        args[i, j] = 1;
                        if(!(num == max || num+1 == max))
                        {
                            num++;
                        }
                    }
                    else
                    {
                        args[i, j] = 0;
                    }
                }
            }
        }
        Console.WriteLine("Game of Life!");
        Console.WriteLine("Please input the amount of columns for your field: ");
        int columns = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please input the amount of rows for your field: ");
        int rows = Convert.ToInt32(Console.ReadLine());

        int[,] data = new int[rows, columns];
        FillDefault(data);
        Print(data);

        Console.WriteLine("How many alive cells would you like?"); // Maybe would be better to use default size rows*columns
        int InputSize = Convert.ToInt32(Console.ReadLine());
        int[] input = new int[InputSize];
        Console.WriteLine("Input the numbers where you want alive cells:");
        for (int i = 0; i < InputSize; i++)
        {
            input[i] = Convert.ToInt32(Console.ReadLine());
        }
        Array.Sort(input);
        MarkAlive(data, input);
        Print(data);
    }
}
