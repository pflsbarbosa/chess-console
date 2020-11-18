using chess_board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game
{
    class Pawn : Piece
    {

        private ChessMatch Match;

        public Pawn(Board board, Color color, ChessMatch match) : base(color, board)
        {
            Match = match;
        }
        public override string ToString()
        {
            return "P";
        }

        private bool ExistOneEnemy(Position position)
        {
            Piece p = Board.Piece(position);
            return p != null && p.Color != Color;
            // Check if the house is occupy (not null) and Check if the house has an opponent piece
        }

        private bool Free(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] logicMatrix = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            //Ternary operator: if white move to up (-1) and if black move to down (+1)
            int d = Color == Color.White ? -1 : 1;

            //Above free
            position.DefiningValues(Position.Line + d, Position.Column);
            if (Board.ValidPosition(position) && Free(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //Above free 2steps
            position.DefiningValues(Position.Line + (d * 2), Position.Column);
            Position p2 = new Position(position.Line + d, position.Column);
            if (Board.ValidPosition(p2) && Free(p2) && Board.ValidPosition(position) && Free(position) && MovementsQuantity == 0)
            {
                logicMatrix[position.Line, position.Column] = true;
            }

            //NorthEast
            position.DefiningValues(Position.Line + d, Position.Column + 1);
            if (Board.ValidPosition(position) && ExistOneEnemy(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }

            //NorthWest
            position.DefiningValues(Position.Line + d, Position.Column - 1);
            if (Board.ValidPosition(position) && ExistOneEnemy(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }

            //#Special movement: En Passant
            int y = Color == Color.White ? 3 : 4;
            if (position.Line == y)
            {
                Position left = new Position(position.Line, position.Column - 1);
                if (Board.ValidPosition(left) && ExistOneEnemy(left) && Board.Piece(left) == Match.VulnerableEnPassant)
                {
                    logicMatrix[left.Line + d, left.Column] = true;
                }
                Position right = new Position(position.Line, position.Column + 1);
                if (Board.ValidPosition(right) && ExistOneEnemy(right) && Board.Piece(right) == Match.VulnerableEnPassant)
                {
                    logicMatrix[right.Line + d, right.Column] = true;
                }
            }

            return logicMatrix;
        }

    }
}
