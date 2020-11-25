using System;
using System.Windows.Forms;

namespace Maintain_Student_Scores_II_returns
{
    public partial class frmAddScore : Form
    {
        public frmAddScore()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(Validator.CheckAll(txtScore))
            {
                Tag = txtScore.Text;
                Close();
            }       
        }
    }
}
