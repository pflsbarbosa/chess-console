using chess_board;


namespace chess_game
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(color, board)
        {

        }
        public override string ToString()
        {
            return "T";
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
            Position pos = new Position(0, 0);

            //Above
            pos.DefiningValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefiningValues(pos.Line - 1, pos.Column);
            }
            //South (Down)
            pos.DefiningValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefiningValues(pos.Line + 1, pos.Column);
            }
            //East (Right)
            pos.DefiningValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefiningValues(pos.Line, pos.Column + 1);
            }

            //West (Left)
            pos.DefiningValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                logicMatrix[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.DefiningValues(pos.Line, pos.Column - 1);
            }

            return logicMatrix;
        }
    }
}
