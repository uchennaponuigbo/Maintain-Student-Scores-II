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
    public partial class frmStudentScores : Form
    {
        public frmStudentScores()
        {
            InitializeComponent();

            //default data until I add the database stuff to read from
            StudentsListBox.Items.Add("Joel Murach|97|71|83");
            StudentsListBox.Items.Add("Doug Lowel|99|93|97");
            StudentsListBox.Items.Add("Anne Boehm|100|100|100");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form form = new frmAddNewStudent();
            DialogResult button = form.ShowDialog();
            if (button == DialogResult.OK)
                StudentsListBox.Items.Add(form.Tag.ToString());
        }

        private void ClearTextboxes()
        {
            txtAverage.Text = txtScoreCount.Text = txtScoreTotal.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Student.RemoveItem(StudentsListBox);
            ClearTextboxes();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(Validator.IsSelected(StudentsListBox))
            {
                Student student = new Student(StudentsListBox.SelectedItem.ToString());
                Form form = new frmUpdateStudentScores(student);
                DialogResult button = form.ShowDialog();
                if (button == DialogResult.OK)
                {
                    if (StudentsListBox.SelectedItems.Count != 0)
                    {
                        while (StudentsListBox.SelectedIndex != -1)
                        {
                            StudentsListBox.Items.Insert(StudentsListBox.SelectedIndex, form.Tag);
                            StudentsListBox.Items.Remove(StudentsListBox.SelectedItem);
                        }
                    }
                }
                ClearTextboxes();
            }  
        }

        private void StudentsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(StudentsListBox.SelectedIndex != -1)
            {
                Student student = new Student(StudentsListBox.SelectedItem.ToString());
                txtScoreTotal.Text = student.TotalScore().ToString();
                txtScoreCount.Text = student.ScoreCount().ToString();
                txtAverage.Text = student.AverageScore().ToString();
            }            
        }
    }
}
