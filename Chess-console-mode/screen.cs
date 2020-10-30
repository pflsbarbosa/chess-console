using System;
using chess_board;

namespace Chess_console_mode
{
    class screen
    {
        public static void printingChessBoard(Board board)
        {

            for (int i = 0; i < board.Lines; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.Piece(i, j) + " ");
                    }

                }
                Console.WriteLine();
            }

        }
    }
}
