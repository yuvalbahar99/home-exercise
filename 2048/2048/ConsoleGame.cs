using System;
using System.Collections.Generic;

namespace _2048
{
    class ConsoleGame
    {
        string[] DIRECTIONS = { "u", "d", "l", "r" };
        Dictionary<int, ConsoleColor> NUMBER_COLOR = new Dictionary<int, ConsoleColor>
            {
                { 0, ConsoleColor.White },
                { 2, ConsoleColor.Blue },
                { 4, ConsoleColor.Cyan },
                { 8, ConsoleColor.Green },
                { 16, ConsoleColor.DarkYellow  },
                { 32, ConsoleColor.Yellow },
                { 64, ConsoleColor.Red },
                { 128, ConsoleColor.DarkRed },
                { 256, ConsoleColor.Magenta },
                { 512, ConsoleColor.DarkMagenta },
                { 1024, ConsoleColor.Gray  },
                { 2048, ConsoleColor.DarkGray }
            };
        public Game newGame;
        public ConsoleGame()
        {
            newGame = new Game();
        }
        public int numberLength(int number)
        {
            if (number == 0)
                return 1;
            return (int)(Math.Log10(number) + 1);
        }
        public void PrintBoard()
        {
            for (int j = 0; j < Board.BOARD_SIZE; j++)
            {
                for (int i = 0; i < Board.BOARD_SIZE; i++)
                {
                    int numberToPrint = newGame.GameBoard.Data[j, i].Value;
                    SetColor(numberToPrint);
                    Console.Write($"{numberToPrint}" +
                        $"{new String(' ', 5 - numberLength(numberToPrint))}");
                    ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------");
        }
        public Enums.Direction ChooseDirection()
        {
            Console.Write("Enter Input (u/d/l/r): ");
            string direction = Console.ReadLine();
            while (!ValidDirection(direction))
            {
                Console.Write("Enter Valid Input (u/d/l/r): ");
                direction = Console.ReadLine();
            }
            switch (direction)
            {
                case "u":
                    return Enums.Direction.Up;
                case "d":
                    return Enums.Direction.Down;
                case "l":
                    return Enums.Direction.Left;
                default:
                    return Enums.Direction.Right;
            }
        }
        public bool ValidDirection(string direction)
        {
            for (int i = 0; i < DIRECTIONS.Length; i++)
            {
                if (DIRECTIONS[i] == direction)
                    return true;
            }
            return false;
        } 
        public void PrintGameStatus()
        {
            if (newGame.GameStatus == Enums.GameStatuses.Win)
                Console.WriteLine("Winner !!!");
            else if (newGame.GameStatus == Enums.GameStatuses.Lose)
                Console.WriteLine("Loser :(");
            else
                Console.WriteLine("Not Yet A Victory..");
        }
        public void PrintPoints()
        {
            Console.WriteLine($"Total Points: {newGame.Ponits}");
        }
        public void SetColor(int number)
        {
            Console.ForegroundColor = NUMBER_COLOR[number];
        }
        public void ResetColor()
        {
            Console.ResetColor();
        }
        public void RunGame()
        {
            PrintBoard();
            while (newGame.GameStatus != Enums.GameStatuses.Lose)
            {
                newGame.Move(ChooseDirection());
                PrintBoard();
                PrintGameStatus();
                PrintPoints();
            }
        }
    }
}
