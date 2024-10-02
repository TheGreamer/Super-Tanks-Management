using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Super_Tanks_Management
{
    public partial class SuperTanksSettingsForm : Form
    {
        private string filePath = string.Empty;

        public SuperTanksSettingsForm()
        {
            InitializeComponent();
            LoadSettings();
            LoadTextBoxSettings();
        }

        private void LoadSettings()
        {
            filePath = AllowedTanksForm.filePath.Replace("allowtanks.txt", "st_tanksettings.txt");
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('=').Select(p => p.Trim()).ToArray();

                if (parts.Length == 2)
                {
                    string key = parts[0];
                    string value = parts[1];

                    switch (key)
                    {
                        case "wraith_tank_visible_time": textBox1.Text = value; break;
                        case "phantom_tank_bleed_interval": textBox2.Text = value; break;
                        case "necro_tank_witch_hp": textBox3.Text = value; break;
                        case "necromancer_effect_range": textBox4.Text = value; break;
                        case "necro_tank_witch_damage": textBox5.Text = value; break;
                        case "police_tank_flash_color": textBox6.Text = value; break;
                    }
                }
            }
        }

        private void LoadTextBoxSettings()
        {
            textBox1.Tag = new Range { Min = 0.1, Max = 10, IsInteger = false };
            textBox2.Tag = new Range { Min = 0.1, Max = 15, IsInteger = false };
            textBox3.Tag = new Range { Max = 0.9, IsInteger = false };
            textBox4.Tag = new Range { Min = 200, Max = 1000000 };
            textBox5.Tag = new Range { Min = 0.01, Max = 1000000, IsInteger = false };
            textBox6.Tag = new Range { Max = 255 };

            foreach (var textBox in Controls.OfType<TextBox>())
            {
                textBox.KeyPress += Range.TextBox_KeyPress;
                textBox.TextChanged += Range.TextBox_TextChanged;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string[] lines = new string[]
            {
                $"wraith_tank_visible_time = {textBox1.Text}",
                $"phantom_tank_bleed_interval = {textBox2.Text}",
                $"necro_tank_witch_hp = {textBox3.Text}",
                $"necromancer_effect_range = {textBox4.Text}",
                $"necro_tank_witch_damage = {textBox5.Text}",
                $"police_tank_flash_color = {textBox6.Text}"
            };

            File.WriteAllLines(filePath, lines);
            MessageBox.Show("Settings saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}