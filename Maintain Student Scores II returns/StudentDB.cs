using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Sqlite;
using Dapper;

namespace Maintain_Student_Scores_II_returns
{
    //gonna work with SQLserver database on this one

    public class StudentDB
    {
        //private SqlConnection connection;
        //private Dictionary<string, List<int>> records;
        public StudentDB()
        {
            //string sqlConnectionPath = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:
            //    \Users\Uchenna\Documents\Student_Scores_DB.mdf
            //    ;Integrated Security=True;Connect Timeout=30";

            //connection = new SqlConnection(sqlConnectionPath);
            //records = new Dictionary<string, List<int>>();
        }

        public static string LoadConnectionString(string id = "Default") => 
            ConfigurationManager.ConnectionStrings[id].ConnectionString;

        public static void LoadStudents()
        {

        }

        public static void SaveStudents()
        {

        }

        public List<string> GetStudents()
        {
            //List<string> students = new List<string>();
            //connection.Open();

            //connection.Close();
            return null;
        }

        public void SaveStudents(in List<string> students)
        {
            //connection.Open();

            //connection.Close();
        }
    }
}
