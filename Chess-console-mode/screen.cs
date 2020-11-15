using System;
using System.Collections.Generic;
using chess_board;
using chess_game;

namespace Chess_console_mode
{
    class Screen
    {
        public static void PrintingChessMatch(ChessMatch chessMatch)
        {
            Screen.printingChessBoard(chessMatch.Board);
            Console.WriteLine();
            PrintingCapturedPieces(chessMatch);         
            Console.WriteLine();
            Console.WriteLine("Shift: " + chessMatch.Shift);
            Console.WriteLine("Awaitting move: " + chessMatch.CurrentPlayer);
            if (chessMatch.CheckMate)
            {
                Console.WriteLine("YOU ARE IN CHECK MATE!");
            }
            Console.WriteLine();
        }
        public  static void PrintingCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine();
            Console.WriteLine("Captured pieces: ");
            Console.Write("Whites:");
            PrintingSet(chessMatch.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Blacks:");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintingSet(chessMatch.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        public static void PrintingSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set)
            {
                Console.Write(x + " ");
            }

            Console.Write("]");
        }
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
