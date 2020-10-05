using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversie
{
    public partial class Form1 : Form
    {
        readonly double MaxTiles = 6;


        public Form1()
        {
            InitializeComponent();
            InitAnimation();
            GameArea.Paint += InitGame;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            InitAnimation();
        }

        private async void InitAnimation()
        {
            StatusLabel.Text = "Initialising...";
            StatusLabel.Refresh();

            // Create initial animation and randomly choose starting color
            Random _random = new Random();
            int rnd = _random.Next(0, 2);
            for (int i = 0; i < 15; i++)
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
                await Task.Delay(100);
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
            StatusLabel.Text = "";
            StatusLabel.Refresh();
        }

        private void InitGame(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 1; i <= MaxTiles; i++)
            {
                double a = i / MaxTiles * GameArea.Width;
                using (Pen _pen = new Pen(Color.Black))
                {
                    g.DrawLine(_pen, 0, (int)a, GameArea.Width, (int)a);
                    g.DrawLine(_pen, (int)a, 0, (int)a, GameArea.Height);
                }
            }
        }

        private void Game()
        {
            
        }
    }
}
