using System;
using System.Collections.Generic;

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
            return m_board.GetHashCode ();
        }
    }
}

