using Super_Tanks_Management.Properties;
using System.Collections.Generic;
using System.Globalization;
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

        public static void SaveSettings(string filePath, Dictionary<string, TextBox> textBoxMapping)
        {
            string[] lines = textBoxMapping.Select(kvp => $"{kvp.Key} = {kvp.Value.Text}").ToArray();
            File.WriteAllLines(filePath, lines);
            MessageBox.Show("Settings saved.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void LoadTextBoxSettings(Dictionary<TextBox, Range> textBoxSettings, Control.ControlCollection controls)
        {
            foreach (var kvp in textBoxSettings)
            {
                kvp.Key.Tag = kvp.Value;
            }

            foreach (var textBox in controls.OfType<TextBox>())
            {
                textBox.KeyPress += (sender, e) =>
                {
                    if (textBox.Tag is Range range)
                    {
                        if (!range.IsInteger)
                        {
                            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                            {
                                e.Handled = true;
                            }
                            if (e.KeyChar == '.' && textBox.Text.Contains("."))
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                            {
                                e.Handled = true;
                            }
                        }
                    }
                };

                textBox.TextChanged += (sender, e) =>
                {
                    if (textBox.Tag is Range range)
                    {
                        if (range.IsInteger)
                        {
                            if (int.TryParse(textBox.Text, out int value))
                            {
                                if (value < range.Min)
                                {
                                    textBox.Text = range.Min.ToString();
                                }
                                else if (value > range.Max)
                                {
                                    textBox.Text = range.Max.ToString();
                                }
                            }
                        }
                        else
                        {
                            if (double.TryParse(textBox.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double value))
                            {
                                if (!textBox.Text.StartsWith("0."))
                                {
                                    if (value < range.Min)
                                    {
                                        textBox.Text = range.Min.ToString().Replace(',', '.');
                                    }
                                    else if (value > range.Max)
                                    {
                                        textBox.Text = range.Max.ToString().Replace(',', '.');
                                    }
                                }
                            }
                        }
                    }
                };
            }
        }
    }
}