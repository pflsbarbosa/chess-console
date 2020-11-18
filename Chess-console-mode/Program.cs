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
               
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintingChessMatch(chessMatch);

                        Console.WriteLine();
                        Console.Write("Source: ");
                        Position origin = Screen.ReadingChessPosition().ToPositionMatrix();
                        chessMatch.ValidateTheOriginPosition(origin);
                        

                        bool[,] possiblePositions = chessMatch.Board.Piece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintingChessBoard(chessMatch.Board, possiblePositions);


                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadingChessPosition().ToPositionMatrix();
                        chessMatch.ValidateTheDestinyPosition(origin, destiny);

                        chessMatch.PerformMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintingChessMatch(chessMatch);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
