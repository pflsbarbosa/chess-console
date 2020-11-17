using chess_board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game
{
    class Horse:Piece
    {
        public Horse(Board board, Color color) : base(color, board)
        {

        }
        public override string ToString()
        {
            return "H";
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

            //1 step North and 2 to East 
            pos.DefiningValues(Position.Line - 1, Position.Column + 2);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;                                
            }
            //2 step North and 1 to East 
            pos.DefiningValues(Position.Line - 2, Position.Column + 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;                                
            }
            //1 step North and 2 to West 
            pos.DefiningValues(Position.Line - 1, Position.Column - 2);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;                
            }
            //2 step North and 1 to West 
            pos.DefiningValues(Position.Line - 2, Position.Column - 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;               
            }
            //1 Step South and 2 to East
            pos.DefiningValues(Position.Line + 1, Position.Column + 2);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;               
            }
            //2 Step South and 1 to East
            pos.DefiningValues(Position.Line + 2, Position.Column + 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;               
            }
            //1 Step South and 2 to West
            pos.DefiningValues(Position.Line + 1, Position.Column - 2);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;                
            }
            //2 Step South and 1 to West
            pos.DefiningValues(Position.Line + 2, Position.Column - 1);
            if (Board.validPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;              
            }

            return logicMatrix;
        }
    }
}
