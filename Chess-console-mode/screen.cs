using System;
using System.Collections.Generic;
using chess_board;
using chess_game;

namespace Chess_console_mode
{
    class Screen
    {
        public static void printingChessBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    PrintingPiece(board.Piece(i, j));                                      
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
        }
        public static void printingChessBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBakgroundColor = Console.BackgroundColor;
            ConsoleColor bakgroundColorChanged = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i,j] == true)
                    {
                        Console.BackgroundColor = bakgroundColorChanged;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBakgroundColor;
                    }
                    PrintingPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBakgroundColor;
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
        }
        public static ChessPosition ReadingChessPosition()
        {
            string s = Console.ReadLine();
            char column = char.Parse(s.Substring(0, 1));
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintingPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
