using System.Net.Sockets;

namespace Tic_Tac_Toe
{
    class TicTacToe
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char currentPlayer = 'X';
        static bool isGameFinished = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");

            while (!isGameFinished)
            {
                DrawBoard();
                int move = GetPlayerMove();
                if (IsValidMove(move))
                {
                    board[move - 1] = currentPlayer;
                    if (CheckForWin())
                    {
                        DrawBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        isGameFinished = true;
                    }
                    else if (CheckForDraw())
                    {
                        DrawBoard();
                        Console.WriteLine("It's a draw!");
                        isGameFinished = true;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move! Please try again.");
                }
            }
        }

        static void DrawBoard()
        {
            Console.Clear(); // Clear the console before drawing the board
            Console.WriteLine("Tic Tac Toe\n");
            Console.WriteLine($" {GetCellSymbol(6)} | {GetCellSymbol(7)} | {GetCellSymbol(8)} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {GetCellSymbol(3)} | {GetCellSymbol(4)} | {GetCellSymbol(5)} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {GetCellSymbol(0)} | {GetCellSymbol(1)} | {GetCellSymbol(2)} ");
        }

        static char GetCellSymbol(int position)
        {
            return (board[position] == 'X' || board[position] == 'O') ? board[position] : ' ';
        }

        static int GetPlayerMove()
        {
            Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
            int move;
            while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > 9 || !IsValidMove(move))
            {
                Console.Write("Invalid input! Enter a number between 1 and 9 that is not already taken: ");
            }
            return move;
        }

        static bool IsValidMove(int move)
        {
            return board[move - 1] != 'X' && board[move - 1] != 'O';
        }

        static bool CheckForWin()
        {
            return (board[0] == board[1] && board[1] == board[2]) ||
                   (board[3] == board[4] && board[4] == board[5]) ||
                   (board[6] == board[7] && board[7] == board[8]) ||
                   (board[0] == board[3] && board[3] == board[6]) ||
                   (board[1] == board[4] && board[4] == board[7]) ||
                   (board[2] == board[5] && board[5] == board[8]) ||
                   (board[0] == board[4] && board[4] == board[8]) ||
                   (board[2] == board[4] && board[4] == board[6]);
        }

        static bool CheckForDraw()
        {
            foreach (char cell in board)
            {
                if (cell != 'X' && cell != 'O')
                    return false;
            }
            return true;
        }
    }

}
