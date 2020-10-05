using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            InitAnimation();

            GameArea.Paint += InitGame;

            Rectangle _rect1 = new Rectangle(0, 0, RedStone.Width, RedStone.Height);
            Rectangle _rect2 = new Rectangle(0, 0, BlueStone.Width, BlueStone.Height);
            Color color1 = Color.Red;
            Color color2 = Color.Blue;

            RedStone.Paint += (sender, e) => InitPaintStones(sender, e, _rect1, color1);
            BlueStone.Paint += (sender, e) => InitPaintStones(sender, e, _rect2, color2);
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            InitAnimation();
            GameArea.Paint += InitGame;
        }

        private async void InitAnimation()
        {
            // Create initial animation and randomly choose starting color
            Random _random = new Random();
            int rnd = _random.Next(0, 2);

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
                    Turn = true;
                    break;

                case 1:
                    BlueTurnLabel.BackColor = Color.Blue;
                    BlueTurn.BackColor = Color.Blue;
                    RedTurnLabel.ForeColor = Color.White;
                    RedTurnLabel.BackColor = Color.White;
                    RedTurn.BackColor = Color.White;
                    Turn = false;
                    break;
            }
        }

        private void InitGame(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Create new arrays for physical position and representation
            FetchArray = new int[(int)Rows, (int)Columns];
            CoordArray = new Rectangle[(int)Rows, (int)Columns];

            double Width = 1 / Rows * GameArea.Width;
            double Height = 1 / Columns * GameArea.Height;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    double x0 = (j) / Rows * GameArea.Width;
                    double y0 = (i) / Columns * GameArea.Width;

                    Rectangle _rect = new Rectangle((int)x0, (int)y0, (int)Width, (int)Height);
                    if (i == (int)(Rows / 2) - 1 && j == (int)(Columns / 2))
                        FetchArray[i, j] = 1;

                    else if (i == (int)(Rows / 2) && j == (int)(Columns / 2))
                        FetchArray[i, j] = 2;

                    else if (i == (int)(Rows / 2) - 1 && j == (int)(Columns / 2) - 1)
                        FetchArray[i, j] = 2;

                    else if (i == (int)(Rows / 2) && j == (int)(Columns / 2) - 1)
                        FetchArray[i, j] = 1;

                    else FetchArray[i, j] = 0;

                    CoordArray[i, j] = _rect;
                }

                double a = (i + 1) / Rows * GameArea.Width;
                double b = (i + 1) / Columns * GameArea.Width;
                using (Pen _pen = new Pen(Color.Black))
                {
                    g.DrawLine(_pen, 0, (int)a, GameArea.Width, (int)a);
                    g.DrawLine(_pen, (int)b, 0, (int)b, GameArea.Height);
                }
            }
            CountAndPaint(sender, e);
        }

        // Still needs to be done
        private void Game()
        {
            
        }

        private void InitPaintStones(object sender, PaintEventArgs e, Rectangle _rect, Color color)
        {
            using (Brush _brush = new SolidBrush(color))
                e.Graphics.FillEllipse(_brush, _rect);


        }

        private void CountAndPaint(object sender, PaintEventArgs e)
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
                            e.Graphics.FillEllipse(new SolidBrush(Color.Red), CoordArray[i, j]);
                            break;

                        // Blue
                        case 2:
                            BlueCount++;
                            e.Graphics.FillEllipse(new SolidBrush(Color.Blue), CoordArray[i, j]);
                            break;

                        // White -> Still needs to be done;
                        case 3:
                            e.Graphics.FillEllipse(new SolidBrush(Color.White), CoordArray[i, j]);
                            break;
                    }
                }
            }
            RedStoneCount.Text = RedCount.ToString() + " Stones";
            BlueStoneCount.Text = BlueCount.ToString() + " Stones";
        }
    }
}
