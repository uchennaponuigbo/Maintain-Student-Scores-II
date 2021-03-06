﻿using System;
using System.Windows.Forms;

namespace Maintain_Student_Scores_II_returns
{
    public partial class frmAddNewStudent : Form
    {
        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*TODO: Find out why the form closes regardless of whether the textbox contains values or not*/
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validator.IsNotEmpty(txtName))
            {
                string newStudent = txtName.Text + "|";
                if (txtScores.Text != "")
                {
                    string scoresDelimiter = txtScores.Text.Replace(' ', '|');
                    scoresDelimiter = scoresDelimiter.Remove(scoresDelimiter.Length - 1, 1); //removes last character in string
                    newStudent += scoresDelimiter;
                }

                Tag = newStudent;
                Close();
            }
            else
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScores.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(Validator.CheckAll(txtScore))
            {
                txtScores.Text += txtScore.Text + " ";
                txtScore.Text = "";
            }
        }
    }
}
