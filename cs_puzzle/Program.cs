using System;
using System.Collections;
using System.Collections.Generic;
using Priority_Queue;

namespace cs_puzzle
{
    class VisitedBoardInfo : IEquatable<VisitedBoardInfo>
    {
        public VisitedBoardInfo (int prev_board_hash, int prev_boards_num, Board board)
        {
            m_prev_board_hash = prev_board_hash;
            m_prev_boards_num = prev_boards_num;
            m_board = board;
        }
        public int m_prev_board_hash;
        public int m_prev_boards_num;
        public Board m_board;

        public override bool Equals (object obj)
        {
            return Equals (obj as VisitedBoardInfo);
        }

        public bool Equals (VisitedBoardInfo other)
        {
            return other != null && EqualityComparer<Board>.Default.Equals (m_board, other.m_board);
        }

        public override int GetHashCode ()
        {
            return HashCode.Combine (m_board);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Board starting_board = Board.get_random_board (3, 100);
            Console.WriteLine ("Initial board:");
            starting_board.print ();

            var visited_boards = new Dictionary<int, VisitedBoardInfo> ();
            var queue = new SimplePriorityQueue<VisitedBoardInfo, double> ();
            queue.Enqueue (new VisitedBoardInfo (-1, 0, starting_board), 9999);

            Board current_board;
            VisitedBoardInfo current_board_info;
            while (true)
            {
                current_board_info = queue.Dequeue ();
                current_board = current_board_info.m_board;

                if (current_board.manhattan () == 0)
                    break;

                if (visited_boards.ContainsKey (current_board.GetHashCode ()))
                    continue;

                visited_boards.Add (current_board.GetHashCode (), current_board_info);

                List<Board> moves = current_board.get_available_moves ();
                foreach (Board move in moves)
                {
                    int priority = move.manhattan () + current_board_info.m_prev_boards_num;
                    queue.Enqueue (new VisitedBoardInfo (current_board.GetHashCode (), current_board_info.m_prev_boards_num + 1, move), priority);
                }

            }

            List<Board> solution_boards = new List<Board> ();
            for (VisitedBoardInfo b = current_board_info; b.m_prev_boards_num > 0; b = visited_boards[b.m_prev_board_hash])
                solution_boards.Add (b.m_board);

            solution_boards.Reverse ();

            Console.WriteLine ("Solution:");
            foreach (Board b in solution_boards)
                b.print ();
        }
    }
}
