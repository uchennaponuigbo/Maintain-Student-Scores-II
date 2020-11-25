using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Maintain_Student_Scores_II_returns
{
    public partial class frmStudentScores : Form
    {
        public frmStudentScores()
        {
            InitializeComponent();

            LoadFromDatabase();           
        }

        private void LoadFromDatabase()
        {
            //if the database doesn't exist, then create it... 
            //but I'll leave that to the student copying this project
            List<Student> incoming = StudentDB.LoadStudents();
            foreach (var student in incoming)
            {
                student.ConvertBytesToScores();
                StudentsListBox.Items.Add(student.ToString());
            }
                
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*TODO: Find out why the form closes regardless of whether the textbox contains values or not*/
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form form = new frmAddNewStudent();
            DialogResult button = form.ShowDialog();
            if (button == DialogResult.OK && form.Tag != null)
            {
                StudentDB.AddStudent(form.Tag.ToString());
                StudentsListBox.Items.Add(form.Tag.ToString());
            }
                
        }

        private void ClearTextboxes()
        {
            txtAverage.Text = txtScoreCount.Text = txtScoreTotal.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string itemToDelete = ListManagement.RemoveItem(StudentsListBox);
            ClearTextboxes();
            StudentDB.DeleteStudent(itemToDelete);           
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
                    string itemToModify = ListManagement.ChangeItem(StudentsListBox, form);                   
                    StudentDB.UpdateStudent(itemToModify);
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
