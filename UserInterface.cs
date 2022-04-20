using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static public class UserInterface
    {
        private const string notNumericMessage = "Please input numeric value.";
        private const string pressAnyKeyMessage = "Press any key to continiue.";
        private static string notInRangeMessage = "The value is not within range.";

        public static int GetNumericInput(string prompt)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine(prompt);
                string? value = Console.ReadLine();
                bool success = int.TryParse(value, out int result);
                if(success)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine(notNumericMessage);
                    Console.WriteLine(pressAnyKeyMessage);
                    Console.ReadKey();
                }
            }
        }
        public static int GetValueInRange(string prompt, int minValue, int maxValue)
        {
            while(true)
            {
                Console.Clear();
                int number = GetNumericInput(prompt);
                if (number >= minValue && number <= maxValue)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine(notInRangeMessage);
                    Console.WriteLine(pressAnyKeyMessage);
                    Console.ReadKey();
                }
            }
        }
        public static void Print(int [,] args)
        {
            for(int i = 0; i < args.GetLength(0); i++)
            {
                for(int j = 0; j < args.GetLength(1); j++)
                {
                    Console.Write(args[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
