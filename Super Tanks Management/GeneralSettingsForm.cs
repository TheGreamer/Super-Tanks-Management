using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Super_Tanks_Management
{
    public partial class GeneralSettingsForm : Form
    {
        private readonly string filePath = string.Empty;
        private readonly Dictionary<string, TextBox> textBoxMapping;

        public GeneralSettingsForm()
        {
            InitializeComponent();

            textBoxMapping = new Dictionary<string, TextBox>()
            {
                { "godmode", textBox1 },
                { "tank_health_multiply", textBox2 },
                { "hidden_tank_chance", textBox3 },
                { "tank_health_hud", textBox4 },
                { "tank_damage_multiply", textBox5 },
                { "bot_friendly_fire", textBox6 },
                { "force_regular_tank", textBox7 },
                { "godmode_bots", textBox8 },
                { "tank_variant_chance", textBox9 },
                { "tank_spawner", textBox10 },
                { "tank_rewards", textBox11 },
                { "tank_overlord_chance", textBox12 },
                { "tank_notice", textBox13 },
                { "overlord_tank_limit", textBox14 },
                { "special_tank_limit", textBox15 },
                { "hidden_tank_allow_restart_times", textBox16 }
            };

            filePath = SettingsManager.LoadSettings("st_settings.txt", textBoxMapping);

            SettingsManager.LoadTextBoxSettings(new Dictionary<TextBox, Range>
            {
                { textBox1, new Range() },
                { textBox2, new Range() { Max = 15.0, IsInteger = false } },
                { textBox3, new Range() { Max = 100 } },
                { textBox4, new Range() },
                { textBox5, new Range() { Min = 0.1, Max = 10000, IsInteger = false } },
                { textBox6, new Range() },
                { textBox7, new Range() },
                { textBox8, new Range() },
                { textBox9, new Range() { Max = 100 } },
                { textBox10, new Range() },
                { textBox11, new Range() { Max = 3 } },
                { textBox12, new Range() { Max = 100 } },
                { textBox13, new Range() { Max = 1 } },
                { textBox14, new Range() { Min = 1, Max = 20 } },
                { textBox15, new Range() { Min = 1, Max = 20 } },
                { textBox16, new Range() { Min = 1, Max = 10000 } }
            }, Controls);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SettingsManager.SaveSettings(filePath, textBoxMapping);
        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}