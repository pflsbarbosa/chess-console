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
                Board board = new Board(8, 8);

                board.PuttingPieces(new Tower(board, Color.Black), new Position(0, 0));
                board.PuttingPieces(new Tower(board, Color.Black), new Position(1, 3));
                board.PuttingPieces(new King(board, Color.Black), new Position(0, 2));


                screen.printingChessBoard(board);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}
