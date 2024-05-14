using System;


namespace _2048
{
    class Game
    {
        public Board GameBoard { get; set; }
        public Enums.GameStatuses GameStatus { get; set; }
        public int Ponits { get; protected set; }
        public Game()
        {
            GameBoard = new Board();
            GameStatus = Enums.GameStatuses.Idle;
            Ponits = 0;
        }
        public void Move(Enums.Direction chosenDirection)
        {
            if (GameStatus != Enums.GameStatuses.Lose)
            {
                int points = GameBoard.Move(chosenDirection);
                Ponits += points;
                if (points >= 2048)
                    GameStatus = Enums.GameStatuses.Win;
                if (GameBoard.IsBoardFull() &&
                    GameStatus == Enums.GameStatuses.Idle && 
                    !CanStillWin())
                    GameStatus = Enums.GameStatuses.Lose;
            }
        }
        public bool CanStillWin()
        {
            for (int i = 1; i < Board.BOARD_SIZE; i++)
            {
                for (int j = 1; j < Board.BOARD_SIZE; j++)
                {
                    if (GameBoard.Data[i, j].Value == GameBoard.Data[i - 1, j].Value ||
                        GameBoard.Data[i, j].Value == GameBoard.Data[i, j - 1].Value)
                        return true;
                }
            }
            for (int i = 0; i < Board.BOARD_SIZE - 1; i++)
                if (GameBoard.Data[i, 0].Value == GameBoard.Data[i + 1, 0].Value)
                    return true;
            for (int j = 0; j < Board.BOARD_SIZE - 1; j++)
                if (GameBoard.Data[0, j].Value == GameBoard.Data[0, j + 1].Value)
                    return true;
            return false;
        }
    }
}
