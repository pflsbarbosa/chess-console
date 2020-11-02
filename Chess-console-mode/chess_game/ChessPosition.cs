using chess_board;

namespace chess_game
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Position ToPositionMatrix()
        {
            return new Position(8 - Line, Column - 'a' );
            //'a' = 97 (ASCII decimal value) 
            //Column = 100

        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
