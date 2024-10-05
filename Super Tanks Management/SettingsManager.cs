using Super_Tanks_Management.Properties;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Super_Tanks_Management
{
    public static class SettingsManager
    {
        public static string LoadSettings(string fileName, Dictionary<string, TextBox> textBoxMapping)
        {
            string filePath = Settings.Default.FilePath.Replace("allowtanks.txt", fileName);
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('=').Select(p => p.Trim()).ToArray();

                if (parts.Length == 2)
                {
                    string key = parts[0];
                    string value = parts[1];

                    if (textBoxMapping.ContainsKey(key))
                    {
                        textBoxMapping[key].Text = value;
                    }
                }
            }

            return filePath;
        }

        public static void LoadTextBoxSettings(Dictionary<TextBox, Range> textBoxSettings, Control.ControlCollection controls)
        {
            foreach (var kvp in textBoxSettings)
            {
                kvp.Key.Tag = kvp.Value;
            }

            foreach (var textBox in controls.OfType<TextBox>())
            {
                textBox.KeyPress += Range.TextBox_KeyPress;
                textBox.TextChanged += Range.TextBox_TextChanged;
            }
        }

        public static void SaveSettings(string filePath, Dictionary<string, TextBox> textBoxMapping)
        {
            string[] lines = textBoxMapping.Select(kvp => $"{kvp.Key} = {kvp.Value.Text}").ToArray();
            File.WriteAllLines(filePath, lines);
            MessageBox.Show("Settings saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}