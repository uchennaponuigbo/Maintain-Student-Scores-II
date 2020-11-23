using System.Windows.Forms;

namespace Maintain_Student_Scores_II_returns
{
    public static class ListManagement
    {
        public static void RemoveItem(in ListBox listBox)
        {
            if (listBox.SelectedItems.Count != 0)
            {
                while (listBox.SelectedIndex != -1)
                {
                    listBox.Items.RemoveAt(listBox.SelectedIndex);
                }
            }
        }

        public static void ChangeItem(in ListBox listBox, in Form form)
        {
            if (listBox.SelectedItems.Count != 0)
            {
                while (listBox.SelectedIndex != -1)
                {
                    listBox.Items.Insert(listBox.SelectedIndex, form.Tag);
                    listBox.Items.Remove(listBox.SelectedItem);
                }
            }
        }
    }
}
