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
        public Pawn(Board board, Color color) : base(color, board)
        {

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
                if (Board.validPosition(position) && Free(position))
                {
                    logicMatrix[position.Line, position.Column] = true;
                }
                //Above free 2steps
                position.DefiningValues(Position.Line + (d * 2), Position.Column);
                if (Board.validPosition(position) && Free(position) && MovementsQuantity == 0)
                {
                    logicMatrix[position.Line, position.Column] = true;
                }

                //NorthEast
                position.DefiningValues(Position.Line + d, Position.Column + 1);
                if (Board.validPosition(position) && ExistOneEnemy(position))
                {
                    logicMatrix[position.Line, position.Column] = true;
                }
              
                //NorthWest
                position.DefiningValues(Position.Line + d, Position.Column - 1);
                if (Board.validPosition(position) && ExistOneEnemy(position))
                {
                    logicMatrix[position.Line, position.Column] = true;
                }
            
            
            return logicMatrix;
        }

    }
}
