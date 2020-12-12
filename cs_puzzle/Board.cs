using System;
using System.Collections.Generic;

namespace cs_puzzle
{
    class Board : IEquatable<Board>
    {
        int[,] m_tiles;
        int N;

        public Board (int given_N)
        {
            N = given_N;
            m_tiles = new int[N, N];
            int count = 0;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    m_tiles[i, j] = count++;
        }

        public void print ()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (m_tiles[i, j] > 0)
                        Console.Write (m_tiles[i, j]);
                    else
                        Console.Write (" ");
                    Console.Write (" ");
                }
                Console.WriteLine ();
            }
            Console.WriteLine ();
        }

        public List<Board> get_available_moves ()
        {
            int zero_i = -1;
            int zero_j = -1;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (m_tiles[i, j] == 0)
                    {
                        zero_i = i;
                        zero_j = j;
                    }

            List<Board> result = new List<Board> ();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int i_diff = i - zero_i;
                    int j_diff = j - zero_j;

                    if (Math.Abs (i_diff) + Math.Abs (j_diff) != 1)
                        continue;

                    Board after_board = new Board (N);
                    after_board.m_tiles = m_tiles.Clone () as int[,];
                    int swap = after_board.m_tiles[i, j];
                    after_board.m_tiles[i, j] = after_board.m_tiles[zero_i, zero_j];
                    after_board.m_tiles[zero_i, zero_j] = swap;

                    result.Add (after_board);
                }
            }

            return result;
        }

        public static Board get_random_board (int board_size, int random_move_number)
        {
            var random = new Random ();
            Board current = new Board (board_size);

            for (int i = 0; i < random_move_number; i++)
            {
                List<Board> moves = current.get_available_moves ();
                current = moves[random.Next (moves.Count)];
            }

            return current;
        }

        public int manhattan ()
        {
            int result = 0;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    if (m_tiles[i, j] == 0)
                        continue;
                    int final_i = m_tiles[i, j] / N;
                    int final_j = m_tiles[i, j] % N;

                    result += Math.Abs (final_i - i) + Math.Abs (final_j - j);
                }
            return result;
        }

        public override bool Equals (object obj)
        {
            return Equals (obj as Board);
        }

        public bool Equals (Board other)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (m_tiles[i, j] != other.m_tiles[i, j])
                        return false;
            return true;
        }

        public override int GetHashCode ()
        {
            int result = 1;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    result = result * 10 + m_tiles[i, j];
            return result;

            int hc = 0;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    hc = unchecked (hc * 17 + m_tiles[i, j]);
            return hc;
        }
    }
}
