using Super_Tanks_Management.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Super_Tanks_Management
{
    public partial class AllowedTanksForm : Form
    {
        public static string filePath = string.Empty;
        private bool state = false;
        private readonly Dictionary<string, int> attributes = new Dictionary<string, int>();

        public AllowedTanksForm()
        {
            InitializeComponent();
            LoadFilePath();
        }

        private void LoadFilePath()
        {
            if (!string.IsNullOrEmpty(Settings.Default.FilePath) && File.Exists(Settings.Default.FilePath))
            {
                filePath = Settings.Default.FilePath;
                state = true;
            }
            else
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.SafeFileName.Equals("allowtanks.txt"))
                    {
                        filePath = openFileDialog.FileName;
                        Settings.Default.FilePath = filePath;
                        Settings.Default.Save();
                        state = true;
                    }
                    else
                    {
                        MessageBox.Show("You must select 'allowtanks.txt' in order to proceed. The application will close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("File selection was cancelled. The application will close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadFile()
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('=');

                if (parts.Length == 2)
                {
                    string attributeName = parts[0].Trim();
                    int attributeValue = int.Parse(parts[1].Trim());
                    attributes[attributeName] = attributeValue;
                }
            }

            UpdateListBox();
        }

        private void SaveAttributesToFile()
        {
            var lines = new List<string>();

            foreach (var entry in attributes)
            {
                lines.Add($"{entry.Key} = {entry.Value}");
            }

            File.WriteAllLines(filePath, lines);
        }

        private void UpdateListBox()
        {
            listBoxSuperTanks.Items.Clear();

            foreach (var entry in attributes)
            {
                listBoxSuperTanks.Items.Add($"{entry.Key}");
            }
        }

        private void AllowedTanksForm_Load(object sender, EventArgs e)
        {
            if (state)
                LoadFile();
            else
                Application.Exit();
        }

        private void ButtonToggleSelected_Click(object sender, EventArgs e)
        {
            if (listBoxSuperTanks.SelectedItem != null)
            {
                string selected = listBoxSuperTanks.SelectedItem.ToString().Split('-')[0].Trim();
                attributes[selected] = attributes[selected] == 1 ? 0 : 1;
                labelStatus.Text = $"Status: {selected} is now {(attributes[selected] == 1 ? "active" : "inactive")}";
                UpdateListBox();
                SaveAttributesToFile();
            }
            else
            {
                MessageBox.Show("To toggle an option you must first select one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonActivateAll_Click(object sender, EventArgs e)
        {
            foreach (string key in attributes.Keys.ToList())
            {
                attributes[key] = 1;
            }

            labelStatus.Text = "Status: All super tanks are now active";
            UpdateListBox();
            SaveAttributesToFile();
        }

        private void ButtonDeactivateAll_Click(object sender, EventArgs e)
        {
            foreach (string key in attributes.Keys.ToList())
            {
                attributes[key] = 0;
            }

            labelStatus.Text = "Status: All super tanks are now inactive";
            UpdateListBox();
            SaveAttributesToFile();
        }

        private void ListBoxSuperTanks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (listBoxSuperTanks.Items.Count != 0)
            {
                e.DrawBackground();

                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                string itemText = listBoxSuperTanks.Items[e.Index].ToString();
                bool isActive = attributes[itemText.Split('-')[0].Trim()] == 1;

                Color bgColor = isActive ? Color.LightGreen : Color.LightCoral;
                Color textColor = Color.FromArgb(0, 57, 57);

                if (isSelected)
                    bgColor = Color.DarkGray;

                e.Graphics.FillRectangle(new SolidBrush(bgColor), e.Bounds);
                e.Graphics.DrawString(itemText, e.Font, new SolidBrush(textColor), e.Bounds, StringFormat.GenericDefault);
                e.DrawFocusRectangle();
            }
        }

        private void GeneralSettingsButton_Click(object sender, EventArgs e)
        {
            new GeneralSettingsForm().ShowDialog();
        }

        private void SuperTanksSettingsButton_Click(object sender, EventArgs e)
        {
            new SuperTanksSettingsForm().ShowDialog();
        }
    }
}