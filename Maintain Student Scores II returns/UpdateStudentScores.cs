using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintain_Student_Scores_II_returns
{
    public partial class frmUpdateStudentScores : Form
    {
        public frmUpdateStudentScores(in Student student)
        {
            InitializeComponent();

            txtName.Text = student.Name;
            List<int> scores = student.ListofScores();
            foreach (var item in scores)
                ScoresListBox.Items.Add(item);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //do stuff then close
            List<int> scores = new List<int>();
            foreach (var item in ScoresListBox.Items)
                scores.Add(Convert.ToInt32(item));

            Student update = new Student(txtName.Text, scores);
            Tag = update.ToString();
            Close();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Student.RemoveItem(ScoresListBox);
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            ScoresListBox.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form form = new frmAddScore();
            DialogResult button = form.ShowDialog();
            if (button == DialogResult.OK)
                ScoresListBox.Items.Add(form.Tag.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(Validator.IsSelected(ScoresListBox))
            {
                Form form = new frmUpdateScore(ScoresListBox.SelectedItem.ToString());
                DialogResult button = form.ShowDialog();
                if (button == DialogResult.OK)
                {
                    if (ScoresListBox.SelectedItems.Count != 0)
                    {
                        while (ScoresListBox.SelectedIndex != -1)
                        {
                            ScoresListBox.Items.Insert(ScoresListBox.SelectedIndex, form.Tag);
                            ScoresListBox.Items.Remove(ScoresListBox.SelectedItem);
                        }
                    }
                }
            }
            
        }
    }
}
