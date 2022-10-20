using MVC7Days.Models;
using MVC7Days.RepositoryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC7Days.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Session["StudentID"] = "zul@gmail.com";
            return RedirectToAction("Registration");
        }

        public ActionResult Registration()
        {
            return View(GetStudents());
        }

        [HttpPost]
        public ActionResult Registration(Student stu, string btnsubmit)
        {
            Repository rep = new Repository();

            if (btnsubmit == "update")
            {
                var res = rep.InsertUpdateOrDeleteStudent(stu, Student.ProcIDs.UpdateStudent);

                if (res.DBStatus > 0)
                    TempData["Message"] = "Data Updated";
                else
                    TempData["Message"] = "Data Not Updated";
            }
            else
            {
                var res = rep.InsertUpdateOrDeleteStudent(stu, Student.ProcIDs.InsertStudent);

                if (res.StudentID > 0)
                    TempData["Message"] = "Data Inserted";
                else
                    TempData["Message"] = "Data Not Inserted";
            }



            return RedirectToAction("Registration", "Student");
        }

        private Student GetStudents()
        {
            Repository r = new Repository();
            var lstStudent = r.GetStudents();

            var st = new Student
            {
                _lstStudent = lstStudent
            };

            return st;
        }

        [HttpGet]
        public ActionResult DeleteStudent(int StudentID = 0)
        {
            if (StudentID > 0)
            {
                Repository r = new Repository();
                var stu = new Student { StudentID = StudentID };
                var res = r.InsertUpdateOrDeleteStudent(stu, Student.ProcIDs.DeleteStudent);
                if (res.DBStatus > 0)
                {
                    TempData["Message"] = "Record Deleted";
                }
                else
                {
                    TempData["Message"] = "Record Not Deleted";
                }
            }

            return RedirectToAction("Registration", "Student");
        }

        public ActionResult ShowRegistration()
        {
            return View();
        }
    }
}