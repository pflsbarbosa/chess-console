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
            Position position = new Position(0, 0);

            //Above
            position.DefiningValues(Position.Line - 1, Position.Column);
            while (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line - 1;//Taking the opponente position 
            }
            //South (Down)
            position.DefiningValues(Position.Line + 1, Position.Column);
            while (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Line = position.Line + 1;//Taking the opponente position 
            }
            //East (Right)
            position.DefiningValues(Position.Line, Position.Column + 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column + 1;//Taking the opponente position 
            }
            
            //West (Left)
            position.DefiningValues(Position.Line, Position.Column - 1);
            while (Board.validPosition(position) && CanMove(position))
            {
                logicMatrix[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column - 1;//Taking the opponente position 
            }

            return logicMatrix;
        }
    }
}
