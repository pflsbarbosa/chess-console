﻿

namespace chess_board
{
    class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position() { }

        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }
        public void  DefiningValues(int line, int column)
        {
            Line = line;
            Column = column;
        }
        public override string ToString()
        {
            return Line
                + ","
                + Column;
        }
    }
}
