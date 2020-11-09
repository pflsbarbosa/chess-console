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
                    try
                    {
                        Console.Clear();
                        Screen.printingChessBoard(chessMatch.Board);
                        Console.WriteLine();
                        Console.WriteLine("Shift: " + chessMatch.Shift);
                        Console.WriteLine("Awaitting move: " + chessMatch.CurrentPlayer);

                        Console.Write("Source: ");
                        Position original = Screen.ReadingChessPosition().ToPositionMatrix();
                        chessMatch.ValidateTheOriginPosition(original);
                        

                        bool[,] possiblePositions = chessMatch.Board.Piece(original).PossibleMovements();

                        Console.Clear();
                        Screen.printingChessBoard(chessMatch.Board, possiblePositions);


                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadingChessPosition().ToPositionMatrix();
                        chessMatch.ValidateTheDestinyPosition(original, destiny);
                        chessMatch.PerformMove(original, destiny);
                    }
                    catch (BoardException e)
                    {

                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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
