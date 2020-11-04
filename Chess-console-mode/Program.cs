using System;
using chess_board;
using chess_game;

namespace Chess_console_mode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*
                ChessPosition chessPosition = new ChessPosition('f', 7);
                Console.Write(chessPosition);
                Console.WriteLine(" -> "+chessPosition.ChessPositionConversion());
                */
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.Finished)
                {
                    Console.Clear();
                    Screen.printingChessBoard(chessMatch.Board);

                    Console.WriteLine();
                    Console.Write("Source: " );
                    Position source = Screen.ReadingChessPosition().ToPositionMatrix();

                    bool[,] possiblePositions = chessMatch.Board.Piece(source).PossibleMovements();

                    Console.Clear();
                    Screen.printingChessBoard(chessMatch.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadingChessPosition().ToPositionMatrix();

                    chessMatch.ExecutingMovement(source, destiny);
                }
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}
