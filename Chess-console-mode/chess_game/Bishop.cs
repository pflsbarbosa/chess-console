using chess_board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game
{
    class Bishop: Piece
    {
        public Bishop(Board board, Color color) : base(color, board)
        {

        }
        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
            //First: Check if the house is free (null) or not
            //Second: Check if the house has an opponent piece
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] logicMatrix = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //NorthEast 
            pos.DefiningValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefiningValues(pos.Line - 1, pos.Column + 1);
            }
            //NorthWest 
            pos.DefiningValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefiningValues(pos.Line - 1, pos.Column - 1);
            }
            //SouthEast
            pos.DefiningValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefiningValues(pos.Line + 1, pos.Column + 1);
            }
            //SouthWest
            pos.DefiningValues(Position.Line + 1, Position.Column -1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefiningValues(pos.Line + 1, pos.Column - 1);
            }
           

            return logicMatrix;
        }
    }
}
