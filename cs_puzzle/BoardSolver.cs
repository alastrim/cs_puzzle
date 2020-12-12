using System;
using System.Collections;
using System.Collections.Generic;
using Priority_Queue;

namespace cs_puzzle
{
    class BoardSolver
    {
        static public List<Board> solve_board (Board starting_board)
        {
            var visited_boards = new Dictionary<int, VisitedBoardInfo> ();
            var queue = new SimplePriorityQueue<VisitedBoardInfo, int> ();
            queue.Enqueue (new VisitedBoardInfo (0, null, starting_board), 0);

            int max_queue_size = 0;
            VisitedBoardInfo current_board_info;
            do
            {
                if (queue.Count > max_queue_size)
                    max_queue_size = queue.Count;

                current_board_info = queue.Dequeue ();
                Board current_board = current_board_info.m_board;

                if (current_board.manhattan () == 0)
                    break;

                if (visited_boards.ContainsKey (current_board.GetHashCode ()))
                    continue;

                visited_boards.Add (current_board.GetHashCode (), current_board_info);

                List<Board> moves = current_board.get_available_moves ();
                foreach (Board move in moves)
                {
                    if (visited_boards.ContainsKey (move.GetHashCode ()))
                        continue;

                    int prev_boards_num = current_board_info.m_prev_boards_num + 1;
                    int priority = move.manhattan () + prev_boards_num;
                    queue.Enqueue (new VisitedBoardInfo (prev_boards_num, current_board_info, move), priority);
                }

            } while (queue.Count > 0);

            if (current_board_info.m_board.manhattan () != 0)
            {
                Console.WriteLine ("Board seems unsolvable");
                return null;
            }

            List<Board> solution_boards = new List<Board> ();
            for (VisitedBoardInfo b = current_board_info; b.m_prev_boards_num > 0; b = b.m_prev_board_info)
                solution_boards.Add (b.m_board);

            solution_boards.Reverse ();

            Console.WriteLine ("Board solved succesfully, max queue size = {0}, steps required = {1}", max_queue_size, solution_boards.Count);
            return solution_boards;
        }
    }
}
