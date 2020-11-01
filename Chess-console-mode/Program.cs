using System;
using chess_board;
using chess_game;

namespace Chess_console_mode
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            
            board.PuttingPieces(new Tower(board, Color.Black), new Position(0, 0));
            board.PuttingPieces(new Tower(board, Color.Black), new Position(1, 3));
            board.PuttingPieces(new King(board, Color.Black), new Position(2, 4));
            

            screen.printingChessBoard(board);
            Console.ReadKey();

        }
    }
}
