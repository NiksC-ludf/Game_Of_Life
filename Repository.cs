using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Container class for all text messages.
    /// </summary>
    public static class Repository
    {
        public const string notNumericMessage = "Please input numeric value.";
        public const string pressAnyKeyMessage = "Press any key to continiue.";
        public const string notInRangeMessage = "The value is not within range.";
        public const string welcomeMessage = "Welcome to game of life!";
        public const string instructionsHeader = "Instructions:";
        public const string instructionOne = "1. Enter 1, to start a new game with a random game board.";
        public const string instructionTwo = "2. Enter 2, to load previous game and continiue with that.";
        public const string failedToSerializeMessage = "Failed to serialize. Reason: ";
        public const string failedToDeserializeMessage = "Failed to deserialize.Reason: ";
        public const string inputColumnMessage = "Input amount of columns.";
        public const string inputRowMessage = "Input amount of rows.";
        public const string aliveCellMessage = "Amount of alive cells: ";
        public const string iterationCounterMessage = "Current iteration: ";
        public const string filePath = @"C:\Users\niks.cibulis\source\repos\Game_of_Life\GameData.txt";
        public const string choice = "Input your choice:";
        public const string exitOrSaveMessage = "Press 'S' to save current iteration to file.\nPress 'Z' to exit application.";
        public const int minRowCount = 5;
        public const int maxRowCount = 200;
        public const int minColumnCount = 5;
        public const int maxColumnCount = 200;
    }

    public enum MenuOptions
    {
        newRandomGame = 1,
        loadSavedGame = 2
    }
}
