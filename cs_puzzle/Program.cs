using System;
using System.Collections;
using System.Collections.Generic;
using Priority_Queue;

namespace cs_puzzle
{
    class Program
    {

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Board starting_board = Board.get_random_board (4, 100);
                Console.WriteLine ("Solving board:");
                starting_board.print ();

                List<Board> solution = BoardSolver.solve_board (starting_board);
                if (solution == null)
                    return;

                //Console.WriteLine ("Solution:");
                //foreach (Board b in solution)
                //    b.print ();
            }
        }
    }
}
