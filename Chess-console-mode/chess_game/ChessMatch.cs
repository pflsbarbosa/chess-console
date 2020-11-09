using System;
using chess_board;

namespace chess_game
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;//Initating with white Pieces (chess rule)
            Finished = false;
            PuttingPieces();
        }
        public void ExecutingMovement(Position source, Position destiny)
        {
            Piece piece = Board.RemovingPieces(source);//removing the source position
            piece.incrementingQtyMovements();
            Piece capturedPiece = Board.RemovingPieces(destiny);
            Board.PuttingPiece(piece, destiny);
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
        private void PuttingPieces()
        {
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ToPositionMatrix());
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ToPositionMatrix());
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).ToPositionMatrix());
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ToPositionMatrix());
            Board.PuttingPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ToPositionMatrix());
            Board.PuttingPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPositionMatrix());


            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).ToPositionMatrix());
            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).ToPositionMatrix());
            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPositionMatrix());
            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).ToPositionMatrix());
            Board.PuttingPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).ToPositionMatrix());
            Board.PuttingPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPositionMatrix());

        }
    }
}
