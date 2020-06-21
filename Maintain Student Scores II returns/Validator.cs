using System;
using System.Windows.Forms;

namespace Maintain_Student_Scores_II_returns
{
    public static class Validator
    {
        public static bool CheckAll(in TextBox textBox)
        {
            if (IsNotEmpty(textBox))
                if (IsInteger(textBox))
                    if (IsWithinRange(textBox))
                        return true;
            return false;
        }
        public static bool IsWithinRange(in TextBox textBox, int min = 0, int max = 100)
        {
            int number = Convert.ToInt32(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show($"The value in {textBox.Tag} must be between {min} and {max}."
                   , "Out of Range Error");
                textBox.Focus();
                return false;
            }
            else
                return true;
        }

        public static bool IsInteger(in TextBox textBox)
        {
            if (!Int32.TryParse(textBox.Text, out int number))
            {
                MessageBox.Show($"{textBox.Tag} is not a valid integer.", "Invalid Entry");
                textBox.Focus();
                return false;
            }
            else
                return true;
        }

        public static bool IsNotEmpty(in TextBox textBox)
        {
            if (textBox.Text == String.Empty)
            {
                MessageBox.Show($"{textBox.Tag} cannot be empty.", "Empty Textbox");
                textBox.Focus();
                return false;
            }
            else
                return true;
        }

        public static bool IsSelected(in ListBox listBox)
        {
            if (listBox.SelectedIndex == -1)
            {
                MessageBox.Show($"Please select an available student in {listBox.Tag}.", "No Selection");
                return false;
            }
            else
                return true;
        }
    }
}
