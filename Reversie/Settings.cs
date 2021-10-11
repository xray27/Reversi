using System;
using System.Windows.Forms;

namespace Reversie
{
    public partial class Settings : Form
    {
        private readonly Game g;
        public bool Unlock = false;
        public Settings(Game GameInstance)
        {
            InitializeComponent();
            g = GameInstance;

            SettingsColumns.Text = "6";
            SettingsRows.Text = "6";

            SettingsColumns.LostFocus += (s, e) => AddPlaceHolder(s, e, SettingsColumns);
            SettingsRows.LostFocus += (s, e) => AddPlaceHolder(s, e, SettingsRows);

            SettingsColumns.TextChanged += (s, e) => ChangedText(s, e, SettingsColumns);
            SettingsRows.TextChanged += (s, e) => ChangedText(s, e, SettingsRows);

            PlayerVSPlayerButton.CheckedChanged += CheckedChangedEventHandler;

            DifficultyValues.SelectedItem = "Easy";
            DelayValueBox.SelectedItem = "750";
            DelayValueBox.Enabled = false;
            DifficultyValues.Enabled = false;
            
        }

        private void AddPlaceHolder(object sender, EventArgs e, Control control)
        {
            if (string.IsNullOrEmpty(control.Text)) control.Text = "6";
            if (int.Parse(control.Text) < 3) control.Text = "3";
        }

        private void ChangedText(object sender, EventArgs e, Control control)
        {
            try
            {
                int.Parse(control.Text);
            }
            catch (Exception)
            {
                control.Text = "6";
            }
        }

        private void CheckedChangedEventHandler(object sender, EventArgs e)
        {
            Unlock = !Unlock;
            foreach (Control control in Controls)
            {
                switch (control.Name)
                {
                    case "DelayValueBox":
                        control.Enabled = Unlock;
                        break;
                    case "DifficultyValues":
                        control.Enabled = Unlock;
                        break;
                }
            }
        }

        private void SettingsConfirmButton_Click(object sender, EventArgs e)
        {
            if (PlayerVSComputerButton.Checked) 
                g.PlayVSComputer = true;
            else 
                g.PlayVSComputer = false;

            if ((string)DifficultyValues.SelectedItem == "Easy") 
                g.DifficultyComputer = "Easy";
            else 
                g.DifficultyComputer = "Hard";

            g.ComputerDelay = int.Parse(DelayValueBox.Text);

            if (int.Parse(SettingsColumns.Text) >= 3) 
                g.Columns = int.Parse(SettingsColumns.Text);
            else 
                g.Columns = 3;

            if (int.Parse(SettingsRows.Text) >= 3) 
                g.Rows = int.Parse(SettingsRows.Text);
            else 
                g.Rows = 3;

            g.NewGame();
            Hide();
        }

        private void SettingsCancelButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
