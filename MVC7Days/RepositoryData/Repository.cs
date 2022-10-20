using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using MVC7Days.Models;

namespace MVC7Days.RepositoryData
{
    public class Repository
    {
        DynamicParameters dp = new DynamicParameters();

        public Student InsertUpdateOrDeleteStudent(Student stu, Student.ProcIDs procIDs)
        {
            using (IDbConnection _dbConnection = ConnectionStrings.GetDBConnection())
            {
                dp.Add("@ProcID", procIDs); //-->This is good practice
                dp.Add("@StudentName", stu.StudentName);
                dp.Add("@Age", stu.Age);
                dp.Add("@StudentID", stu.StudentID);

                var res = _dbConnection.QueryFirst<Student>("dbo.proc_student", dp, null, null, CommandType.StoredProcedure);
                return res;
            }
        }


        public IEnumerable<Student> GetStudents()
        {
            using (IDbConnection _dbConnection = ConnectionStrings.GetDBConnection())
            {
                dp.Add("@ProcID", Student.ProcIDs.GetStudents); //-->This is good practice

                var res = _dbConnection.Query<Student>("dbo.proc_student", dp, commandType: CommandType.StoredProcedure);
                return res;
            }
        }

    }
}