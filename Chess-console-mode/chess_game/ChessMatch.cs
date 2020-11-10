using System.Collections.Generic;
using chess_board;

namespace chess_game
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captureds;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;//Initating with white Pieces (chess rule)
            Finished = false;
            Pieces = new HashSet<Piece>();
            Captureds = new HashSet<Piece>();
            PuttingPieces();
        }

        public void ExecutingMovement(Position source, Position destiny)
        {
            Piece piece = Board.RemovingPieces(source);//removing the source position
            piece.incrementingQtyMovements();
            Piece capturedPiece = Board.RemovingPieces(destiny);
            Board.PuttingPiece(piece, destiny);
            if (capturedPiece != null)
            {
                Captureds.Add(capturedPiece);
            }
        }


        public void PerformMove(Position source, Position destiny)
        {
            ExecutingMovement(source, destiny);
            Shift++;
            ChangePlayer();
        }

        public void ValidateTheOriginPosition(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("Don´t exist any piece in that position");
            }
            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("The selected original piece it is not yours!");
            }
            if (!Board.Piece(position).ThereArePossibleMovements())
            {
                throw new BoardException("There isn't any possible movements for this piece!");
            }
        }
        public void ValidateTheDestinyPosition(Position original, Position destiny)
        {
            if (!Board.Piece(original).CanMooveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captureds)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public  HashSet<Piece> PiecesInMatch(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captureds)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public  void PuttingNewPiece(char column, int line, Piece piece)
        {
            Board.PuttingPiece(piece, new ChessPosition(column, line).ToPositionMatrix());
        }
        private void PuttingPieces()
        {
            PuttingNewPiece('c', 1, new Tower(Board, Color.White));
            PuttingNewPiece('c', 2, new Tower(Board, Color.White));
            PuttingNewPiece('d', 2, new Tower(Board, Color.White));
            PuttingNewPiece('e', 2, new Tower(Board, Color.White));
            PuttingNewPiece('e', 1, new Tower(Board, Color.White));
            PuttingNewPiece('d', 1, new King(Board, Color.White));


            PuttingNewPiece('c', 8, new Tower(Board, Color.Black));
            PuttingNewPiece('c', 7, new Tower(Board, Color.Black));
            PuttingNewPiece('d', 8, new King(Board, Color.Black));
            PuttingNewPiece('d', 7, new Tower(Board, Color.Black));
            PuttingNewPiece('e', 8, new Tower(Board, Color.Black));
            PuttingNewPiece('e', 7, new Tower(Board, Color.Black));



        }
    }
}
