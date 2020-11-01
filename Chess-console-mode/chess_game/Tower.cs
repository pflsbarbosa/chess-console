﻿using chess_board;


namespace chess_game
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(color, board)
        {

        }
        public override string ToString()
        {
            return "T";
        }
    }
}