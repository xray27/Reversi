using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversie
{
    public partial class Game : Form
    {
        // Global variables
        public int[,] BoardArray;
        public Rectangle[,] CoordArray;
        public bool Turn;
        public bool Help = false;
        public int check;
        public int current;
        public bool BoardInitialised = false;
        public bool TurnAvailableRed = true;
        public bool TurnAvailableBlue = true;
        public bool GameStarted = false;
        public int ComputerTurn = 2;

        // In settings configurable
        public bool PlayVSComputer;
        public int ComputerDelay;
        public string DifficultyComputer;
        public double Rows = 6;
        public double Columns = 6;

        public Game()
        {
            InitializeComponent();
            RedStone.BackColor = Color.Transparent;
            RedStoneCount.BackColor = Color.Transparent;
            BlueStone.BackColor = Color.Transparent;
            BlueStoneCount.BackColor = Color.Transparent;
            WinnerArea.BackColor = Color.Transparent;

            GameArea.Image = new Bitmap(GameArea.Width, GameArea.Height);
            ResizeEnd += ResizeScreen;
            Resize += FullScreenCheck;

            Rectangle rect1 = new Rectangle(0, 0, RedStone.Width, RedStone.Height);
            Rectangle rect2 = new Rectangle(0, 0, BlueStone.Width, BlueStone.Height);

            RedStone.Paint += (sender, e) => InitPaintStones(sender, e, rect1, Color.Red);
            BlueStone.Paint += (sender, e) => InitPaintStones(sender, e, rect2, Color.Blue);
            Paint += (sender, e) => PaintForm(sender, e, Color.Purple);
        }


        #region BUTTON-FUNCTIONALITY METHODS
        private void GameAreaClick(object sender, EventArgs ea)
        {
            if (BoardInitialised)
            {
                if ((PlayVSComputer && ComputerTurn != current) || !PlayVSComputer)
                {
                    Point RelativePos = PointToClient(Cursor.Position);
                    int x = RelativePos.X - 341;
                    int y = RelativePos.Y - 12;
                    Point point = new Point(x, y);

                    // Change value in BoardArray
                    for (int i = 0; i < CoordArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < CoordArray.GetLength(1); j++)
                        {
                            if (CoordArray[i, j].Contains(point) && BoardArray[i, j] == 3)
                            {
                                switch (Turn)
                                {
                                    case true:
                                        BoardArray[i, j] = 1;
                                        break;
                                    case false:
                                        BoardArray[i, j] = 2;
                                        break;
                                }

                                Point StonePoint = new Point(i, j);
                                //
                                // Horizontals
                                Check(StonePoint, 0, 1, null);
                                Check(StonePoint, 0, -1, null);
                                //
                                // Vericals
                                Check(StonePoint, -1, 0, null);
                                Check(StonePoint, 1, 0, null);
                                //
                                // Diagonals
                                Check(StonePoint, -1, 1, null);
                                Check(StonePoint, -1, -1, null);
                                Check(StonePoint, 1, -1, null);
                                Check(StonePoint, 1, 1, null);

                                ChangeTurn();
                                CheckPossibleMoves();
                                Count();
                                PaintStones();

                            }
                        }
                    }
                }

                if (PlayVSComputer && ComputerTurn == current)
                    Computer();
            }
        }

        public void NewGameButtonClick(object sender, EventArgs e)
        {
            Settings settings = new Settings(this);
            settings.Show();
        }

        private void HelpButtonClick(object sender, EventArgs e)
        {
            if (GameStarted)
            {
                Help = !Help;
                PaintStones();
            }
        }

        private void PassButtonClick(object sender, EventArgs e)
        {
            // Change turn
            if (GameStarted)
            {
                ChangeTurn();
                CheckPossibleMoves();
                Count();
                PaintStones();
                if (PlayVSComputer && ComputerTurn == current)
                    Computer();
            }
        }
        #endregion


        #region SCREEN RESIZE METHODS
        private void ResizeScreen(object sender, EventArgs e)
        {
            // Set minimal values for the size of the form
            if (ClientSize.Width < 981)
                ClientSize = new Size(981, ClientSize.Height);
            if (ClientSize.Height < 652)
                ClientSize = new Size(ClientSize.Width, 652);

            // Change sizes and locations base on new CLientSize
            NewGameButton.Location = new Point(12, ClientSize.Height - NewGameButton.Height - 12);
            HelpButton.Location = new Point(12, ClientSize.Height - NewGameButton.Height - HelpButton.Height - 17);
            GameArea.Size = new Size(ClientSize.Width - GameArea.Location.X - 12, ClientSize.Width - GameArea.Location.X - 12);

            // Create new bitmap
            GameArea.Image.Dispose();
            GameArea.Image = new Bitmap(GameArea.Width, GameArea.Height);

            // Update arrays and paint stones
            OutOfBoundsCheck();
            InitCoordArray();
            DrawBoard();
            PaintStones();
            Invalidate();
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
                Invalidate();
            }
        }
        #endregion


        #region INITIALISATION METHODS
        private async void InitAnimation()
        {
            int rnd = 0;
            Paint += (sender, e) => PaintForm(sender, e, Color.Purple);
            Invalidate();

            if (!PlayVSComputer)
            {
                // Create initial animation and randomly choose starting color
                Random random = new Random();
                rnd = random.Next(0, 2);

                if (rnd == 1) Turn = false;
                else Turn = true;
            }

            else Turn = true;

            // Animation
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

            // Check who can start
            switch (rnd)
            {
                case 0:
                    current = 1;
                    check = 2;
                    RedTurnLabel.BackColor = Color.Red;
                    RedTurn.BackColor = Color.Red;
                    BlueTurnLabel.ForeColor = Color.White;
                    BlueTurnLabel.BackColor = Color.White;
                    BlueTurn.BackColor = Color.White;
                    Paint += (sender, e) => PaintForm(sender, e, Color.Red);
                    break;

                case 1:
                    current = 2;
                    check = 1;
                    BlueTurnLabel.BackColor = Color.Blue;
                    BlueTurn.BackColor = Color.Blue;
                    RedTurnLabel.ForeColor = Color.White;
                    RedTurnLabel.BackColor = Color.White;
                    RedTurn.BackColor = Color.White;
                    Paint += (sender, e) => PaintForm(sender, e, Color.Blue);
                    break;
            }
            Invalidate();
            CheckPossibleMoves();
            PaintStones();
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

                    Rectangle rect = new Rectangle((int)x0, (int)y0, (int)Width, (int)Height);
                    CoordArray[i, j] = rect;
                }
            }
        }

        private void InitBoardArray()
        {
            // Create new arrays for physical position and representation
            BoardArray = new int[(int)Columns, (int)Rows];

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    // Set stones in the middle
                    if (j == (int)(Rows / 2) - 1 && i == (int)(Columns / 2))
                        BoardArray[i, j] = 1;

                    else if (j == (int)(Rows / 2) && i == (int)(Columns / 2))
                        BoardArray[i, j] = 2;

                    else if (j == (int)(Rows / 2) - 1 && i == (int)(Columns / 2) - 1)
                        BoardArray[i, j] = 2;

                    else if (j == (int)(Rows / 2) && i == (int)(Columns / 2) - 1)
                        BoardArray[i, j] = 1;

                    else BoardArray[i, j] = 0;
                }
            }
        }
        #endregion


        #region PAINTER METHODS
        public void NewGame()
        {
            if (!GameStarted) GameStarted = true;
            if (!BoardInitialised) BoardInitialised = true;
            GameArea.Image.Dispose();
            GameArea.Image = new Bitmap(GameArea.Width, GameArea.Height);
            WinnerArea.BackColor = Color.Transparent;
            WinnerArea.BorderStyle = BorderStyle.None;
            WinnerLabel.Text = null;
            TurnAvailableRed = true;
            TurnAvailableBlue = true;

            InitAnimation();
            InitBoardArray();
            InitCoordArray();
            ChangeCheck();
            DrawBoard();
            Count();
            PaintStones();
        }

        private void InitPaintStones(object sender, PaintEventArgs e, Rectangle rect, Color color)
        {
            using (Brush brush = new SolidBrush(color))
                e.Graphics.FillEllipse(brush, rect);
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

                        using (Pen pen = new Pen(Color.Black))
                        {
                            g.DrawLine(pen, 0, (int)b, GameArea.Width, (int)b);
                            g.DrawLine(pen, (int)a, 0, (int)a, GameArea.Height);
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
                for (int i = 0; i < BoardArray.GetLength(0); i++)
                {
                    for (int j = 0; j < BoardArray.GetLength(1); j++)
                    {
                        float width = CoordArray[i, j].Width * 0.5f;
                        float height = CoordArray[i, j].Height * 0.5f;
                        float x = CoordArray[i, j].X + width * 0.5f;
                        float y = CoordArray[i, j].Y + height * 0.5f;
                        switch (BoardArray[i, j])
                        {
                            case 0:
                                g.DrawEllipse(new Pen(Color.White), x, y, width, height);
                                break;
                            case 1:
                                g.FillEllipse(new SolidBrush(Color.Red), CoordArray[i, j]);
                                break;
                            case 2:
                                g.FillEllipse(new SolidBrush(Color.Blue), CoordArray[i, j]);
                                break;
                            case 3:
                                if (Help) g.DrawEllipse(new Pen(Color.Black), x, y, width, height);
                                else g.DrawEllipse(new Pen(Color.White), x, y, width, height);
                                break;
                        }
                    }
                }
                g.Dispose();
                GameArea.Refresh();
            }
        }

        private void PaintForm(object sender, PaintEventArgs e, Color color)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.White, color, 0f))
                e.Graphics.FillRectangle(brush, ClientRectangle);
        }
        #endregion


        #region HELPER METHODS
        private int? Check(Point StonePoint, int NextX, int NextY, string str)
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
                if (x < 0 || x >= Rows || y < 0 || y >= Columns) break;

                // Increment counter if another stone is founds
                if (BoardArray[x, y] == current)
                {
                    if (counter != 0)
                    {
                        if (str == null)
                            ChangeValues(StonePoint, NextX, NextY, counter);
                        else return counter;
                    }
                }

                if (BoardArray[x, y] == check)
                    counter++;
                else return null;
            }
            return null;
        }

        private void CheckPossibleMoves()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    if (BoardArray[i, j] == 3)
                        BoardArray[i, j] = 0;
                    if (BoardArray[i, j] == 0)
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
                        if (CheckList.Any(k => k != null))
                            BoardArray[i, j] = 3;
                    }
                }
            }
        }

        private void CheckIfTurnPossible(int RedCount, int BlueCount)
        {
            int check = default;

            // If there is a 3 in BoardArray, a move is possible
            switch (current)
            {
                case 1:
                    for (int i = 0; i < Columns; i++)
                    {
                        for (int j = 0; j < Rows; j++)
                        {
                            if (BoardArray[i, j] == 3)
                            {
                                check = 1;
                                break;
                            }
                        }
                    }
                    if (check == default)
                        TurnAvailableRed = false;
                    else TurnAvailableRed = true;
                    break;

                case 2:
                    for (int i = 0; i < Columns; i++)
                    {
                        for (int j = 0; j < Rows; j++)
                        {
                            if (BoardArray[i, j] == 3)
                            {
                                check = 1;
                                break;
                            }

                        }
                    }
                    if (check == default)
                        TurnAvailableBlue = false;
                    else TurnAvailableBlue = true;
                    break;
            }

            // if no turn is possible
            if (!TurnAvailableRed && !TurnAvailableBlue)
            {
                if (RedCount == BlueCount)
                {
                    WinnerArea.BackColor = Color.Purple;
                    WinnerArea.BorderStyle = BorderStyle.FixedSingle;
                    WinnerLabel.BackColor = Color.Purple;
                    WinnerLabel.ForeColor = Color.White;
                    Paint += (sender, e) => PaintForm(sender, e, Color.Purple);
                    WinnerLabel.Text = "It's a draw!";
                }

                else
                {
                    switch (RedCount > BlueCount)
                    {
                        case false:
                            WinnerArea.BackColor = Color.Blue;
                            WinnerArea.BorderStyle = BorderStyle.FixedSingle;
                            WinnerLabel.BackColor = Color.Blue;
                            WinnerLabel.ForeColor = Color.White;
                            Paint += (sender, e) => PaintForm(sender, e, Color.Blue);
                            WinnerLabel.Text = "Blue is the winner!";
                            break;
                        case true:
                            WinnerArea.BackColor = Color.Red;
                            WinnerArea.BorderStyle = BorderStyle.FixedSingle;
                            WinnerLabel.BackColor = Color.Red;
                            WinnerLabel.ForeColor = Color.White;
                            Paint += (sender, e) => PaintForm(sender, e, Color.Red);
                            WinnerLabel.Text = "Red is the winner!";
                            break;
                    }
                }
                Invalidate();
                WinnerArea.Location = new Point(12, ClientSize.Height / 2 - (WinnerArea.Width / 7));
                WinnerLabel.Location = new Point(12 + WinnerArea.Width / 2 - WinnerLabel.Width / 2, ClientSize.Height / 2 - (WinnerArea.Width / 7) + WinnerArea.Height / 2 - WinnerLabel.Height / 2);
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

                BoardArray[x, y] = BoardArray[StonePoint.X, StonePoint.Y];
            }
        }

        private void Count()
        {
            int RedCount = 0;
            int BlueCount = 0;
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    switch (BoardArray[i, j])
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
            CheckIfTurnPossible(RedCount, BlueCount);
        }

        private void ChangeCheck()
        {
            switch (Turn)
            {
                case true:
                    check = 2;
                    current = 1;
                    break;
                case false:
                    check = 1;
                    current = 2;
                    break;
            }
        }

        private void ChangeTurn()
        {
            Turn = !Turn;
            switch (Turn)
            {
                case true:
                    Paint += (sender, e) => PaintForm(sender, e, Color.Red);
                    RedTurnLabel.BackColor = Color.Red;
                    RedTurn.BackColor = Color.Red;
                    BlueTurnLabel.ForeColor = Color.White;
                    BlueTurnLabel.BackColor = Color.White;
                    BlueTurn.BackColor = Color.White;
                    break;

                case false:
                    Paint += (sender, e) => PaintForm(sender, e, Color.Blue);
                    BlueTurnLabel.BackColor = Color.Blue;
                    BlueTurn.BackColor = Color.Blue;
                    RedTurnLabel.ForeColor = Color.White;
                    RedTurnLabel.BackColor = Color.White;
                    RedTurn.BackColor = Color.White;
                    break;
            }
            Invalidate();
            ChangeCheck();
        }
        #endregion
    }
}
