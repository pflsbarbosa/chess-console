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
        public int MovmentsQuantity { get; protected set; }
        public Board Board { get; set; }

        public Piece() { }

        public Piece(Position position, Color color, int movmentsQuantity, Board board)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Board = board ?? throw new ArgumentNullException(nameof(board));
            Color = color;
            MovmentsQuantity = 0;
        }
    }
}
