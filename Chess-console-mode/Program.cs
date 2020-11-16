﻿using System;
using chess_board;
using chess_game;

namespace Chess_console_mode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintingChessMatch(chessMatch);

                        Console.WriteLine();
                        Console.Write("Source: ");
                        Position original = Screen.ReadingChessPosition().ToPositionMatrix();
                        chessMatch.ValidateTheOriginPosition(original);
                        

                        bool[,] possiblePositions = chessMatch.Board.Piece(original).PossibleMovements();

                        Console.Clear();
                        Screen.printingChessBoard(chessMatch.Board, possiblePositions);


                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadingChessPosition().ToPositionMatrix();
                        chessMatch.ValidateTheDestinyPosition(original, destiny);
                        chessMatch.PerformMove(original, destiny);
                    }
                    catch (BoardException e)
                    {

                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintingChessMatch(chessMatch);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.ReadKey();

        }
    }
}
