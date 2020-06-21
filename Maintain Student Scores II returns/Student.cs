using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintain_Student_Scores_II_returns
{
    //handles the business logic of the application
    public class Student
    {
        public string Name { get;  private set; }
        private List<int> StudentScores;

        public Student(string studentData)
        {
            StudentScores = new List<int>();

            int firstDelimter = studentData.IndexOf("|");
            Name = studentData.Substring(0, firstDelimter);
            string scoreData = studentData.Substring(firstDelimter);
            if(scoreData != "|")
            {
                string[] scores = scoreData.Split('|');

                //not start at 0 because the split method's first index is an empty string
                for (int i = 1; i < scores.Length; i++)
                    StudentScores.Add(Convert.ToInt32(scores[i]));
            }
            
        }

        public Student(string name, in List<int> scores)
        {
            Name = name;
            StudentScores = scores;
        }

        public override string ToString()
        {
            if (StudentScores.Count > 0)
            {
                string student = Name;
                foreach (var item in StudentScores)
                {
                    student += $"|{item.ToString()}";
                }
                return student;
            }
            else
                return Name + "|";
            
        }

        public List<int> ListofScores() => StudentScores;

        public int TotalScore()
        {
            int total = 0;
            foreach (var item in StudentScores)
                total += item;
            return total;
        }

        public int ScoreCount() => StudentScores.Count();

        public int AverageScore()
        {
            int average = 0;
            foreach (var item in StudentScores)
                average += item;

            if (StudentScores.Count() == 0)
                return 0;
            else
                return average / StudentScores.Count();
        }

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
    }
}
