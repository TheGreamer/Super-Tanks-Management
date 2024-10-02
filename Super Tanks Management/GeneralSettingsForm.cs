using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Super_Tanks_Management
{
    public partial class GeneralSettingsForm : Form
    {
        private string filePath = string.Empty;

        public GeneralSettingsForm()
        {
            InitializeComponent();
            LoadSettings();
            LoadTextBoxSettings();
        }

        private void LoadSettings()
        {
            filePath = AllowedTanksForm.filePath.Replace("allowtanks.txt", "st_settings.txt");
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
                        case "godmode": textBox1.Text = value; break;
                        case "tank_health_multiply": textBox2.Text = value; break;
                        case "hidden_tank_chance": textBox3.Text = value; break;
                        case "tank_health_hud": textBox4.Text = value; break;
                        case "tank_damage_multiply": textBox5.Text = value; break;
                        case "bot_friendly_fire": textBox6.Text = value; break;
                        case "force_regular_tank": textBox7.Text = value; break;
                        case "godmode_bots": textBox8.Text = value; break;
                        case "tank_variant_chance": textBox9.Text = value; break;
                        case "tank_spawner": textBox10.Text = value; break;
                        case "tank_rewards": textBox11.Text = value; break;
                        case "tank_overlord_chance": textBox12.Text = value; break;
                        case "tank_notice": textBox13.Text = value; break;
                        case "overlord_tank_limit": textBox14.Text = value; break;
                        case "special_tank_limit": textBox15.Text = value; break;
                        case "hidden_tank_allow_restart_times": textBox16.Text = value; break;
                    }
                }
            }
        }

        private void LoadTextBoxSettings()
        {
            textBox1.Tag = new Range();
            textBox2.Tag = new Range { Max = 15.0, IsInteger = false };
            textBox3.Tag = new Range { Max = 100 };
            textBox4.Tag = new Range();
            textBox5.Tag = new Range { Min = 0.1, Max = 10000, IsInteger = false };
            textBox6.Tag = new Range();
            textBox7.Tag = new Range();
            textBox8.Tag = new Range();
            textBox9.Tag = new Range { Max = 100 };
            textBox10.Tag = new Range();
            textBox11.Tag = new Range { Max = 3 };
            textBox12.Tag = new Range { Max = 100 };
            textBox13.Tag = new Range { Max = 1 };
            textBox14.Tag = new Range { Min = 1, Max = 20 };
            textBox15.Tag = new Range { Min = 1, Max = 20 };
            textBox16.Tag = new Range { Min = 1, Max = 10000 };

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
                $"godmode = {textBox1.Text}",
                $"tank_health_multiply = {textBox2.Text}",
                $"hidden_tank_chance = {textBox3.Text}",
                $"tank_health_hud = {textBox4.Text}",
                $"tank_damage_multiply = {textBox5.Text}",
                $"bot_friendly_fire = {textBox6.Text}",
                $"force_regular_tank = {textBox7.Text}",
                $"godmode_bots = {textBox8.Text}",
                $"tank_variant_chance = {textBox9.Text}",
                $"tank_spawner = {textBox10.Text}",
                $"tank_rewards = {textBox11.Text}",
                $"tank_overlord_chance = {textBox12.Text}",
                $"tank_notice = {textBox13.Text}",
                $"overlord_tank_limit = {textBox14.Text}",
                $"special_tank_limit = {textBox15.Text}",
                $"hidden_tank_allow_restart_times = {textBox16.Text}"
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