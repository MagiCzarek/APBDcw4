using APBDcw4.Models;
using System.Collections.Generic;


namespace APBDcw4.Services
{
     interface IStudentService
    {
         IEnumerable<Student> GetStudents();
         Enrollment GetStudentEnrollment(string studentIndex);
    }
}