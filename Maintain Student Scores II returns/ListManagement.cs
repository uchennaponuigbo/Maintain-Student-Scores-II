using System.Windows.Forms;

namespace Maintain_Student_Scores_II_returns
{
    public static class ListManagement
    {
        public static string RemoveItem(in ListBox listBox)
        {
            string deletedItem = "";
            if (listBox.SelectedItems.Count != 0)
            {
                while (listBox.SelectedIndex != -1)
                {
                    deletedItem = listBox.Items[listBox.SelectedIndex].ToString();
                    listBox.Items.RemoveAt(listBox.SelectedIndex);                   
                }
            }
            return deletedItem;
        }

        public static string ChangeItem(in ListBox listBox, in Form form)
        {
            string updatedItem = "";
            if (listBox.SelectedItems.Count != 0)
            {
                while (listBox.SelectedIndex != -1)
                {
                    listBox.Items.Insert(listBox.SelectedIndex, form.Tag);
                    updatedItem = form.Tag.ToString();
                    listBox.Items.Remove(listBox.SelectedItem);
                }
            }
            return updatedItem;
        }
    }
}
