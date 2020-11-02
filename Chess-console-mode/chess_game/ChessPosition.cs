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

        public Position ChessPositionConversion()
        {
            return new Position(8 - Line, Column - 'a');
           
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
