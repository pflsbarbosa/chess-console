using chess_board;


namespace chess_game
{
    class King : Piece
    {
        public King (Board board, Color color) : base (color, board)
        {

        }
        public override string ToString()
        {
            return "R";
        }
    }
}
