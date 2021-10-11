using System.Windows.Forms;

namespace Reversie
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameArea = new System.Windows.Forms.PictureBox();
            this.RedTurn = new System.Windows.Forms.PictureBox();
            this.BlueTurn = new System.Windows.Forms.PictureBox();
            this.RedTurnLabel = new System.Windows.Forms.Label();
            this.BlueTurnLabel = new System.Windows.Forms.Label();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.RedStone = new System.Windows.Forms.PictureBox();
            this.BlueStone = new System.Windows.Forms.PictureBox();
            this.RedStoneCount = new System.Windows.Forms.Label();
            this.BlueStoneCount = new System.Windows.Forms.Label();
            this.WinnerArea = new System.Windows.Forms.PictureBox();
            this.WinnerLabel = new System.Windows.Forms.Label();
            this.PassButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedStone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueStone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinnerArea)).BeginInit();
            this.SuspendLayout();
            // 
            // GameArea
            // 
            this.GameArea.BackColor = System.Drawing.Color.White;
            this.GameArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameArea.Location = new System.Drawing.Point(455, 15);
            this.GameArea.Margin = new System.Windows.Forms.Padding(4);
            this.GameArea.Name = "GameArea";
            this.GameArea.Size = new System.Drawing.Size(837, 772);
            this.GameArea.TabIndex = 0;
            this.GameArea.TabStop = false;
            this.GameArea.Click += new System.EventHandler(this.GameAreaClick);
            // 
            // RedTurn
            // 
            this.RedTurn.BackColor = System.Drawing.Color.White;
            this.RedTurn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RedTurn.Location = new System.Drawing.Point(17, 15);
            this.RedTurn.Margin = new System.Windows.Forms.Padding(4);
            this.RedTurn.Name = "RedTurn";
            this.RedTurn.Size = new System.Drawing.Size(199, 61);
            this.RedTurn.TabIndex = 1;
            this.RedTurn.TabStop = false;
            // 
            // BlueTurn
            // 
            this.BlueTurn.BackColor = System.Drawing.Color.White;
            this.BlueTurn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlueTurn.Location = new System.Drawing.Point(237, 15);
            this.BlueTurn.Margin = new System.Windows.Forms.Padding(4);
            this.BlueTurn.Name = "BlueTurn";
            this.BlueTurn.Size = new System.Drawing.Size(199, 61);
            this.BlueTurn.TabIndex = 2;
            this.BlueTurn.TabStop = false;
            // 
            // RedTurnLabel
            // 
            this.RedTurnLabel.AutoSize = true;
            this.RedTurnLabel.BackColor = System.Drawing.Color.White;
            this.RedTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedTurnLabel.ForeColor = System.Drawing.Color.White;
            this.RedTurnLabel.Location = new System.Drawing.Point(56, 31);
            this.RedTurnLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RedTurnLabel.Name = "RedTurnLabel";
            this.RedTurnLabel.Size = new System.Drawing.Size(114, 29);
            this.RedTurnLabel.TabIndex = 3;
            this.RedTurnLabel.Text = "Red Turn";
            // 
            // BlueTurnLabel
            // 
            this.BlueTurnLabel.AutoSize = true;
            this.BlueTurnLabel.BackColor = System.Drawing.Color.White;
            this.BlueTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueTurnLabel.ForeColor = System.Drawing.Color.White;
            this.BlueTurnLabel.Location = new System.Drawing.Point(279, 31);
            this.BlueTurnLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BlueTurnLabel.Name = "BlueTurnLabel";
            this.BlueTurnLabel.Size = new System.Drawing.Size(118, 29);
            this.BlueTurnLabel.TabIndex = 4;
            this.BlueTurnLabel.Text = "Blue Turn";
            // 
            // NewGameButton
            // 
            this.NewGameButton.BackColor = System.Drawing.Color.White;
            this.NewGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGameButton.Location = new System.Drawing.Point(16, 673);
            this.NewGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(421, 114);
            this.NewGameButton.TabIndex = 5;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButtonClick);
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.White;
            this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.Location = new System.Drawing.Point(16, 610);
            this.HelpButton.Margin = new System.Windows.Forms.Padding(4);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(421, 55);
            this.HelpButton.TabIndex = 8;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = false;
            this.HelpButton.Click += new System.EventHandler(this.HelpButtonClick);
            // 
            // RedStone
            // 
            this.RedStone.Location = new System.Drawing.Point(43, 129);
            this.RedStone.Margin = new System.Windows.Forms.Padding(4);
            this.RedStone.Name = "RedStone";
            this.RedStone.Size = new System.Drawing.Size(133, 123);
            this.RedStone.TabIndex = 9;
            this.RedStone.TabStop = false;
            // 
            // BlueStone
            // 
            this.BlueStone.Location = new System.Drawing.Point(269, 129);
            this.BlueStone.Margin = new System.Windows.Forms.Padding(4);
            this.BlueStone.Name = "BlueStone";
            this.BlueStone.Size = new System.Drawing.Size(133, 123);
            this.BlueStone.TabIndex = 10;
            this.BlueStone.TabStop = false;
            // 
            // RedStoneCount
            // 
            this.RedStoneCount.AutoSize = true;
            this.RedStoneCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedStoneCount.ForeColor = System.Drawing.Color.Red;
            this.RedStoneCount.Location = new System.Drawing.Point(56, 261);
            this.RedStoneCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RedStoneCount.Name = "RedStoneCount";
            this.RedStoneCount.Size = new System.Drawing.Size(90, 25);
            this.RedStoneCount.TabIndex = 11;
            this.RedStoneCount.Text = "0 Stones";
            // 
            // BlueStoneCount
            // 
            this.BlueStoneCount.AutoSize = true;
            this.BlueStoneCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueStoneCount.ForeColor = System.Drawing.Color.Blue;
            this.BlueStoneCount.Location = new System.Drawing.Point(279, 261);
            this.BlueStoneCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BlueStoneCount.Name = "BlueStoneCount";
            this.BlueStoneCount.Size = new System.Drawing.Size(90, 25);
            this.BlueStoneCount.TabIndex = 12;
            this.BlueStoneCount.Text = "0 Stones";
            // 
            // WinnerArea
            // 
            this.WinnerArea.BackColor = System.Drawing.SystemColors.Control;
            this.WinnerArea.Location = new System.Drawing.Point(17, 345);
            this.WinnerArea.Margin = new System.Windows.Forms.Padding(4);
            this.WinnerArea.Name = "WinnerArea";
            this.WinnerArea.Size = new System.Drawing.Size(421, 183);
            this.WinnerArea.TabIndex = 13;
            this.WinnerArea.TabStop = false;
            // 
            // WinnerLabel
            // 
            this.WinnerLabel.AutoSize = true;
            this.WinnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinnerLabel.Location = new System.Drawing.Point(123, 427);
            this.WinnerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WinnerLabel.Name = "WinnerLabel";
            this.WinnerLabel.Size = new System.Drawing.Size(0, 25);
            this.WinnerLabel.TabIndex = 14;
            // 
            // PassButton
            // 
            this.PassButton.BackColor = System.Drawing.Color.White;
            this.PassButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassButton.Location = new System.Drawing.Point(164, 84);
            this.PassButton.Margin = new System.Windows.Forms.Padding(4);
            this.PassButton.Name = "PassButton";
            this.PassButton.Size = new System.Drawing.Size(120, 38);
            this.PassButton.TabIndex = 15;
            this.PassButton.Text = "Pass";
            this.PassButton.UseVisualStyleBackColor = false;
            this.PassButton.Click += new System.EventHandler(this.PassButtonClick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 802);
            this.Controls.Add(this.PassButton);
            this.Controls.Add(this.WinnerLabel);
            this.Controls.Add(this.WinnerArea);
            this.Controls.Add(this.BlueStoneCount);
            this.Controls.Add(this.RedStoneCount);
            this.Controls.Add(this.BlueStone);
            this.Controls.Add(this.RedStone);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.BlueTurnLabel);
            this.Controls.Add(this.RedTurnLabel);
            this.Controls.Add(this.BlueTurn);
            this.Controls.Add(this.RedTurn);
            this.Controls.Add(this.GameArea);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Game";
            this.RightToLeftLayout = true;
            this.Text = "Reversie";
            ((System.ComponentModel.ISupportInitialize)(this.GameArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedStone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueStone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinnerArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameArea;
        private System.Windows.Forms.PictureBox RedTurn;
        private System.Windows.Forms.PictureBox BlueTurn;
        private System.Windows.Forms.Label RedTurnLabel;
        private System.Windows.Forms.Label BlueTurnLabel;
        private Button NewGameButton;
        private new Button HelpButton;
        private PictureBox RedStone;
        private PictureBox BlueStone;
        private Label RedStoneCount;
        private Label BlueStoneCount;
        private PictureBox WinnerArea;
        private Label WinnerLabel;
        private Button PassButton;
    }
}

