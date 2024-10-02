using System.Globalization;
using System.Windows.Forms;
using System;

namespace Super_Tanks_Management
{
    public class Range
    {
        public double Min { get; set; } = 0;
        public double Max { get; set; } = 1;
        public bool IsInteger { get; set; } = true;

        public static void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as TextBox;

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
        }

        public static void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;

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
        }
    }
}