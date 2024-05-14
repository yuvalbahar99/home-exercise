using System;

namespace _2048
{
    class Board
    {
        public const int BOARD_SIZE = 4;
        public Item[,] Data { get; protected set; }
        public Board()
        {
            Data = new Item[BOARD_SIZE, BOARD_SIZE];
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                for (int i = 0; i < BOARD_SIZE; i++)
                {
                    Data[i, j] = new Item();
                }
            }
            Add2or4inRandomPlace();
            Add2or4inRandomPlace();
        }
        public bool IsBoardFull()
        {
            bool isBoardFull = true;
            for (int j = 0; j < Board.BOARD_SIZE; j++)
            {
                for (int i = 0; i < Board.BOARD_SIZE; i++)
                {
                    if (IsEqualTo(i, j, 0))
                        isBoardFull = false;
                }
            }
            return isBoardFull;
        }
        public bool IsEqualTo(int x, int y, int value)
        {
            return (Data[x, y].Value == value);
        }
        public bool Add2or4inRandomPlace()
        {
            if (IsBoardFull())
                return false;
            int[] place = RandomPlace();
            while (!IsEqualTo(place[0], place[1], 0))
                place = RandomPlace();
            Data[place[0], place[1]].Value = RandomNumber2or4();
            return true;
        }

        public int RandomNumber2or4()
        {
            Random rnd = new Random();
            int number = rnd.Next(2, 5);
            while (number == 3)
                number = rnd.Next(2, 5);
            return number;
        }
        public int[] RandomPlace()
        {
            Random rnd = new Random();
            return new[] { rnd.Next(0, 4), rnd.Next(0, 4) };
        }
        public void FillSpot(int[] placeOnBoard, int number, bool isBlended)
        {
            Data[placeOnBoard[0], placeOnBoard[1]].Value = number;
            Data[placeOnBoard[0], placeOnBoard[1]].IsBlended = isBlended;
        }

        public int Move(Enums.Direction chosenDirection)
        {
            int points = 0;
            switch (chosenDirection)
            {
                case Enums.Direction.Up:
                    points = MoveUp();
                    break;
                case Enums.Direction.Down:
                    points = MoveDown();
                    break;
                case Enums.Direction.Left:
                    points = MoveLeft();
                    break;
                case Enums.Direction.Right:
                    points = MoveRight();
                    break;
            }
            UpdateBlendedToFalse();
            Add2or4inRandomPlace();
            return points;
        }
        public int[] FirstUpperValueSpot(int iStart, int jConst, int value, bool needsTobeNexTo)
        {
            for (int i = iStart; i < BOARD_SIZE; i++)
            {
                if (IsEqualTo(i , jConst, value))
                    return new[] { i, jConst };
                else if (needsTobeNexTo && !IsEqualTo(i, jConst, 0))
                    return null;
            }
            return null;
        }
        public int[] FirstLowerValueSpot(int iStart, int jConst, int value, bool needsTobeNexTo)
        {
            for (int i = iStart; i >= 0; i--)
            {
                if (IsEqualTo(i, jConst, value))
                    return new[] { i, jConst };
                else if (needsTobeNexTo && !IsEqualTo(i, jConst, 0))
                    return null;
            }
            return null;
        }
        public int[] FirstLeftValueSpot(int iConst, int jStart, int value, bool needsTobeNexTo)
        {
            for (int j = jStart; j < BOARD_SIZE; j++)
            {
                if (IsEqualTo(iConst, j, value))
                    return new[] { iConst, j };
                else if (needsTobeNexTo && !IsEqualTo(iConst, j, 0))
                    return null;
            }
            return null;
        }
        public int[] FirstRightValueSpot(int iConst, int jStart, int value, bool needsTobeNexTo)
        {
            for (int j = jStart; j >= 0; j--)
            {
                if (IsEqualTo(iConst, j, value))
                    return new[] { iConst, j };
                else if (needsTobeNexTo && !IsEqualTo(iConst, j, 0))
                    return null;
            }
            return null;
        }

        public int MoveUp()
        {
            int points = 0;
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                for (int i = 1; i < BOARD_SIZE; i++)
                {
                    if (!IsEqualTo(i, j, 0))
                    {
                        int[] sameValueSpot = FirstLowerValueSpot(i - 1, j, Data[i,j].Value, true);
                        if (sameValueSpot != null &&
                            !Data[sameValueSpot[0], sameValueSpot[1]].IsBlended)
                        {
                            points += Data[i, j].Value * 2;
                            FillSpot(sameValueSpot, Data[i, j].Value * 2, true);
                            FillSpot(new[] { i, j }, 0, false);
                        }
                        else
                        {
                            int[] emptySpot = FirstUpperValueSpot(0, j, 0, false);
                            if (emptySpot != null)
                            {
                                if (emptySpot[0] < i)
                                {
                                    FillSpot(emptySpot, Data[i, j].Value, false);
                                    FillSpot(new[] { i, j }, 0, false);
                                }
                            }
                        }
                    }
                }
            }
            return points;
        }
        public int MoveDown()
        {
            int points = 0; 
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                for (int i = BOARD_SIZE - 1; i >= 0; i--)
                {
                    if (!IsEqualTo(i, j, 0))
                    {
                        int[] sameValueSpot = FirstUpperValueSpot(i + 1, j, Data[i, j].Value, true);
                        if (sameValueSpot != null &&
                            !Data[sameValueSpot[0], sameValueSpot[1]].IsBlended)
                        {
                            points += Data[i, j].Value * 2;
                            FillSpot(sameValueSpot, Data[i, j].Value * 2, true);
                            FillSpot(new[] { i, j }, 0, false);
                        }
                        else
                        {
                            int[] emptySpot = FirstLowerValueSpot(BOARD_SIZE - 1, j, 0, false);
                            if (emptySpot != null)
                            {
                                if (emptySpot[0] > i)
                                {
                                    FillSpot(emptySpot, Data[i, j].Value, false);
                                    FillSpot(new[] { i, j }, 0, false);
                                }
                            }
                        }
                    }
                }
            }
            return points;
        }
        public int MoveLeft()
        {
            int points = 0;
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (!IsEqualTo(i, j, 0))
                    {
                        int[] sameValueSpot = FirstRightValueSpot(i, j - 1, Data[i, j].Value, true);
                        if (sameValueSpot != null &&
                            !Data[sameValueSpot[0], sameValueSpot[1]].IsBlended)
                        {
                            points += Data[i, j].Value * 2;
                            FillSpot(sameValueSpot, Data[i, j].Value * 2, true);
                            FillSpot(new[] { i, j }, 0, false);
                        }
                        else
                        {
                            int[] emptySpot = FirstLeftValueSpot(i, 0, 0, false);
                            if (emptySpot != null)
                            {
                                if (emptySpot[1] < j)
                                {
                                    FillSpot(emptySpot, Data[i, j].Value, false);
                                    FillSpot(new[] { i, j }, 0, false);
                                }
                            }
                        }
                    }
                }
            }
            return points;
        }
        public int MoveRight()
        {
            int points = 0;
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = BOARD_SIZE - 1; j >= 0; j--)
                {
                    if (!IsEqualTo(i, j, 0))
                    {
                        int[] sameValueSpot = FirstLeftValueSpot(i, j + 1, Data[i, j].Value, true);
                        if (sameValueSpot != null &&
                            !Data[sameValueSpot[0], sameValueSpot[1]].IsBlended)
                        {
                            points += Data[i, j].Value * 2;
                            FillSpot(sameValueSpot, Data[i, j].Value * 2, true);
                            FillSpot(new[] { i, j }, 0, false);
                        }
                        else
                        {
                            int[] emptySpot = FirstRightValueSpot(i, BOARD_SIZE - 1, 0, false);
                            if (emptySpot != null)
                            {
                                if (emptySpot[1] > j)
                                {
                                    FillSpot(emptySpot, Data[i, j].Value, false);
                                    FillSpot(new[] { i, j }, 0, false);
                                }
                            }
                        }
                    }
                }
            }
            return points;
        }
        public void UpdateBlendedToFalse()
        {
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    Data[i, j].IsBlended = false;
                }
            }
        }
    }
}
