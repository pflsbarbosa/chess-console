using System;
using chess_board;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;//only board move the pieces

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];//instantiate the matrix of pieces
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }

        public bool PieceExists(Position position)
        {
            validatePosition(position);
            return Piece(position) != null;
        }

        public void PuttingPiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new BoardException("There is already a piece in that position!");
            }
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
        
        public  Piece RemovingPieces(Position position)
        {
            
            if (Piece(position) == null)
            {
                return null;
            }

            Piece aux = Piece(position);
            
            //removing the piece from board
            aux.Position = null; 
            Pieces[position.Line, position.Column] = null;
            return aux;
        } 

        public bool validPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column >= Columns || position.Column < 0)
            {
                return false;
            }

            return true;
        }

        public void validatePosition(Position position)
        {
            if (!validPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
