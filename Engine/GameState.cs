using System;
using System.Collections.Generic;
using System.Text;

using utility_t = System.Double;
using bitboard_t = System.Int64;


namespace C4.Engine
{
    public class GameState
    {
        # region GameState class Constants

        private const int MAX_FILES = 8;
        private const int MAX_RANKS = 8;
        private const int MAX_WINBOARDS = (24 + 24 + 21);

        public const double EQUAL_GAME = 0.0;
        public const double MAX_WINS = 100.0;
        public const double MIN_WINS = -100.0;

        /* We give a large advantage for any 3 in a row */
        private const double MAX_LARGE_ADVANTAGE = 1.0;
        private const double MIN_LARGE_ADVANTAGE = -1.0;

        /* An odd advantage is one where the threat falls on an 
          odd row. */
        private const double MAX_ODD_BONUS = 0.40;
        private const double MIN_ODD_BONUS = -0.40;

        /* An even advantage is one where the threat falls on an 
          even row. Note that an even threat is not worth anything for
          MAX */
        private const double MAX_EVEN_BONUS = 0.0;
        private const double MIN_EVEN_BONUS = -0.20;

        /* creating a threat on a lower rank is more valuable than
         creating a threat on a higher rank. Threats on rank1 are 
         not very useful, so we give no bonus for first rank threats.
         For ranks 2-6, we give the bonus C * RANK_BONUS, where C is a
         constant that reflects how valuable the rank is. The end result 
         is that rank_2 is worth .25 (.05 * 5) and rank 6 is worth
         .05 (.05 * 1). */
        private const double MAX_RANK_BONUS = 0.05;
        private const double MIN_RANK_BONUS = -0.05;

        /* We give a small advantage to any two in a row that 
           could turn into a three in a row + threat to win */
        private const double MAX_SMALL_ADVANTAGE = 0.01;
        private const double MIN_SMALL_ADVANTAGE = -0.01;

        private const bitboard_t A1 = (1 << 0);
        private const bitboard_t A2 = (A1 << 8);
        private const bitboard_t A3 = (A2 << 8);
        private const bitboard_t A4 = (A3 << 8);
        private const bitboard_t A5 = (A4 << 8);
        private const bitboard_t A6 = (A5 << 8);
        private const bitboard_t A7 = (A6 << 8);
        private const bitboard_t A8 = (A7 << 8);
        private const bitboard_t AFILE = (A1 | A2 | A3 | A4 | A5 | A6 | A7 | A8);

        private const bitboard_t B1 = (1 << 1);
        private const bitboard_t B2 = (B1 << 8);
        private const bitboard_t B3 = (B2 << 8);
        private const bitboard_t B4 = (B3 << 8);
        private const bitboard_t B5 = (B4 << 8);
        private const bitboard_t B6 = (B5 << 8);
        private const bitboard_t B7 = (B6 << 8);
        private const bitboard_t B8 = (B7 << 8);
        private const bitboard_t BFILE = (B1 | B2 | B3 | B4 | B5 | B6 | B7 | B8);

        private const bitboard_t C1 = (1 << 2);
        private const bitboard_t C2 = (C1 << 8);
        private const bitboard_t C3 = (C2 << 8);
        private const bitboard_t C4 = (C3 << 8);
        private const bitboard_t C5 = (C4 << 8);
        private const bitboard_t C6 = (C5 << 8);
        private const bitboard_t C7 = (C6 << 8);
        private const bitboard_t C8 = (C7 << 8);
        private const bitboard_t CFILE = (C1 | C2 | C3 | C4 | C5 | C6 | C7 | C8);

        private const bitboard_t D1 = (1 << 3);
        private const bitboard_t D2 = (D1 << 8);
        private const bitboard_t D3 = (D2 << 8);
        private const bitboard_t D4 = (D3 << 8);
        private const bitboard_t D5 = (D4 << 8);
        private const bitboard_t D6 = (D5 << 8);
        private const bitboard_t D7 = (D6 << 8);
        private const bitboard_t D8 = (D7 << 8);
        private const bitboard_t DFILE = (D1 | D2 | D3 | D4 | D5 | D6 | D7 | D8);

        private const bitboard_t E1 = (1 << 4);
        private const bitboard_t E2 = (E1 << 8);
        private const bitboard_t E3 = (E2 << 8);
        private const bitboard_t E4 = (E3 << 8);
        private const bitboard_t E5 = (E4 << 8);
        private const bitboard_t E6 = (E5 << 8);
        private const bitboard_t E7 = (E6 << 8);
        private const bitboard_t E8 = (E7 << 8);
        private const bitboard_t EFILE = (E1 | E2 | E3 | E4 | E5 | E6 | E7 | E8);

        private const bitboard_t F1 = (1 << 5);
        private const bitboard_t F2 = (F1 << 8);
        private const bitboard_t F3 = (F2 << 8);
        private const bitboard_t F4 = (F3 << 8);
        private const bitboard_t F5 = (F4 << 8);
        private const bitboard_t F6 = (F5 << 8);
        private const bitboard_t F7 = (F6 << 8);
        private const bitboard_t F8 = (F7 << 8);
        private const bitboard_t FFILE = (F1 | F2 | F3 | F4 | F5 | F6 | F7 | F8);

        private const bitboard_t G1 = (1 << 6);
        private const bitboard_t G2 = (G1 << 8);
        private const bitboard_t G3 = (G2 << 8);
        private const bitboard_t G4 = (G3 << 8);
        private const bitboard_t G5 = (G4 << 8);
        private const bitboard_t G6 = (G5 << 8);
        private const bitboard_t G7 = (G6 << 8);
        private const bitboard_t G8 = (G7 << 8);
        private const bitboard_t GFILE = (G1 | G2 | G3 | G4 | G5 | G6 | G7 | G8);

        private const bitboard_t H1 = (1 << 7);
        private const bitboard_t H2 = (H1 << 8);
        private const bitboard_t H3 = (H2 << 8);
        private const bitboard_t H4 = (H3 << 8);
        private const bitboard_t H5 = (H4 << 8);
        private const bitboard_t H6 = (H5 << 8);
        private const bitboard_t H7 = (H6 << 8);
        private const bitboard_t H8 = (H7 << 8);
        private const bitboard_t HFILE = (H1 | H2 | H3 | H4 | H5 | H6 | H7 | H8);

        private const bitboard_t RANK_1 = (A1 | B1 | C1 | D1 | E1 | F1 | G1 | H1);
        private const bitboard_t RANK_2 = (A2 | B2 | C2 | D2 | E2 | F2 | G2 | H2);
        private const bitboard_t RANK_3 = (A3 | B3 | C3 | D3 | E3 | F3 | G3 | H3);
        private const bitboard_t RANK_4 = (A4 | B4 | C4 | D4 | E4 | F4 | G4 | H4);
        private const bitboard_t RANK_5 = (A5 | B5 | C5 | D5 | E5 | F5 | G5 | H5);
        private const bitboard_t RANK_6 = (A6 | B6 | C6 | D6 | E6 | F6 | G6 | H6);
        private const bitboard_t RANK_7 = (A7 | B7 | C7 | D7 | E7 | F7 | G7 | H7);
        private const bitboard_t RANK_8 = (A8 | B8 | C8 | D8 | E8 | F8 | G8 | H8);

        private const bitboard_t ODD_THREATS = (RANK_3 | RANK_5);
        private const bitboard_t EVEN_THREATS = (RANK_2 | RANK_4 | RANK_6);

        private const bitboard_t VALID_SQUARES = (~(RANK_7 | RANK_8 | HFILE));
        private const bitboard_t VALID_NEXT_AVAIL = (~(RANK_8 | HFILE));

        # endregion

        # region Static bitboards
        /* read only bitboards; we use these to quickly evaluate winning positions */

        static List<bitboard_t> files = new List<bitboard_t>();
        static List<bitboard_t> ranks = new List<bitboard_t>();

        static List<bitboard_t> winboards = new List<bitboard_t>();
        static bitboard_t filled_board = VALID_SQUARES;

        static bool init_ = false;
        # endregion

        # region Class data members
        protected bitboard_t max_;
        protected bitboard_t min_;
        protected bitboard_t next_avail_;
        protected bool maxonmove_;
        protected int prev_play_;
        protected System.Random randomizer_ = new System.Random();
        protected bool random_;
        protected bool MOVE_ORDER_HEURISTIC = true;
        
        protected enum FILES { A_FILE = 0, B_FILE, C_FILE, D_FILE, E_FILE, F_FILE, G_FILE, H_FILE };
        protected enum STM { MAX, MIN };
        # endregion

        # region Public properties
        public enum AlgorithmType { NegaMax, AlphaBeta, NegaScout };

        private AlgorithmType _algorithm = AlgorithmType.AlphaBeta;
        public AlgorithmType Algorithm
        {
            get
            {
                return _algorithm;
            }

            set
            {
                _algorithm = value;
                MOVE_ORDER_HEURISTIC = (_algorithm != AlgorithmType.NegaMax);
            }
        }

        public bool Random
        {
            get
            {
                return random_;
            }
            set
            {
                random_ = value;
            }
        }
        # endregion

        # region Construction Code
        /// <summary>
        /// One time initialization of static bitboards
        /// </summary>
        private void Init()
        {
            if (init_) return;
            init_ = true;

            // initialize file lookups

            files.Add(AFILE);
            files.Add(BFILE);
            files.Add(CFILE);
            files.Add(DFILE);
            files.Add(EFILE);
            files.Add(FFILE);
            files.Add(GFILE);
            files.Add(HFILE);

            ranks.Add(RANK_1);
            ranks.Add(RANK_2);
            ranks.Add(RANK_3);
            ranks.Add(RANK_4);
            ranks.Add(RANK_5);
            ranks.Add(RANK_6);
            ranks.Add(RANK_7);
            ranks.Add(RANK_8);

            // Init horizontal wins (24 total)
            for (int i = 0; i < 6; i++)
            {
                bitboard_t bb = (A1 | B1 | C1 | D1);
                bb <<= i * 8;

                for (int j = 0; j < 4; j++)
                {
                    winboards.Add(bb);
                    bb <<= 1;
                }
            }

            // Init vertical wins (21 total)
            for (int i = 0; i < 7; i++)
            {
                bitboard_t bb = (A1 | A2 | A3 | A4);
                bb <<= i;
                for (int j = 0; j < 3; j++)
                {
                    winboards.Add(bb);
                    bb <<= 8;
                }
            }

            // init winning diagonals
            winboards.Add(A1 | B2 | C3 | D4);
            winboards.Add(A2 | B3 | C4 | D5);
            winboards.Add(A3 | B4 | C5 | D6);
            winboards.Add(B1 | C2 | D3 | E4);
            winboards.Add(B2 | C3 | D4 | E5);
            winboards.Add(B3 | C4 | D5 | E6);
            winboards.Add(C1 | D2 | E3 | F4);
            winboards.Add(C2 | D3 | E4 | F5);
            winboards.Add(C3 | D4 | E5 | F6);
            winboards.Add(D1 | E2 | F3 | G4);
            winboards.Add(D2 | E3 | F4 | G5);
            winboards.Add(D3 | E4 | F5 | G6);

            winboards.Add(A6 | B5 | C4 | D3);
            winboards.Add(A5 | B4 | C3 | D2);
            winboards.Add(A4 | B3 | C2 | D1);
            winboards.Add(B6 | C5 | D4 | E3);
            winboards.Add(B5 | C4 | D3 | E2);
            winboards.Add(B4 | C3 | D2 | E1);
            winboards.Add(C6 | D5 | E4 | F3);
            winboards.Add(C5 | D4 | E3 | F2);
            winboards.Add(C4 | D3 | E2 | F1);
            winboards.Add(D6 | E5 | F4 | G3);
            winboards.Add(D5 | E4 | F3 | G2);
            winboards.Add(D4 | E3 | F2 | G1);
        }

        /// <summary>
        /// construct the gamestate, and reset to start-of-game state.
        /// </summary>
        public GameState()
        {
            Init();
            Reset();
        }
    # endregion

        # region Helper Functions
        /// <summary>
        /// Reset the board to the initial state
        /// </summary>
        public void Reset()
        {
            // max always moves first
            maxonmove_ = true;

            // next_avail_ is a bitmask of the next square on each file
            // that can be played to.
            next_avail_ = RANK_1 & VALID_SQUARES;

            // max_ and min_ are bitmasks indicating which locations each
            // side has played to. When they are AND'ed together, you get 
            // the total board state
            max_ = 0;
            min_ = 0;

            // This is a bit setting of where the last move was made at
            prev_play_ = 0;
        }

        /// <summary>
        /// Count the number of bits that are set for the input bitboard
        /// </summary>
        /// <param name="b">the bitboard to check</param>
        /// <returns>number of bits that are on</returns>
        protected int CountBitsOn(bitboard_t b)
        {
            int n = 0;
            do
            {
                if ((b & 1) != 0) n++;
            } while ((b >>= 1) != 0);

            return n;
        }

        /// <summary>
        /// Get a number that reflects the value of a particular rank.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        protected int GetRankValue(bitboard_t b)
        {
            int n = 6;

            while ((b >>= 8) != 0) n -= 1;

            return (n == 6) ? 0 : n;
        }

        /// <summary>
        /// Evaluate the current gamestate
        /// </summary>
        /// <returns>the score for this position</returns>
        protected utility_t Evaluate(bool absEval)
        {
            utility_t val = EQUAL_GAME;
            bitboard_t max_threats = 0;
            bitboard_t min_threats = 0;

            /* Each "win board" is one four-in-a-row sequence that would represent a win. We cycle
               through all possible win boards, awarding points to both min and max based on their 
               respective advantages. We award a large advantage to MIN (or MAX) each time he can
               get an uncontested 3 of 4 (meaning one more play on that winboard represents a win), and 
               a small advantage for an uncontested 2 of 4 (i.e. two more plays on that winboard to win the
               game). An equal position will be close to a zero score. A large advantage for max will be a 
               large positive score. And a large advantage for min will be a large negative score. 
             
             Additionally, bonus points are added when a three-in-a-row creates a threat on an odd row, i.e.
             row 3 or 5. Min can get bonus points for creating an even threat (even threats do not help
             MAX at all). */

            foreach (bitboard_t bb in winboards)
            {

                // each side has made a play on this winboard. Neither side 
                // has winning opportunities here, so skip it and look at the next one.
                if ((bb & max_) != 0 && (bb & min_) != 0)
                {
                    continue;
                }
                else if ((bb & max_) != 0)
                {

                    // all bits on: max wins
                    if ((bb & max_) == bb)
                    {
                        val = MAX_WINS;
                        break;
                    }

                    // check how many bits are set, and award points as
                    // needed.
                    int n = CountBitsOn(bb & max_);

                    // Max has played 3 of 4 on this win board. This is a big advantage.
                    // Do not award points for duplicate theats
                    if (n == 3 && (bb & ~max_ & max_threats) == 0)
                    {
                        bitboard_t this_threat = bb & ~max_;

                        // add this threat to our list of current threats
                        max_threats |= this_threat;

                        val += MAX_LARGE_ADVANTAGE;

                        if ((this_threat & ODD_THREATS) != 0)
                        {
                            val += MAX_ODD_BONUS;
                        }

                        // give a bonus based on which rank the threat falls on
                        val += MAX_RANK_BONUS * GetRankValue(bb);
                    }
                    // Max has played 2 of 4 on this win board. Small advantage.
                    else if (n == 2)
                    {
                        val += MAX_SMALL_ADVANTAGE;
                    }
                }
                else if ((bb & min_) != 0)
                {
                    //all bits on: min wins
                    if ((bb & min_) == bb)
                    {
                        val = MIN_WINS;
                        break;
                    }
                    // check how many bits are set, and award points as
                    // needed.
                    int n = CountBitsOn(bb & min_);

                    // Min has played 3 of 4 on this win board. This is a big advantage.
                    if (n == 3 && (bb & ~min_ & min_threats) == 0)
                    {
                        bitboard_t this_threat = bb & ~min_;

                        val += MIN_LARGE_ADVANTAGE;

                        // add to our list of current threats
                        min_threats |= this_threat;

                        if (((bb & ~min_) & ODD_THREATS) != 0)
                        {
                            val += MIN_ODD_BONUS;
                        }
                        else if (((bb & ~min_) & EVEN_THREATS) != 0)
                        {
                            val += MIN_EVEN_BONUS;
                        }

                        // give a bonus based on which rank the threat falls on
                        val += MIN_RANK_BONUS * GetRankValue(bb);
                    }
                    // Min has played 2 of 4 on this win board. This is a small advantage.
                    else if (n == 2)
                    {
                        val += MIN_SMALL_ADVANTAGE;
                    }
                }
            }

            // add a small randomizing value if requested
            if (Random && val != MAX_WINS && val != MIN_WINS) {
                double r = randomizer_.Next(99);
                r /= 10000;
                val += r;
            }

            System.Diagnostics.Debug.Assert(val <= MAX_WINS && val >= MIN_WINS);

            if (absEval)
            {
                return val;
            }
            else
            {
                if (GameState.STM.MAX == SideToMove())
                {
                    return val;
                }
                else
                {
                    return -val;
                }
            }
        }

        /// <summary>
        /// Check if the board is filled (i.e. game over, nobody wins)
        /// </summary>
        /// <returns>True if the board is filled up</returns>
        protected bool BoardFilled() 
        {
            if ((max_ | min_) == filled_board)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get the next available rank location for a given file
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        protected bitboard_t GetNextAvailAtFile(int column)
        {
            bitboard_t b = (next_avail_ & files[column]);
            b &= VALID_SQUARES;

            System.Diagnostics.Debug.Assert((b & max_) == 0);
            System.Diagnostics.Debug.Assert((b & min_) == 0);

            return b;
        }

        /// <summary>
        /// Update next_avail_ after a move has been made
        /// </summary>
        /// <param name="next"></param>
        protected void UpdateNextAvail(bitboard_t next) 
        {
            // This could ruin next_avail_ !
            System.Diagnostics.Debug.Assert(CountBitsOn(next) == 1);

            next_avail_ &= ~next;
            next_avail_ |= (next << 8);

            next_avail_ &= VALID_NEXT_AVAIL;

            System.Diagnostics.Debug.Assert(next_avail_ != 0);
            System.Diagnostics.Debug.Assert((next_avail_ & max_) == 0);
            System.Diagnostics.Debug.Assert((next_avail_ & min_) == 0);
        }

        /// <summary>
        /// Undo a change made to next_avail_ by UpdateNextAvail()
        /// </summary>
        /// <param name="next"></param>
        protected void UndoNextAvail(bitboard_t next)
        {
            next_avail_ &= ~(next << 8);
            next_avail_ |= next;
            next_avail_ &= VALID_NEXT_AVAIL;

            System.Diagnostics.Debug.Assert(next_avail_ != 0);
            System.Diagnostics.Debug.Assert((next_avail_ & max_) == 0);
            System.Diagnostics.Debug.Assert((next_avail_ & min_) == 0);
        }

        /// <summary>
        /// Get the file that a particular bitboard is on
        /// </summary>
        /// <param name="bb"></param>
        /// <returns></returns>
        protected int FileFromBitboard(bitboard_t bb)
        {
            int r = 0;
            for (int n = 0; n < files.Count; n++) {
                if ((bb & files[n]) != 0) {
                    r = n;
                    break;
                }
            }

            System.Diagnostics.Debug.Assert(r >= (int)GameState.FILES.A_FILE);
            System.Diagnostics.Debug.Assert(r < (int)GameState.FILES.H_FILE);

            return r;
        }

        /// <summary>
        /// Make a move specified by a bitboard
        /// </summary>
        /// <param name="move"></param>
        protected void MakeMove(bitboard_t move)
        {
            System.Diagnostics.Debug.Assert(move != 0);

            if (maxonmove_) {
		        max_ |= move;
                System.Diagnostics.Debug.Assert(max_ == (max_ & VALID_SQUARES));
            }
            else {
		        min_ |= move;
                System.Diagnostics.Debug.Assert(min_ == (min_ & VALID_SQUARES));
            }

            if (MOVE_ORDER_HEURISTIC)
                prev_play_ = FileFromBitboard(move);

            UpdateNextAvail(move);
            maxonmove_ = !maxonmove_;
        }

        /// <summary>
        /// Undo a move specified by a bitboard
        /// </summary>
        /// <param name="move"></param>
        protected void UnMakeMove(bitboard_t move)
        {
            System.Diagnostics.Debug.Assert(move != 0);

            if (!maxonmove_)
            {
                max_ &= ~move;
            }
            else
            {
                min_ &= ~move;
            }

            // Note: No need to undo prev_play_

            UndoNextAvail(move);
            maxonmove_ = !maxonmove_;
        }

        /// <summary>
        /// Generate all the legal moves in the current position
        /// </summary>
        /// <param name="moves"></param>
        protected void GenerateMoves(List<bitboard_t> moves)
        {
            /* The AlphaBeta algorithm is sensitive to move ordering. The 
            sooner it is given the best move, the faster it will perform.
            What we need is a heuristic that in general will guess the
            best first move. For connect four, a good heuristic is to say
            that the best move will be near where the opponent just played. 
            My (limited) testing suggests that this method speeds up the search
            by nearly 50% */

            if (!MOVE_ORDER_HEURISTIC) {
                for (GameState.FILES i = GameState.FILES.A_FILE; i < GameState.FILES.H_FILE; i++)
                {
                    bitboard_t b = GetNextAvailAtFile(Convert.ToInt32(i));
                    if (b != 0)
                    {
                        moves.Add(b);
                    }
                }
            }
            else {
                System.Diagnostics.Debug.Assert(prev_play_ >= (int)GameState.FILES.A_FILE);
                System.Diagnostics.Debug.Assert(prev_play_ < (int)GameState.FILES.H_FILE);

                int current = prev_play_;
                for (int i = 0; i < GameState.MAX_FILES; i++)
                {
                    bitboard_t b;
                    if (i == 0)
                    {
                        b = GetNextAvailAtFile(current);
                        if (b != 0)
                        {
                            moves.Add(b);
                        }
                    }
                    else
                    {
                        if (current + i < (int)GameState.FILES.H_FILE)
                        {
                            b = GetNextAvailAtFile(current + i);
                            if (b != 0)
                            {
                                moves.Add(b);
                            }
                        }

                        if (current - i >= (int)GameState.FILES.A_FILE)
                        {
                            b = GetNextAvailAtFile(current - i);
                            if (b != 0)
                            {
                                moves.Add(b);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Determine which side has the move
        /// </summary>
        /// <returns></returns>
        protected GameState.STM SideToMove()
        {
            if (maxonmove_)
                return GameState.STM.MAX;
            else
                return GameState.STM.MIN;
        }

        /// <summary>
        /// Return the value for infinity. This only needs to be a number
        /// that is larger than the greatest value Max can achieve.
        /// </summary>
        /// <returns></returns>
        protected utility_t Infinity()
        {
            return MAX_WINS + 1;
        }

        /// <summary>
        /// Convert a bitboard to a string representation
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        protected String BitboardToString(bitboard_t b)
        {
            int r = 7;
            int f = 7;
            for (r = 0; r < 6; r++)
            {
                if ((ranks[r] & b) != 0)
                {
                    break;
                }
            }

            for (f = 0; f < 7; f++)
            {
                if ((files[f] & b) != 0)
                {
                    break;
                }
            }

            return String.Format("{0}{1}", Char.ToLower(Convert.ToChar(65 + f)), r + 1);
        }

        /// <summary>
        /// convert a string to a bitboard representation
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        protected bitboard_t StringToBitboard(String s)
        {
            String rank = s[1].ToString();
            int f = Convert.ToInt32(Char.ToUpper(s[0])) - 65;
            int r = (int.Parse(rank) - 1) * 8;

            bitboard_t mf = (1 << f);
            bitboard_t m = mf << r;

            return m;
        }
        # endregion

        # region Search Algorithms
        
        /// <summary>
        /// The negamax search algorithm
        /// </summary>
        /// <param name="depth">how many ply to search</param>
        /// <param name="lineOut">output PV</param>
        /// <returns></returns>
        protected utility_t NegaMax(int depth, List<bitboard_t> lineOut)
        {
            List<bitboard_t> line = new List<bitboard_t>();
            utility_t best = -Infinity();

            // If we reached the end state, get the evaluation
            // of the position
            if (depth == 0 || EndState())
            {
                return Evaluate(true);
            }

            // Get a list of legal moves
            List<bitboard_t> moves = new List<bitboard_t>();
            GenerateMoves(moves);

            // If we Assert() here, either EndState() is broken, or 
            // GenerateMoves() is broken!
            System.Diagnostics.Debug.Assert(moves.Count != 0);

            // Iterate over all moves
            foreach (bitboard_t m in moves)
            {
                MakeMove(m);
                utility_t val = -NegaMax(depth - 1, line);
                UnMakeMove(m);

                if (val > best)
                {
                    best = val;

                    // save the move in the line
                    lineOut.Clear();
                    lineOut.Add(m);
                    lineOut.InsertRange(1, line);
                }
            }
            return best;
        }

        /// <summary>
        /// The alpha-beta search algorithm
        /// </summary>
        /// <param name="depth">how many ply to search</param>
        /// <param name="alpha">the alpha score</param>
        /// <param name="beta">the beta score</param>
        /// <param name="lineOut">output PV</param>
        /// <returns></returns>
        protected utility_t AlphaBeta(int depth, utility_t alpha, utility_t beta, List<bitboard_t> lineOut)
        {
            List<bitboard_t> line = new List<bitboard_t>();

            // If we reached the end state, get the evaluation
            // of the position
            if (depth == 0 || EndState())
            {
                return Evaluate(false);
            }

            // Get a list of legal moves
            List<bitboard_t> moves = new List<bitboard_t>();
            GenerateMoves(moves);

            // If we Assert() here, either EndState() is broken, or 
            // GenerateMoves() is broken!
            System.Diagnostics.Debug.Assert(moves.Count != 0);

            // Iterate over all moves
            foreach (bitboard_t m in moves)
            {
                MakeMove(m);
                utility_t val = -AlphaBeta(depth - 1, -beta, -alpha, line);
                UnMakeMove(m);

                if (val >= beta)
                {
                    return beta;
                }
                if (val > alpha)
                {
                    alpha = val;

                    // save the move in the line
                    lineOut.Clear();
                    lineOut.Add(m);
                    lineOut.InsertRange(1, line);
                }
            }
            return alpha;
        }

        /// <summary>
        /// The negascout search algorithm
        /// </summary>
        /// <param name="depth">how many ply to search</param>
        /// <param name="alpha">the alpha score</param>
        /// <param name="beta">the beta score</param>
        /// <param name="lineOut">output PV</param>
        /// <returns></returns>
        protected utility_t NegaScout(int depth, utility_t alpha, utility_t beta, List<bitboard_t> lineOut)
        {
            List<bitboard_t> line = new List<bitboard_t>();
            bool pvFound = false;
            utility_t val;

            // If we reached the end state, get the evaluation
            // of the position
            if (depth == 0 || EndState())
            {
                return Evaluate(false);
            }

            // Get a list of legal moves
            List<bitboard_t> moves = new List<bitboard_t>();
            GenerateMoves(moves);

            // If we Assert() here, either EndState() is broken, or 
            // GenerateMoves() is broken!
            //System.Diagnostics.Debug.Assert(moves.Count != 0);

            // Iterate over all moves
            foreach (bitboard_t m in moves)
            {
                MakeMove(m);
                if (pvFound) {
                    val = -NegaScout(depth - 1, -alpha - .005, -alpha, line);

                    if ((val > alpha) && (val < beta))
                    {
                        line.Clear();
                        val = -NegaScout(depth - 1, -beta, -alpha, line);
                    }
                }
                else {
                    val = -NegaScout(depth - 1, -beta, -alpha, line);
                }
                UnMakeMove(m);

                if (val >= beta)
                {
                    return beta;
                }
                if (val > alpha)
                {
                    alpha = val;
                    pvFound = true;

                    // save the move in the line
                    lineOut.Clear();
                    lineOut.Add(m);
                    lineOut.InsertRange(1, line);
                }
            }
            return alpha;
        }
        # endregion

        # region Public Methods
        /// <summary>
        /// Check if Min has a won game
        /// </summary>
        /// <returns></returns>
        public bool MinWins()
        {
            // each winboard represents a four-in-a-row win. We check
            // for a match here
            foreach (bitboard_t bb in winboards)
            {
                if ((bb & min_) == bb)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check if Max has a won game
        /// </summary>
        /// <returns></returns>
        public bool MaxWins()
        {
            // each winboard represents a four-in-a-row win. We check
            // for a match here
            foreach (bitboard_t bb in winboards)
            {
                if ((bb & max_) == bb)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Check for any end-state condition
        /// </summary>
        /// <returns></returns>
        public bool EndState()
        {
            if (MaxWins() || MinWins() || BoardFilled()) return true;

            return false;
        }

        /// <summary>
        /// Make a move
        /// </summary>
        /// <param name="move"></param>
        public void MakeMove(String move)
        {
            bitboard_t bb;

            bb = StringToBitboard(move);

            MakeMove(bb);
        }

        /// <summary>
        /// The search algorithm
        /// </summary>
        /// <param name="line">output PV</param>
        /// <param name="depth">the number of ply to search</param>
        /// <returns></returns>
        public utility_t Search(List<String> lineOut, int depth)
        {
            List<bitboard_t> line = new List<bitboard_t>();
            utility_t alpha = -Infinity();
            utility_t beta = Infinity();
            utility_t val = 0;

            if (SideToMove() == GameState.STM.MAX)
            {
                switch (_algorithm)
                {
                    case AlgorithmType.AlphaBeta:
                        val = AlphaBeta(depth, alpha, beta, line);
                        break;
                    case AlgorithmType.NegaMax:
                        val = NegaMax(depth, line);
                        break;
                    case AlgorithmType.NegaScout:
                        val = NegaScout(depth, alpha, beta, line);
                        break;
                }
            }
            else
            {
                switch (_algorithm)
                {
                    case AlgorithmType.AlphaBeta:
                        val = -AlphaBeta(depth, alpha, beta, line);
                        break;
                    case AlgorithmType.NegaMax:
                        val = -NegaMax(depth, line);
                        break;
                    case AlgorithmType.NegaScout:
                        val = -NegaScout(depth, alpha, beta, line);
                        break;
                }
            }

            System.Diagnostics.Debug.Assert(line.Count != 0);

            // convert the bitboard list to a string list of moves
            foreach (bitboard_t b in line)
            {
                lineOut.Add(BitboardToString(b));
            }

            return val;
        }
        # endregion
    }
}
