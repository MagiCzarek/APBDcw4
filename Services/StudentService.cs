using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using APBDcw4.Models;
using APBDcw4.Models;

namespace APBDcw4.Services
{
    public class StudentService : IStudentService
    {
        private string conString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        public IEnumerable<Student> GetStudents()
        {
            var students = new List<Student>();
            using (var con =
                new SqlConnection(conString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Student";
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var student = new Student
                    {
                        IndexNumber = dr["IndexNumber"].ToString(),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        BirthDate = dr["BirthDate"].ToString(),
                        IdEnrollment = int.Parse(dr["IdEnrollment"].ToString())
                    };
                    students.Add(student);
                }
            }

            return students;
        }


        public Enrollment GetStudentEnrollment(string studentIndex)
        {
            using (var con =
                new SqlConnection(conString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                
                    
                com.CommandText = "select * from Enrollment where IdEnrollment = (select IdEnrollment from Student where Student.IndexNumber='@index')";
                com.Parameters.AddWithValue("index", studentIndex);
                con.Open();
                var dr = com.ExecuteReader();
                dr.Read();

                var enroll = new Enrollment
                {
                    IdEnrollment = int.Parse(dr["IdEnrollment"].ToString()),
                    IdStudy = int.Parse(dr["IdStudy"].ToString()),
                    Semester = int.Parse(dr["Semester"].ToString()),
                    StartDate = dr["StartDate"].ToString()
                };
                return enroll;
            }
        }
    }
}