using System;

namespace chess_board
{
    abstract class Piece
    {
        public Position Position { get; set; }        
        public Color Color { get; protected set; }
        public int MovementsQuantity { get; protected set; }
        public Board Board { get; set; }

       
        public Piece(Color color, Board board)
        {
            Position = null;
            Board = board ?? throw new ArgumentNullException(nameof(board));
            Color = color;
            MovementsQuantity = 0;
        }
                
        public void IncrementingQtyMovements()
        {
            MovementsQuantity++;
        }
        public void DecrementingQtyMovements()
        {
            MovementsQuantity--;
        }
        public bool ThereArePossibleMovements()
        {
            bool[,] logicMatrix = PossibleMovements();
            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (logicMatrix[i,j])
                    {
                        return true;
                    }
                }
            }
            //if there isn't any possible movements return false
            return false;
        }

        public bool PossibleMovement(Position position)//to read better
        {
            return PossibleMovements()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMovements();
    }
}
