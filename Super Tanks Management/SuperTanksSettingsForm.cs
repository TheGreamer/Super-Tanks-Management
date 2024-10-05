using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Super_Tanks_Management
{
    public partial class SuperTanksSettingsForm : Form
    {
        private readonly string filePath = string.Empty;
        private readonly Dictionary<string, TextBox> textBoxMapping;

        public SuperTanksSettingsForm()
        {
            InitializeComponent();

            textBoxMapping = new Dictionary<string, TextBox>()
            {
                { "wraith_tank_visible_time", textBox1 },
                { "phantom_tank_bleed_interval", textBox2 },
                { "necro_tank_witch_hp", textBox3 },
                { "necromancer_effect_range", textBox4 },
                { "necro_tank_witch_damage", textBox5 },
                { "police_tank_flash_color", textBox6 }
            };

            filePath = SettingsManager.LoadSettings("st_tanksettings.txt", textBoxMapping);

            SettingsManager.LoadTextBoxSettings(new Dictionary<TextBox, Range>
            {
                { textBox1, new Range() { Min = 0.1, Max = 10, IsInteger = false } },
                { textBox2, new Range() { Min = 0.1, Max = 15, IsInteger = false } },
                { textBox3, new Range() { Max = 0.9, IsInteger = false } },
                { textBox4, new Range() { Min = 200, Max = 1000000 } },
                { textBox5, new Range() { Min = 0.01, Max = 1000000, IsInteger = false } },
                { textBox6, new Range() { Max = 255 } }
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