using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


/* POSSIBLE IDEAS
 * We need 8 checks in total:
 *      front, back, diagonals, up and down
 *      Check for the stones of the other player,
 *      backtrack => is a stone of yours in the backtracked row/column/diagonal?:
 *          set the small white circle on the next position in the row/column/diagonal
 *          if a player has placed their stone on the small white circle:
 *              backtrack and change every value you meet until you hit another stone of yours
 *
 *      
 * recursively check for colors in row
 * EXAMPLE:
 * 0 0 1 2 2 1 0
 * start at the end, and keep checking current position -1 for values
 * 
 * 
*/

namespace Reversie
{
    public partial class Form1 : Form
    {
        public double Rows = 6;
        public double Columns = 6;

        // Arrays for phisical location and representation of stones
        // 0 is no stone, 1 is red, 2 is blue and 3 is white
        public int[,] FetchArray;
        public Rectangle[,] CoordArray;

        // True if red, false if blue
        public bool Turn;

        public Form1()
        {
            InitializeComponent();

            Rectangle _rect1 = new Rectangle(0, 0, RedStone.Width, RedStone.Height);
            Rectangle _rect2 = new Rectangle(0, 0, BlueStone.Width, BlueStone.Height);
            Color color1 = Color.Red;
            Color color2 = Color.Blue;

            RedStone.Paint += (sender, e) => InitPaintStones(sender, e, _rect1, color1);
            BlueStone.Paint += (sender, e) => InitPaintStones(sender, e, _rect2, color2);
            InitGame();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            InitAnimation();
            InitGame();
        }

        private void GameArea_Click(object sender, EventArgs ea)
        {
            /*
             * Click on square => DONE!
             * Get position of that square in CoordArray => DONE!
             * Set value in FetchArray on position from CoordArray => DONE!
             * Check for stones to be flipped
             * Change those values in array (don't know how yet)
            */
            Point RelativePos = PointToClient(Cursor.Position);
            int x = RelativePos.X - 341;
            int y = RelativePos.Y - 12;
            Point _point = new Point(x, y);
            
            for (int i = 0; i < CoordArray.GetLength(0); i++)
            {
                for (int j = 0; j < CoordArray.GetLength(1); j++)
                {
                    if (CoordArray[i, j].Contains(_point) && !new[] { 1, 2 }.Contains(FetchArray[i, j]))
                    {
                        switch (Turn)
                        {
                            case true:
                                FetchArray[i, j] = 1;
                                break;
                            case false:
                                FetchArray[i, j] = 2;
                                break;
                        }
                        PaintStones(CoordArray[i, j]);
                        ChangeTurn();
                    }
                }
            }

            
        }

        // TODO: Stop this function if it is initialised again
        private async void InitAnimation()
        {
            // Create initial animation and randomly choose starting color
            Random _random = new Random();
            int rnd = _random.Next(0, 2);

            if (rnd == 1) Turn = false;
            else Turn = true;

            int delay = 100;
            for (int i = 0; i < 25; i++)
            {
                switch (i % 2)
                {
                    case 0:
                        RedTurnLabel.BackColor = Color.Red;
                        RedTurn.BackColor = Color.Red;
                        BlueTurnLabel.ForeColor = Color.White;
                        BlueTurnLabel.BackColor = Color.White;
                        BlueTurn.BackColor = Color.White;
                        break;

                    case 1:
                        BlueTurnLabel.BackColor = Color.Blue;
                        BlueTurn.BackColor = Color.Blue;
                        RedTurnLabel.ForeColor = Color.White;
                        RedTurnLabel.BackColor = Color.White;
                        RedTurn.BackColor = Color.White;
                        break;
                }
                await Task.Delay(delay);
                delay += 10;
            }

            switch (rnd)
            {
                case 0:
                    RedTurnLabel.BackColor = Color.Red;
                    RedTurn.BackColor = Color.Red;
                    BlueTurnLabel.ForeColor = Color.White;
                    BlueTurnLabel.BackColor = Color.White;
                    BlueTurn.BackColor = Color.White;
                    break;

                case 1:
                    BlueTurnLabel.BackColor = Color.Blue;
                    BlueTurn.BackColor = Color.Blue;
                    RedTurnLabel.ForeColor = Color.White;
                    RedTurnLabel.BackColor = Color.White;
                    RedTurn.BackColor = Color.White;
                    break;
            }
        }

        private void InitGame()
        {
            GameArea.Image = new Bitmap(GameArea.Width, GameArea.Height);
            Graphics g = Graphics.FromImage(GameArea.Image);
            
            // Create new arrays for physical position and representation
            FetchArray = new int[(int)Columns, (int)Rows];
            CoordArray = new Rectangle[(int)Columns, (int)Rows];

            double Width = 1 / Rows * GameArea.Width;
            double Height = 1 / Columns * GameArea.Height;

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    double x0 = j / Rows * GameArea.Width;
                    double y0 = i / Columns * GameArea.Height;

                    Rectangle _rect = new Rectangle((int)x0, (int)y0, (int)Width, (int)Height);
                    CoordArray[i, j] = _rect;

                    // Red is 1, blue is 2, white is 3
                    if (j == (int)(Rows / 2) - 1 && i == (int)(Columns / 2))
                    {
                        FetchArray[i, j] = 1;
                        g.FillEllipse(new SolidBrush(Color.Red), CoordArray[i, j]);
                    }

                    else if (j == (int)(Rows / 2) && i == (int)(Columns / 2))
                    {
                        FetchArray[i, j] = 2;
                        g.FillEllipse(new SolidBrush(Color.Blue), CoordArray[i, j]);
                    }

                    else if (j == (int)(Rows / 2) - 1 && i == (int)(Columns / 2) - 1)
                    {
                        FetchArray[i, j] = 2;
                        g.FillEllipse(new SolidBrush(Color.Blue), CoordArray[i, j]);
                    }

                    else if (j == (int)(Rows / 2) && i == (int)(Columns / 2) - 1)
                    {
                        FetchArray[i, j] = 1;
                        g.FillEllipse(new SolidBrush(Color.Red), CoordArray[i, j]);
                    }

                    else FetchArray[i, j] = 0;

                    double a = (j + 1) / Rows * GameArea.Width;
                    double b = (i + 1) / Columns * GameArea.Height;
                    using (Pen _pen = new Pen(Color.Black))
                    {
                        g.DrawLine(_pen, 0, (int)b, GameArea.Width, (int)b);
                        g.DrawLine(_pen, (int)a, 0, (int)a, GameArea.Height);
                    }
                }
            }

            switch (Turn)
            {
                case true:
                    CheckStone(2);
                    break;
                case false:
                    CheckStone(1);
                    break;
            }

            Count();
            GameArea.Refresh();
            g.Dispose();
        }

        private void InitPaintStones(object sender, PaintEventArgs e, Rectangle _rect, Color color)
        {
            using (Brush _brush = new SolidBrush(color))
                e.Graphics.FillEllipse(_brush, _rect);
        }

        private void CheckStone(int check)
        {
            /*
             *We need 8 checks in total:
             *front, back, diagonals, up and down
             * Check for the stones of the other player,
             *backtrack => is a stone of yours in the backtracked row / column / diagonal ?:
             *set the small white circle on the next position in the row / column / diagonal
             *          if a player has placed their stone on the small white circle:
             *backtrack and change every value you meet until you hit another stone of yours
             *
             */
            /*
            for (int i = 0; i < FetchArray.GetLength(0); i++)
            {
                for (int j = 0; j < FetchArray.GetLength(1); i++)
                {
                    if (FetchArray[i, j] == check)
                    {

                    }
                }
            }
            */
        }

        private void Count()
        {
            int RedCount = 0;
            int BlueCount = 0;
            for (int i = 0; i < FetchArray.GetLength(0); i++)
            {
                for (int j = 0; j < FetchArray.GetLength(1); j++)
                {
                    switch (FetchArray[i, j])
                    {
                        // if there are no stones
                        case 0:
                            break;

                        // Red
                        case 1:
                            RedCount++;
                            break;

                        // Blue
                        case 2:
                            BlueCount++;
                            break;

                        // White -> Still needs to be done;
                        case 3:
                            break;
                    }
                }
            }
            RedStoneCount.Text = RedCount.ToString() + " Stones";
            BlueStoneCount.Text = BlueCount.ToString() + " Stones";
        }

        private void PaintStones(Rectangle rect)
        {
            Graphics g = Graphics.FromImage(GameArea.Image);

            switch (Turn)
            {
                case true:
                    g.FillEllipse(new SolidBrush(Color.Red), rect);
                    break;
                case false:
                    g.FillEllipse(new SolidBrush(Color.Blue), rect);
                    break;
            }
            GameArea.Refresh();
            g.Dispose();
        }

        private void ChangeTurn()
        {
            Turn = !Turn;
            switch (Turn)
            {
                case true:
                    RedTurnLabel.BackColor = Color.Red;
                    RedTurn.BackColor = Color.Red;
                    BlueTurnLabel.ForeColor = Color.White;
                    BlueTurnLabel.BackColor = Color.White;
                    BlueTurn.BackColor = Color.White;
                    break;

                case false:
                    BlueTurnLabel.BackColor = Color.Blue;
                    BlueTurn.BackColor = Color.Blue;
                    RedTurnLabel.ForeColor = Color.White;
                    RedTurnLabel.BackColor = Color.White;
                    RedTurn.BackColor = Color.White;
                    break;
            }
        }
    }
}
