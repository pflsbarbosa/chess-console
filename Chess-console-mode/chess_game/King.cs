using chess_board;


namespace chess_game
{
    class King : Piece
    {
        private ChessMatch Match;//King's Match

        public King (Board board, Color color, ChessMatch match) : base (color, board)
        {
            Match = match;
        }
        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
            //First: Check if the house is free (null) or not
            //Second: Check if the house has an opponent piece
        }

        private bool TestingTowerToCastling(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Tower && p.Color == Color && p.MovementsQuantity == 0;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] logicMatrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            //Above
            position.DefiningValues(Position.Line -1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position)) 
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //NorthEast
            position.DefiningValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //East (Right)
            position.DefiningValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //SouthEast 
            position.DefiningValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //South (Down)
            position.DefiningValues(Position.Line + 1 , Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //SouthWest
            position.DefiningValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //West (Left)
            position.DefiningValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //NorthWest
            position.DefiningValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }


            //#special Movement
            if (MovementsQuantity==0 && !Match.CheckMate)
            {
                //#Small Castling
                Position towerPosition = new Position(Position.Line, Position.Column + 3);
                if (TestingTowerToCastling(towerPosition))
                {
                    Position pos1 = new Position(Position.Line, Position.Column + 1);
                    Position pos2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.Piece(pos1) == null && Board.Piece(pos2) == null)
                    {
                        logicMatrix[Position.Line, Position.Column + 2] = true;
                    }
                }
                //#Great Castling
                Position towerPosition2 = new Position(Position.Line, Position.Column -4);
                if (TestingTowerToCastling(towerPosition2))
                {
                    Position pos1 = new Position(Position.Line, Position.Column - 1);
                    Position pos2 = new Position(Position.Line, Position.Column - 2);
                    Position pos3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(pos1) == null && Board.Piece(pos2) == null && Board.Piece(pos3) == null)
                    {
                        logicMatrix[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            
            return logicMatrix;
        }
    }
}
