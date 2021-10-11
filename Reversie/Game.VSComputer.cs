using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Reversie
{
    public partial class Game
    {
        public void Computer()
        {
            DetermineMove();
        }

        private async void DetermineMove()
        {
            await Task.Delay(ComputerDelay);
            int CombinedGain;
            List<int?> PossibleGain = new List<int?>();
            List<Point> PossiblePoints = new List<Point>();

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (BoardArray[i, j] == 3)
                    {
                        Point StonePoint = new Point(i, j);
                        List<int?> CheckList = new List<int?>()
                        {
                            // Horizontals
                            Check(StonePoint, 0, 1, "check"),
                            Check(StonePoint, 0, -1, "check"),
                            //
                            // Vericals
                            Check(StonePoint, -1, 0, "check"),
                            Check(StonePoint, 1, 0, "check"),
                            //
                            // Diagonals
                            Check(StonePoint, -1, 1, "check"),
                            Check(StonePoint, -1, -1, "check"),
                            Check(StonePoint, 1, -1, "check"),
                            Check(StonePoint, 1, 1, "check"),
                        };

                        CombinedGain = (int)CheckList.Sum();
                        PossibleGain.Add(CombinedGain);
                        PossiblePoints.Add(StonePoint);
                    }
                }
            }

            if (TurnAvailableBlue)
            {
                int IndexBestMove = default;

                // Get best move
                if (DifficultyComputer == "Hard")
                {
                    // if there is only one move possible
                    if (PossibleGain.Count == 1)
                        IndexBestMove = 0;
                     // Get move that results in the max ammount of stones turned
                    else IndexBestMove = PossibleGain.IndexOf(PossibleGain.Max());

                    // If a corner turn is possible, take it
                    foreach (Point point in PossiblePoints)
                        if ((point.X == 0 && point.Y == 0) ||
                            (point.X == 0 && point.Y == Columns - 1) ||
                            (point.X == Rows - 1 && point.Y == 0) ||
                            (point.X == Rows - 1 && point.Y == Columns - 1))
                            IndexBestMove = PossiblePoints.IndexOf(point);
                }

                // Get second best move
                else if (DifficultyComputer == "Easy")
                    if (PossibleGain.Count == 1)
                        IndexBestMove = 0;
                    else IndexBestMove = PossibleGain.IndexOf(PossibleGain.OrderByDescending(z => z).Skip(1).First());

                Point BestMove = PossiblePoints[IndexBestMove];
                BoardArray[BestMove.X, BestMove.Y] = 2;
                //
                // Horizontals
                Check(BestMove, 0, 1, null);
                Check(BestMove, 0, -1, null);
                //
                // Vericals
                Check(BestMove, -1, 0, null);
                Check(BestMove, 1, 0, null);
                //
                // Diagonals
                Check(BestMove, -1, 1, null);
                Check(BestMove, -1, -1, null);
                Check(BestMove, 1, -1, null);
                Check(BestMove, 1, 1, null);
                //
                ChangeTurn();
                CheckPossibleMoves();
                Count();
                PaintStones();
            }
            else PassButtonClick(null, null);
        }
    }
}
