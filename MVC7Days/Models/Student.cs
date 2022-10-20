using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC7Days.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public IEnumerable<Student> _lstStudent { get; set; }
        public int DBStatus { get; set; }
        public enum ProcIDs
        {
            InsertStudent = 1,
            GetStudents = 2,
            UpdateStudent = 3,
            DeleteStudent = 4
        }
    }
}