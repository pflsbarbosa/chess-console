using System;
using board;

namespace Chess_console_mode
{
    class Program
    {
        static void Main(string[] args)
        {
            Position P;
            P = new Position(3, 4);

            Console.WriteLine("Position: " + P);

            Console.ReadKey();

        }
    }
}
