using System;
using System.Collections.Generic;

namespace cs_puzzle
{
    class Program
    {

        static void Main(string[] args)
        {
            Board a = Board.get_random_board (3, 100);
            a.print ();
            Console.WriteLine (a.manhattan ());
        }
    }
}
