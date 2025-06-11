using System;

namespace Tic_Tac
{
    public class TicTacToe
    {
        static char[] board = new char[9];
        static char human = 'X';
        static char computer = 'O';

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            InitializeBoard();
            PrintBoard();

            // Decide who goes first
            Console.WriteLine("Do you want to go first? (yes/no)");
            string input = Console.ReadLine();
            bool isHumanTurn = input.ToLower().StartsWith("y");

            while (true)
            {
                if (isHumanTurn)
                {
                    HumanMove();
                    if (CheckWin(human))
                    {
                        Console.WriteLine("You win!");
                        break;
                    }
                }
                else
                {
                    ComputerMove();
                    if (CheckWin(computer))
                    {
                        Console.WriteLine("Computer wins!");
                        break;
                    }
                }

                if (IsDraw())
                {
                    Console.WriteLine("It's a draw!");
                    break;
                }

                isHumanTurn = !isHumanTurn;
                PrintBoard();
            }

            PrintBoard(); // Final board state
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < board.Length; i++)
                board[i] = (i + 1).ToString()[0];
        }

        static void PrintBoard()
        {
            Console.WriteLine("\nCurrent state of the board:");
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("--+---+--");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
            Console.WriteLine("\n");
        }


        static void HumanMove()
        {
            while (true)
            {
                Console.WriteLine("Enter your move (1-9):");
                int move = Convert.ToInt32(Console.ReadLine()) - 1;
                if (move >= 0 && move < 9 && board[move] != human && board[move] != computer)
                {
                    board[move] = human;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move, try again.");
                }
            }
        }

        static void ComputerMove()
        {
            int bestScore = int.MinValue;
            int bestMove = 0;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != human && board[i] != computer)
                {
                    char current = board[i];
                    board[i] = computer;
                    int score = Minimax(board, 0, false);
                    board[i] = current;
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = i;
                    }
                }
            }
            board[bestMove] = computer;
        }

        static int Minimax(char[] board, int depth, bool isMaximizing)
        {
            if (CheckWin(computer))
                return 1;
            if (CheckWin(human))
                return -1;
            if (IsDraw())
                return 0;

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i] != human && board[i] != computer)
                    {
                        char current = board[i];
                        board[i] = computer;
                        int score = Minimax(board, depth + 1, false);
                        board[i] = current;
                        bestScore = Math.Max(score, bestScore);
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < board.Length; i++)
                {
                    if (board[i] != human && board[i] != computer)
                    {
                        char current = board[i];
                        board[i] = human;
                        int score = Minimax(board, depth + 1, true);
                        board[i] = current;
                        bestScore = Math.Min(score, bestScore);
                    }
                }
                return bestScore;
            }
        }

        static bool CheckWin(char player)
        {
            int[][] winConditions = new int[][]
            {
                new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 }
            };

            foreach (var condition in winConditions)
            {
                if (board[condition[0]] == player && board[condition[1]] == player && board[condition[2]] == player)
                {
                    return true;
                }
            }
            return false;
        }

        static bool IsDraw()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] != human && board[i] != computer)
                {
                    return false; // There's still at least one empty spot
                }
            }
            return !CheckWin(human) && !CheckWin(computer); // No empty spots and no winner means a draw
        }
    }
}

