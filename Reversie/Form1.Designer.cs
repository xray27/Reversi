using System.Windows.Forms;

namespace Reversie
{
    partial class Form1
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
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTurn)).BeginInit();
            this.SuspendLayout();
            // 
            // GameArea
            // 
            this.GameArea.BackColor = System.Drawing.Color.White;
            this.GameArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameArea.Location = new System.Drawing.Point(341, 12);
            this.GameArea.Name = "GameArea";
            this.GameArea.Size = new System.Drawing.Size(628, 628);
            this.GameArea.TabIndex = 0;
            this.GameArea.TabStop = false;
            // 
            // RedTurn
            // 
            this.RedTurn.BackColor = System.Drawing.Color.Red;
            this.RedTurn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RedTurn.Location = new System.Drawing.Point(13, 12);
            this.RedTurn.Name = "RedTurn";
            this.RedTurn.Size = new System.Drawing.Size(150, 50);
            this.RedTurn.TabIndex = 1;
            this.RedTurn.TabStop = false;
            // 
            // BlueTurn
            // 
            this.BlueTurn.BackColor = System.Drawing.Color.Blue;
            this.BlueTurn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlueTurn.Location = new System.Drawing.Point(178, 12);
            this.BlueTurn.Name = "BlueTurn";
            this.BlueTurn.Size = new System.Drawing.Size(150, 50);
            this.BlueTurn.TabIndex = 2;
            this.BlueTurn.TabStop = false;
            // 
            // RedTurnLabel
            // 
            this.RedTurnLabel.AutoSize = true;
            this.RedTurnLabel.BackColor = System.Drawing.Color.Red;
            this.RedTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedTurnLabel.ForeColor = System.Drawing.Color.White;
            this.RedTurnLabel.Location = new System.Drawing.Point(42, 25);
            this.RedTurnLabel.Name = "RedTurnLabel";
            this.RedTurnLabel.Size = new System.Drawing.Size(90, 24);
            this.RedTurnLabel.TabIndex = 3;
            this.RedTurnLabel.Text = "Red Turn";
            // 
            // BlueTurnLabel
            // 
            this.BlueTurnLabel.AutoSize = true;
            this.BlueTurnLabel.BackColor = System.Drawing.Color.Blue;
            this.BlueTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueTurnLabel.ForeColor = System.Drawing.Color.White;
            this.BlueTurnLabel.Location = new System.Drawing.Point(209, 25);
            this.BlueTurnLabel.Name = "BlueTurnLabel";
            this.BlueTurnLabel.Size = new System.Drawing.Size(93, 24);
            this.BlueTurnLabel.TabIndex = 4;
            this.BlueTurnLabel.Text = "Blue Turn";
            // 
            // NewGameButton
            // 
            this.NewGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGameButton.Location = new System.Drawing.Point(12, 547);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(316, 93);
            this.NewGameButton.TabIndex = 5;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(112, 75);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 25);
            this.StatusLabel.TabIndex = 6;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsButton.Location = new System.Drawing.Point(12, 496);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(150, 45);
            this.SettingsButton.TabIndex = 7;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            // 
            // HelpButton
            // 
            this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.Location = new System.Drawing.Point(178, 496);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(150, 45);
            this.HelpButton.TabIndex = 8;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 652);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.BlueTurnLabel);
            this.Controls.Add(this.RedTurnLabel);
            this.Controls.Add(this.BlueTurn);
            this.Controls.Add(this.RedTurn);
            this.Controls.Add(this.GameArea);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Reversie";
            ((System.ComponentModel.ISupportInitialize)(this.GameArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTurn)).EndInit();
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
        private Label StatusLabel;
        private Button SettingsButton;
        private Button HelpButton;
    }
}

