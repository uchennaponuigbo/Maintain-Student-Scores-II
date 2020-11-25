using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maintain_Student_Scores_II_returns
{
    //handles the business logic of the application
    public class Student
    {
        public string Name { get;  private set; }
        private byte[] Scores { get; set; }

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

        Student()
        {
            //private constructor is required for database initializing
            StudentScores = new List<int>();
        }

        public void ConvertBytesToScores() //this method should only be called once in proportion to the student's name appearing 
            //on the form when the first form opens
        {
            if(Scores != null || Scores.Length > 0)
            {
                string dataScores = Encoding.Default.GetString(Scores); //my database seperates the scores by single spaces
                string[] scores = dataScores.Split(' ');
                if (scores.Length == 1)
                {
                    //purposely empty so that in the case of null score data in database,
                    //I'd check if the split method returned a single element array which is just a single space
                }
                else if (scores.Length > 0)
                {
                    for (int i = 0; i < scores.Length; i++)
                        StudentScores.Add(Convert.ToInt32(scores[i]));
                }
                
                
                Array.Clear(Scores, 0, Scores.Length); //assign to null so that if this method is somehow called again,
                                                     //it won't corrupt the old data
            }
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

            if (average == 0)
                return average;
            else
                return average / StudentScores.Count();
        }       
    }
}
