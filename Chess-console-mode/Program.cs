using System;
using chess_board;

namespace Chess_console_mode
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            
            screen.printingChessBoard(board);
            Console.ReadKey();

        }
    }
}
