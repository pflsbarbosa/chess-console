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

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
            //First: Check if the house is free (null) or not
            //Second: Check if the house has an opponent piece
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] logicMatrix = new bool[Board.Lines, Board.Columns];
            Position position = new Position(0, 0);

            //Above
            position.DefiningValues(Position.Line -1, Position.Column);
            if (Board.validPosition(position) && CanMove(position)) 
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //NorthEast
            position.DefiningValues(Position.Line - 1, Position.Column + 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //East (Right)
            position.DefiningValues(Position.Line, Position.Column + 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //SouthEast 
            position.DefiningValues(Position.Line + 1, Position.Column + 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //South (Down)
            position.DefiningValues(Position.Line + 1 , Position.Column);
            if (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //SouthWest
            position.DefiningValues(Position.Line + 1, Position.Column - 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //West (Left)
            position.DefiningValues(Position.Line, Position.Column - 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            //NorthWest
            position.DefiningValues(Position.Line - 1, Position.Column - 1);
            if (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
            }
            return logicMatrix;
        }
    }
}
