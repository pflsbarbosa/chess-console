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
        public bool CheckMate { get; private set; }
        public Piece VulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;//Initating with white Pieces (chess rule)
            Finished = false;
            CheckMate = false;
            VulnerableEnPassant = null;
            Pieces = new HashSet<Piece>();
            Captureds = new HashSet<Piece>();
            PuttingPieces();
        }

        public Piece ExecutingMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovingPiece(origin);//removing the source position
            piece.IncrementingQtyMovements();
            Piece capturedPiece = Board.RemovingPiece(destiny);
            Board.PuttingPiece(piece, destiny);
            if (capturedPiece != null)
            {
                Captureds.Add(capturedPiece);
            }

            //#special Movement: Small Castling
            if (piece is King && destiny.Column == origin.Column + 2 )
            {
                Position towerOrigin = new Position(origin.Line, origin.Column + 3);//king's Column +3
                Position towerDestiny = new Position(origin.Line, origin.Column + 1);//king's Column +1
                Piece tower = Board.RemovingPiece(towerOrigin);
                tower.IncrementingQtyMovements();
                Board.PuttingPiece(tower, towerDestiny);
            }
            
            //#special Movement: Great Castling
            if (piece is King && destiny.Column == origin.Column - 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column - 4);//king's Column +3
                Position towerDestiny = new Position(origin.Line, origin.Column -1);//king's Column +1
                Piece tower = Board.RemovingPiece(towerOrigin);
                tower.IncrementingQtyMovements();
                Board.PuttingPiece(tower, towerDestiny);
            }

            //#Special movement: En Passant
            if (piece is Pawn) 
            {
                if (origin.Column != destiny.Column && capturedPiece == null)
                {
                    Position pawnPos;
                    if (piece.Color == Color.White)
                    {
                        pawnPos = new Position(destiny.Line + 1, destiny.Column);

                    }
                    else
                    {
                        pawnPos = new Position(destiny.Line - 1, destiny.Column);
                    }
                    capturedPiece = Board.RemovingPiece(pawnPos);
                    Captureds.Add(capturedPiece);
                }

            }
            
            return capturedPiece;
        }

        public void UndoTheMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Board.RemovingPiece(destiny);
            p.DecrementingQtyMovements();
            if (capturedPiece != null)
            {
                Board.PuttingPiece(capturedPiece, destiny);
                Captureds.Remove(capturedPiece);
            }
            Board.PuttingPiece(p, origin);

            //#special Movement: Small Castling
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column + 3);//king's Column +3
                Position towerDestiny = new Position(origin.Line, origin.Column + 1);//king's Column +1
                Piece tower = Board.RemovingPiece(towerDestiny);
                tower.DecrementingQtyMovements();
                Board.PuttingPiece(tower, towerOrigin);
            }
            //#special Movement: Great Castling
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position towerOrigin = new Position(origin.Line, origin.Column - 4);//king's Column +3
                Position towerDestiny = new Position(origin.Line, origin.Column - 1);//king's Column +1
                Piece tower = Board.RemovingPiece(towerDestiny);
                tower.DecrementingQtyMovements();
                Board.PuttingPiece(tower, towerOrigin);
            }
            //#Special movement: En Passant
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column && capturedPiece == VulnerableEnPassant)
                {
                    Piece pawn = Board.RemovingPiece(destiny);
                    Position posPawn;
                    if (p.Color == Color.White)
                    {
                        posPawn = new Position(3, destiny.Column);
                    }
                    else
                    {
                        posPawn = new Position(4, destiny.Column);
                    }
                    Board.PuttingPiece(pawn, posPawn);
                }
            }
        }
        public void PerformMove(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecutingMovement(origin, destiny);

            if (IsInCheckMate(CurrentPlayer))
            {
                UndoTheMovement(origin, destiny, capturedPiece);
                throw new BoardException("You can not put yourself in check-mate!");
            }

            if (IsInCheckMate(Opponent(CurrentPlayer)))
            {
                CheckMate = true;
            }
            else
            {
                CheckMate = false;
            }

            if (TestingCheckMate(Opponent(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Shift++;
                ChangePlayer();
            }

            Piece p = Board.Piece(destiny);

            //#Special movement: EnPassant
            if (p is Pawn && (destiny.Line == origin.Line -2 || destiny.Line == origin.Line + 2))
            {
                VulnerableEnPassant = p;
            }
            else
            {
                VulnerableEnPassant = null;
            }
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
            if (!Board.Piece(original).PossibleMovement(destiny))
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
        public HashSet<Piece> PiecesInMatch(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)//if color give it is equal to white
            {
                return Color.Black; //the opponent color will be the black
            }
            else
            {
                return Color.White;
            }
        }
        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInMatch(color))
            {
                //who is the king of one given color
                if (x is King)//if this piece it is an instance of class king
                {
                    return x;//return this piece(King)
                }
            }
            return null;
        }

        public bool IsInCheckMate(Color color)
        {
            //it is the king of a certain color in checkmate?
            //first check if that king it is  on the board
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("There isn't the king of color " + color + " in the board!");
            }
            foreach (Piece x in PiecesInMatch(Opponent(color)))
            {
                bool[,] logicMatrix = x.PossibleMovements();//if oppnonent piece x
                if (logicMatrix[K.Position.Line, K.Position.Column])//in position where is the king it's true
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestingCheckMate(Color color)
        {
            if (!IsInCheckMate(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInMatch(color))
            {
                bool[,] logicMatrix = x.PossibleMovements();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (logicMatrix[i, j])//if the matrix in j position it is true it is a possible position for that piece
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecutingMovement(origin, destiny);
                            bool check_CheckMate = IsInCheckMate(color);
                            UndoTheMovement(origin, destiny, capturedPiece);
                            if (!check_CheckMate)//if king is not any more in check
                            {
                                return false;
                            }
                        }


                    }
                }
            }
            return true;//lost the game
        }

        public void PuttingNewPiece(char column, int line, Piece piece)
        {
            Board.PuttingPiece(piece, new ChessPosition(column, line).ToPositionMatrix());
            Pieces.Add(piece);
        }

        private void PuttingPieces()
        {
            
            PuttingNewPiece('a', 1, new Tower(Board, Color.White));
            PuttingNewPiece('b', 1, new Horse(Board, Color.White));
            PuttingNewPiece('c', 1, new Bishop(Board, Color.White));
            PuttingNewPiece('d', 1, new Queen(Board, Color.White));
            PuttingNewPiece('e', 1, new King(Board, Color.White, this));
            PuttingNewPiece('f', 1, new Bishop(Board, Color.White));
            PuttingNewPiece('g', 1, new Horse(Board, Color.White));
            PuttingNewPiece('h', 1, new Tower(Board, Color.White));

            PuttingNewPiece('a', 2, new Pawn(Board, Color.White, this));
            PuttingNewPiece('b', 2, new Pawn(Board, Color.White, this));
            PuttingNewPiece('c', 2, new Pawn(Board, Color.White, this));
            PuttingNewPiece('d', 2, new Pawn(Board, Color.White, this));
            PuttingNewPiece('e', 2, new Pawn(Board, Color.White, this));
            PuttingNewPiece('f', 2, new Pawn(Board, Color.White, this));
            PuttingNewPiece('g', 2, new Pawn(Board, Color.White, this));
            PuttingNewPiece('h', 2, new Pawn(Board, Color.White, this));

            PuttingNewPiece('a', 8, new Tower(Board, Color.Black));
            PuttingNewPiece('b', 8, new Horse(Board, Color.Black));
            PuttingNewPiece('c', 8, new Bishop(Board, Color.Black));
            PuttingNewPiece('d', 8, new Queen(Board, Color.Black));
            PuttingNewPiece('e', 8, new King(Board, Color.Black, this));
            PuttingNewPiece('f', 8, new Bishop(Board, Color.Black));
            PuttingNewPiece('g', 8, new Horse(Board, Color.Black));
            PuttingNewPiece('h', 8, new Tower(Board, Color.Black));

            PuttingNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            PuttingNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            PuttingNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            PuttingNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            PuttingNewPiece('e', 7, new Pawn(Board, Color.Black, this));
            PuttingNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            PuttingNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            PuttingNewPiece('h', 7, new Pawn(Board, Color.Black, this));


        }
    }
}
