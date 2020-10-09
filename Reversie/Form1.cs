using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
        public double Rows = 8;
        public double Columns = 8;
        public int[,] FetchArray;
        public Rectangle[,] CoordArray;
        public bool Turn;
        public int check;

        // If you resize the screen without initialising a new game, it will give errors.
        // This is here to prevent that.
        public bool GameStarted = false;

        public Form1()
        {
            InitializeComponent();
            GameArea.Image = new Bitmap(GameArea.Width, GameArea.Height);
            ResizeEnd += ResizeScreen;
            Resize += FullScreenCheck;

            Rectangle _rect1 = new Rectangle(0, 0, RedStone.Width, RedStone.Height);
            Rectangle _rect2 = new Rectangle(0, 0, BlueStone.Width, BlueStone.Height);
            Color color1 = Color.Red;
            Color color2 = Color.Blue;

            RedStone.Paint += (sender, e) => InitPaintStones(sender, e, _rect1, color1);
            BlueStone.Paint += (sender, e) => InitPaintStones(sender, e, _rect2, color2);
        }

        // INITIALISER
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            if (!GameStarted) GameStarted = true;

            GameArea.Image.Dispose();
            GameArea.Image = new Bitmap(GameArea.Width, GameArea.Height);
            InitAnimation();
            InitFetchArray();
            InitCoordArray();
            DrawBoard();
            Count();
            PaintStones();
        }

        // UPDATER
        private void GameArea_Click(object sender, EventArgs ea)
        {
            Point RelativePos = PointToClient(Cursor.Position);
            int x = RelativePos.X - 341;
            int y = RelativePos.Y - 12;
            Point _point = new Point(x, y);

            for (int i = 0; i < CoordArray.GetLength(0); i++)
            {
                for (int j = 0; j < CoordArray.GetLength(1); j++)
                {
                    // Change to 3 if white circles are done
                    if (CoordArray[i, j].Contains(_point) && FetchArray[i, j] == 0)
                    {
                        switch (Turn)
                        {
                            case true:
                                FetchArray[i, j] = 1;
                                check = 2;
                                break;
                            case false:
                                FetchArray[i, j] = 2;
                                check = 1;
                                break;
                        }
                        Point _StonePoint = new Point(i, j);

                        ChangeTurn();
                        //
                        // Horizontals
                        Check(_StonePoint, 0, 1);
                        Check(_StonePoint, 0, -1);
                        //
                        // Vericals
                        Check(_StonePoint, -1, 0);
                        Check(_StonePoint, 1, 0);
                        //
                        // Diagonals
                        Check(_StonePoint, -1, 1);
                        Check(_StonePoint, -1, -1);
                        Check(_StonePoint, 1, -1);
                        Check(_StonePoint, 1, 1);

                        PaintStones();
                        Count();
                    }
                }
            }
        }

        // Contains ResizeScreen(), OutOfBoundsCheck() and FullScreenCheck()
        #region SCREEN RESIZE METHODS
        // <START>
        private void ResizeScreen(object sender, EventArgs e)
        {
            // Set minimal values for the size of the form
            if (ClientSize.Width < 981)
                ClientSize = new Size(981, ClientSize.Height);
            if (ClientSize.Height < 652)
                ClientSize = new Size(ClientSize.Width, 652);

            // Change sizes and locations base on new CLientSize
            NewGameButton.Location = new Point(12, ClientSize.Height - NewGameButton.Height - 12);
            SettingsButton.Location = new Point(12, ClientSize.Height - NewGameButton.Height - SettingsButton.Height - 17);
            HelpButton.Location = new Point(178, ClientSize.Height - NewGameButton.Height - HelpButton.Height - 17);
            GameArea.Size = new Size(ClientSize.Width - GameArea.Location.X - 12, ClientSize.Width - GameArea.Location.X - 12);

            // Create new bitmap
            GameArea.Image.Dispose();
            GameArea.Image = new Bitmap(GameArea.Width, GameArea.Height);

            // Update arrays and paint stones
            OutOfBoundsCheck();
            InitCoordArray();
            DrawBoard();
            PaintStones();
        }

        private void OutOfBoundsCheck()
        {
            if (GameArea.Location.Y + GameArea.Height <= ClientSize.Height)
                GameArea.Size = new Size(ClientSize.Width - GameArea.Location.X - 12, ClientSize.Width - GameArea.Location.X - 12);
            else if (GameArea.Location.X + GameArea.Width <= ClientSize.Width)
                GameArea.Size = new Size(ClientSize.Height - GameArea.Location.Y - 12, ClientSize.Height - GameArea.Location.Y - 12);
        }

        FormWindowState LastWindowState = FormWindowState.Minimized;
        private void FullScreenCheck(object sender, EventArgs e)
        {
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;
                if (WindowState == FormWindowState.Maximized)
                    ResizeScreen(sender, e);
                if (WindowState == FormWindowState.Normal)
                    ResizeScreen(sender, e);
                InitCoordArray();
                DrawBoard();
                PaintStones();
            }
        }
        // <STOP>
        #endregion

        // Contains InitAnimation(), InitCoordArray() and InitFetchArray()
        #region INITIALISATION METHODS
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

        private void InitCoordArray()
        {
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
                }
            }
        }

        private void InitFetchArray()
        {
            // Create new arrays for physical position and representation
            FetchArray = new int[(int)Columns, (int)Rows];

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {

                    if (j == (int)(Rows / 2) - 1 && i == (int)(Columns / 2))
                        FetchArray[i, j] = 1;

                    else if (j == (int)(Rows / 2) && i == (int)(Columns / 2))
                        FetchArray[i, j] = 2;

                    else if (j == (int)(Rows / 2) - 1 && i == (int)(Columns / 2) - 1)
                        FetchArray[i, j] = 2;

                    else if (j == (int)(Rows / 2) && i == (int)(Columns / 2) - 1)
                        FetchArray[i, j] = 1;

                    else FetchArray[i, j] = 0;
                }
            }
        }
        #endregion

        // Contains InitPaintStones(), DrawBoard() and PaintStones()
        #region PAINTER METHODS
        private void InitPaintStones(object sender, PaintEventArgs e, Rectangle _rect, Color color)
        {
            using (Brush _brush = new SolidBrush(color))
                e.Graphics.FillEllipse(_brush, _rect);
        }

        private void DrawBoard()
        {
            if (GameStarted)
            {
                Graphics g = Graphics.FromImage(GameArea.Image);
                for (int i = 0; i < Columns; i++)
                {
                    for (int j = 0; j < Rows; j++)
                    {
                        double a = (j + 1) / Rows * GameArea.Width;
                        double b = (i + 1) / Columns * GameArea.Height;
                        using (Pen _pen = new Pen(Color.Black))
                        {
                            g.DrawLine(_pen, 0, (int)b, GameArea.Width, (int)b);
                            g.DrawLine(_pen, (int)a, 0, (int)a, GameArea.Height);
                        }
                    }
                }
                g.Dispose();
                GameArea.Refresh();
            }
        }

        private void PaintStones()
        {
            if (GameStarted)
            {
                Graphics g = Graphics.FromImage(GameArea.Image);
                for (int i = 0; i < FetchArray.GetLength(0); i++)
                {
                    for (int j = 0; j < FetchArray.GetLength(1); j++)
                    {
                        switch (FetchArray[i, j])
                        {
                            case 1:
                                g.FillEllipse(new SolidBrush(Color.Red), CoordArray[i, j]);
                                break;
                            case 2:
                                g.FillEllipse(new SolidBrush(Color.Blue), CoordArray[i, j]);
                                break;
                                // case 3 still needs to be added (white circles)
                        }
                    }
                }

                GameArea.Refresh();
                g.Dispose();
            }
        }
        #endregion

        // Contains Check(), ChangeValues, Count() and ChangeTurn()
        #region HELPER METHODS
        private void Check(Point StonePoint, int NextX, int NextY)
        {
            int x = StonePoint.X;
            int y = StonePoint.Y;
            int counter = 0;
            double length = 0;

            if (Rows >= Columns) length = Rows;
            else if (Rows < Columns) length = Columns;

            for (int i = 0; i < length; i++)
            {
                x += NextX;
                y += NextY;

                // Check if x and y are out of bounds
                if (x < 0) break;
                if (x >= Rows) break;
                if (y < 0) break;
                if (y >= Columns) break;


                // Increment counter if another stone is founds
                if (FetchArray[x, y] == check)
                    counter++;

                // If another stone of yours is found
                else if (FetchArray[x, y] == FetchArray[StonePoint.X, StonePoint.Y])
                {
                    if (counter != 0)
                    {
                        ChangeValues(StonePoint, NextX, NextY, counter);
                        break;
                    }
                }

                // Else break out of the loop
                else break;
            }
        }

        private void ChangeValues(Point StonePoint, int NextX, int NextY, int counter)
        {
            int x = StonePoint.X;
            int y = StonePoint.Y;

            for (int i = 0; i < counter; i++)
            {
                x += NextX;
                y += NextY;

                if (FetchArray[x, y] == FetchArray[StonePoint.X, StonePoint.Y])
                    break;
                else
                    FetchArray[x, y] = FetchArray[StonePoint.X, StonePoint.Y];
            }
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
                        // Red
                        case 1:
                            RedCount++;
                            break;

                        // Blue
                        case 2:
                            BlueCount++;
                            break;
                    }
                }
            }
            RedStoneCount.Text = RedCount.ToString() + " Stones";
            BlueStoneCount.Text = BlueCount.ToString() + " Stones";
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
        #endregion
    }
}
