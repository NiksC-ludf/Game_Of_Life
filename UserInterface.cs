using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// User interraction of the application.
    /// </summary>
    public class UserInterface
    {
        private const string notNumericMessage = "Please input numeric value.";
        private const string pressAnyKeyMessage = "Press any key to continiue.";
        private const string notInRangeMessage = "The value is not within range.";

        /// <summary>
        /// Gets numeric input from the user.
        /// </summary>
        /// <param name="prompt">Text to display for the user.</param>
        /// <returns>Returns user input as int value.</returns>
        private int GetNumericInput(string prompt)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine(prompt);
                string value = Console.ReadLine();
                if (int.TryParse(value, out int result))
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

        /// <summary>
        /// Gets user input in the specified range.
        /// </summary>
        /// <param name="prompt">Text to display for the user.</param>
        /// <param name="minValue">Minimal acceptable value.</param>
        /// <param name="maxValue">Maximal acceptable value.</param>
        /// <returns>Returns user input within the specified range.</returns>
        public int GetValueInRange(string prompt, int minValue, int maxValue)
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

        /// <summary>
        /// Prints game board to the console.
        /// </summary>
        /// <param name="args">Array containing the game board.</param>
        public void Print(int [,] args)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < args.GetLength(0); i++)
            {
                for (int j = 0; j < args.GetLength(1); j++)
                {
                    Console.Write(args[i, j] == 1 ? "@" : ".");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
