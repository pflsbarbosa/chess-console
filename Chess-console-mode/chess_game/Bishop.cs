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
            Position position = new Position(0, 0);

            //NorthEast 
            position.DefiningValues(Position.Line - 1, Position.Column + 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line - 1;//Taking the opponente position 
            }
            //NorthWest 
            position.DefiningValues(Position.Line - 1, Position.Column - 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line - 1;//Taking the opponente position 
            }
            //SouthEast
            position.DefiningValues(Position.Line + 1, Position.Column + 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line + 1;//Taking the opponente position 
            }
            //SouthWest
            position.DefiningValues(Position.Line + 1, Position.Column -1);
            while (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line + 1;//Taking the opponente position 
            }
           

            return logicMatrix;
        }
    }
}
