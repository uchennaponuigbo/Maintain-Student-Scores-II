using System.Collections.Generic;
using System.Configuration; //go to configuration manager and find this, then check it
using System.Data.SQLite; //install nuget package
using Dapper; //install nuget package
using System.Data;

namespace Maintain_Student_Scores_II_returns
{
    public static class StudentDB
    {
        public static string LoadConnectionString(string id = "Default") => 
            ConfigurationManager.ConnectionStrings[id].ConnectionString; //aka absolute path of my database

        public static List<Student> LoadStudents()
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = "SELECT * FROM Students";
                var output = connection.Query<Student>(sql, new DynamicParameters());
                return output.AsList();
            }
        }

        public static void AddStudent(string newStudent)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                int firstDelimter = newStudent.IndexOf("|");
                string name = newStudent.Substring(0, firstDelimter);
                string combinedScores = newStudent.Substring(firstDelimter).Replace('|', ' ');
                combinedScores = combinedScores.Substring(1);
                string sql = $"INSERT INTO Students (Name, Scores) VALUES (\"{name}\", \"{combinedScores}\")";
                connection.Execute(sql, new DynamicParameters());
            }
        }

        public static void DeleteStudent(string studentToDelete)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                int firstDelimter = studentToDelete.IndexOf("|");
                string name = studentToDelete.Substring(0, firstDelimter);
                string sql = $"DELETE FROM Students WHERE Name = \"{name}\"";
                connection.Execute(sql, new DynamicParameters());
            }
        }

        public static void UpdateStudent(string studentToUpdate)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                int firstDelimter = studentToUpdate.IndexOf("|");
                string name = studentToUpdate.Substring(0, firstDelimter);
                string combinedScores = studentToUpdate.Substring(firstDelimter).Replace('|', ' ');
                combinedScores = combinedScores.Substring(1);                
                string sql = $"UPDATE Students SET Scores = \"{combinedScores}\" WHERE Name = \"{name}\"";
                connection.Execute(sql, new DynamicParameters());
            }
        }
    }
}
