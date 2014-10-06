
namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private class Player
        {
            public string Name { get; private set; }

            public int Points { get; private set; }

            public Player(string име, int points)
            {
                this.Name = име;
                this.Points = points;
            }
        }

        private static void Main()
        {
            string command;
            char[,] board = CreatBoard();
            char[,] bombs = PutBombs();
            int counter = 0;
            bool boom = false;
            var players = new List<Player>(6);
            int row = 0;
            int column = 0;
            bool flag = true;
            const int Max = 35;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine("Let's to play Minesweeper. Try to find a mine-free fields. Good luck!");
                    Console.WriteLine();
                    Console.WriteLine("Commands:");
                    Console.WriteLine("\"top\" - show rating");
                    Console.WriteLine("\"restart\" - start new game");
                    Console.WriteLine("\"exit\" - exit of game");

                    Dumpp(board);
                    flag = false;
                }

                Console.Write("Enter row and column: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out column)
                        && row <= board.GetLength(0) && column <= board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        DisplayRating(players);
                        break;
                    case "restart":
                        board = CreatBoard();
                        bombs = PutBombs();
                        Dumpp(board);
                        boom = false;
                        flag = false;
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                SetPlaeyrTurn(board, bombs, row, column);
                                counter++;
                            }

                            if (Max == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                Dumpp(board);
                            }
                        }
                        else
                        {
                            boom = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\n\n");
                        break;
                }

                if (boom)
                {
                    Dumpp(bombs);
                    Console.Write("\n Nice game! Your score is {0} " + "\nWrite your nickname: ", counter);
                    string nickname = Console.ReadLine();
                    var t = new Player(nickname, counter);
                    if (players.Count < 5)
                    {
                        players.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < t.Points)
                            {
                                players.Insert(i, t);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((r1, r2) => r2.Name.CompareTo(r1.Name));
                    players.Sort((r1, r2) => r2.Points.CompareTo(r1.Points));
                    DisplayRating(players);

                    board = CreatBoard();
                    bombs = PutBombs();
                    counter = 0;
                    boom = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nBravo! You win!");
                    Dumpp(bombs);
                    Console.WriteLine("Write your nickname: ");
                    string nickname = Console.ReadLine();
                    var points = new Player(nickname, counter);
                    players.Add(points);
                    DisplayRating(players);
                    board = CreatBoard();
                    bombs = PutBombs();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("\nGood bye!");
            Console.Read();
        }

        private static void DisplayRating(List<Player> players)
        {
            Console.WriteLine("\nPoints: ");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No players\n");
            }
        }

        private static void SetPlaeyrTurn(char[,] board, char[,] bombs, int row, int column)
        {
            char bombsCount = CalculateBombsCount(bombs, row, column);
            bombs[row, column] = bombsCount;
            board[row, column] = bombsCount;
        }

        private static void Dumpp(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatBoard()
        {
            const int BoardRows = 5;
            const int BoardColumns = 10;
            var board = new char[BoardRows, BoardColumns];
            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PutBombs()
        {
            const int Rows = 5;
            const int Cols = 10;
            var board = new char[Rows, Cols];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    board[i, j] = '-';
                }
            }

            var bombsPosition = new List<int>();
            while (bombsPosition.Count < 15)
            {
                var random = new Random();
                int randomNumber = random.Next(50);
                if (!bombsPosition.Contains(randomNumber))
                {
                    bombsPosition.Add(randomNumber);
                }
            }

            foreach (int position in bombsPosition)
            {
                int col = position / Cols;
                int row = position % Cols;
                if (row == 0 && position != 0)
                {
                    col--;
                    row = Cols;
                }
                else
                {
                    row++;
                }

                board[col, row - 1] = '*';
            }

            return board;
        }

        private static char CalculateBombsCount(char[,] board, int row, int col)
        {
            int counter = 0;
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            if (row - 1 >= 0)
            {
                if (board[row - 1, col] == '*')
                {
                    counter++;
                }
            }

            if (row + 1 < rows)
            {
                if (board[row + 1, col] == '*')
                {
                    counter++;
                }
            }

            if (col - 1 >= 0)
            {
                if (board[row, col - 1] == '*')
                {
                    counter++;
                }
            }

            if (col + 1 < cols)
            {
                if (board[row, col + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (board[row - 1, col - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (board[row - 1, col + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (board[row + 1, col - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (board[row + 1, col + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }
    }
}