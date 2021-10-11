namespace Reversie
{
    partial class Settings
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
            this.PlayerVSPlayerButton = new System.Windows.Forms.RadioButton();
            this.PlayerVSComputerButton = new System.Windows.Forms.RadioButton();
            this.DelayValueBox = new System.Windows.Forms.ComboBox();
            this.ComputerDelayLabel = new System.Windows.Forms.Label();
            this.SettingsConfirmButton = new System.Windows.Forms.Button();
            this.SettingsCancelButton = new System.Windows.Forms.Button();
            this.DifficultyValues = new System.Windows.Forms.ComboBox();
            this.SettingsDifficultyLabel = new System.Windows.Forms.Label();
            this.SettingsRowsLabel = new System.Windows.Forms.Label();
            this.SettingsColumnsLabel = new System.Windows.Forms.Label();
            this.SettingsColumns = new System.Windows.Forms.TextBox();
            this.SettingsRows = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PlayerVSPlayerButton
            // 
            this.PlayerVSPlayerButton.AutoSize = true;
            this.PlayerVSPlayerButton.Checked = true;
            this.PlayerVSPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerVSPlayerButton.Location = new System.Drawing.Point(16, 15);
            this.PlayerVSPlayerButton.Margin = new System.Windows.Forms.Padding(4);
            this.PlayerVSPlayerButton.Name = "PlayerVSPlayerButton";
            this.PlayerVSPlayerButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PlayerVSPlayerButton.Size = new System.Drawing.Size(181, 29);
            this.PlayerVSPlayerButton.TabIndex = 4;
            this.PlayerVSPlayerButton.TabStop = true;
            this.PlayerVSPlayerButton.Text = "Player VS Player";
            this.PlayerVSPlayerButton.UseMnemonic = false;
            this.PlayerVSPlayerButton.UseVisualStyleBackColor = true;
            // 
            // PlayerVSComputerButton
            // 
            this.PlayerVSComputerButton.AutoSize = true;
            this.PlayerVSComputerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerVSComputerButton.Location = new System.Drawing.Point(236, 15);
            this.PlayerVSComputerButton.Margin = new System.Windows.Forms.Padding(4);
            this.PlayerVSComputerButton.Name = "PlayerVSComputerButton";
            this.PlayerVSComputerButton.Size = new System.Drawing.Size(212, 29);
            this.PlayerVSComputerButton.TabIndex = 5;
            this.PlayerVSComputerButton.Text = "Player VS Computer";
            this.PlayerVSComputerButton.UseVisualStyleBackColor = true;
            // 
            // DelayValueBox
            // 
            this.DelayValueBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DelayValueBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelayValueBox.FormattingEnabled = true;
            this.DelayValueBox.Items.AddRange(new object[] {
            "4000",
            "2000",
            "1000",
            "875",
            "750",
            "625",
            "500",
            "375",
            "250",
            "125",
            "0"});
            this.DelayValueBox.Location = new System.Drawing.Point(13, 109);
            this.DelayValueBox.Margin = new System.Windows.Forms.Padding(4);
            this.DelayValueBox.Name = "DelayValueBox";
            this.DelayValueBox.Size = new System.Drawing.Size(164, 33);
            this.DelayValueBox.TabIndex = 6;
            // 
            // ComputerDelayLabel
            // 
            this.ComputerDelayLabel.AutoSize = true;
            this.ComputerDelayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComputerDelayLabel.Location = new System.Drawing.Point(13, 80);
            this.ComputerDelayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ComputerDelayLabel.Name = "ComputerDelayLabel";
            this.ComputerDelayLabel.Size = new System.Drawing.Size(153, 25);
            this.ComputerDelayLabel.TabIndex = 7;
            this.ComputerDelayLabel.Text = "Computer Delay";
            // 
            // SettingsConfirmButton
            // 
            this.SettingsConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsConfirmButton.Location = new System.Drawing.Point(16, 310);
            this.SettingsConfirmButton.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsConfirmButton.Name = "SettingsConfirmButton";
            this.SettingsConfirmButton.Size = new System.Drawing.Size(292, 54);
            this.SettingsConfirmButton.TabIndex = 8;
            this.SettingsConfirmButton.Text = "Confirm";
            this.SettingsConfirmButton.UseVisualStyleBackColor = true;
            this.SettingsConfirmButton.Click += new System.EventHandler(this.SettingsConfirmButton_Click);
            // 
            // SettingsCancelButton
            // 
            this.SettingsCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsCancelButton.Location = new System.Drawing.Point(316, 310);
            this.SettingsCancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsCancelButton.Name = "SettingsCancelButton";
            this.SettingsCancelButton.Size = new System.Drawing.Size(161, 54);
            this.SettingsCancelButton.TabIndex = 9;
            this.SettingsCancelButton.Text = "Cancel";
            this.SettingsCancelButton.UseVisualStyleBackColor = true;
            this.SettingsCancelButton.Click += new System.EventHandler(this.SettingsCancelButton_Click);
            // 
            // DifficultyValues
            // 
            this.DifficultyValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DifficultyValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DifficultyValues.FormattingEnabled = true;
            this.DifficultyValues.Items.AddRange(new object[] {
            "Easy",
            "Hard"});
            this.DifficultyValues.Location = new System.Drawing.Point(16, 199);
            this.DifficultyValues.Margin = new System.Windows.Forms.Padding(4);
            this.DifficultyValues.Name = "DifficultyValues";
            this.DifficultyValues.Size = new System.Drawing.Size(160, 33);
            this.DifficultyValues.TabIndex = 10;
            // 
            // SettingsDifficultyLabel
            // 
            this.SettingsDifficultyLabel.AutoSize = true;
            this.SettingsDifficultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsDifficultyLabel.Location = new System.Drawing.Point(16, 171);
            this.SettingsDifficultyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SettingsDifficultyLabel.Name = "SettingsDifficultyLabel";
            this.SettingsDifficultyLabel.Size = new System.Drawing.Size(84, 25);
            this.SettingsDifficultyLabel.TabIndex = 11;
            this.SettingsDifficultyLabel.Text = "Difficulty";
            // 
            // SettingsRowsLabel
            // 
            this.SettingsRowsLabel.AutoSize = true;
            this.SettingsRowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsRowsLabel.Location = new System.Drawing.Point(311, 171);
            this.SettingsRowsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SettingsRowsLabel.Name = "SettingsRowsLabel";
            this.SettingsRowsLabel.Size = new System.Drawing.Size(60, 25);
            this.SettingsRowsLabel.TabIndex = 12;
            this.SettingsRowsLabel.Text = "Rows";
            // 
            // SettingsColumnsLabel
            // 
            this.SettingsColumnsLabel.AutoSize = true;
            this.SettingsColumnsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsColumnsLabel.Location = new System.Drawing.Point(311, 80);
            this.SettingsColumnsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SettingsColumnsLabel.Name = "SettingsColumnsLabel";
            this.SettingsColumnsLabel.Size = new System.Drawing.Size(90, 25);
            this.SettingsColumnsLabel.TabIndex = 13;
            this.SettingsColumnsLabel.Text = "Columns";
            // 
            // SettingsColumns
            // 
            this.SettingsColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsColumns.Location = new System.Drawing.Point(316, 109);
            this.SettingsColumns.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsColumns.Name = "SettingsColumns";
            this.SettingsColumns.Size = new System.Drawing.Size(132, 30);
            this.SettingsColumns.TabIndex = 14;
            // 
            // SettingsRows
            // 
            this.SettingsRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsRows.Location = new System.Drawing.Point(316, 199);
            this.SettingsRows.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsRows.Name = "SettingsRows";
            this.SettingsRows.Size = new System.Drawing.Size(132, 30);
            this.SettingsRows.TabIndex = 15;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 379);
            this.Controls.Add(this.SettingsRows);
            this.Controls.Add(this.SettingsColumns);
            this.Controls.Add(this.SettingsColumnsLabel);
            this.Controls.Add(this.SettingsRowsLabel);
            this.Controls.Add(this.SettingsDifficultyLabel);
            this.Controls.Add(this.DifficultyValues);
            this.Controls.Add(this.SettingsCancelButton);
            this.Controls.Add(this.SettingsConfirmButton);
            this.Controls.Add(this.ComputerDelayLabel);
            this.Controls.Add(this.DelayValueBox);
            this.Controls.Add(this.PlayerVSComputerButton);
            this.Controls.Add(this.PlayerVSPlayerButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton PlayerVSPlayerButton;
        private System.Windows.Forms.RadioButton PlayerVSComputerButton;
        private System.Windows.Forms.ComboBox DelayValueBox;
        private System.Windows.Forms.Label ComputerDelayLabel;
        private System.Windows.Forms.Button SettingsConfirmButton;
        private System.Windows.Forms.Button SettingsCancelButton;
        private System.Windows.Forms.ComboBox DifficultyValues;
        private System.Windows.Forms.Label SettingsDifficultyLabel;
        private System.Windows.Forms.Label SettingsRowsLabel;
        private System.Windows.Forms.Label SettingsColumnsLabel;
        private System.Windows.Forms.TextBox SettingsColumns;
        private System.Windows.Forms.TextBox SettingsRows;
    }
}