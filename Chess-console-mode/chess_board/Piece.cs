using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_board
{
    class Piece
    {
        public Position Position { get; set; }        
        public Color Color { get; protected set; }
        public int MovementsQuantity { get; protected set; }
        public Board Board { get; set; }

        public Piece() { }

        public Piece(Color color, Board board)
        {
            Position = null;
            Board = board ?? throw new ArgumentNullException(nameof(board));
            Color = color;
            MovementsQuantity = 0;
        }
        public void incrementingQtyMovements()
        {
            MovementsQuantity++;
        }
    }
}
