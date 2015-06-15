using FinalProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Logic
{
    public class Control
    {
        FinalProject.Data.DataContext dataContext = new FinalProject.Data.DataContext();
        public Control()
        {
            dataContext.DeferredLoadingEnabled = false;
            dataContext.ObjectTrackingEnabled = false;
        }

        public string GetPassword(string username)
        {
            

            return (from p in dataContext.LoginInfos
                    where p.ID == username
                    select p).FirstOrDefault().Password;
        }
        public string GetStatus(string username)
        {
            

            return (from p in dataContext.LoginInfos
                    where p.ID == username
                    select p).FirstOrDefault().Status;
        }
        public string GetName(string username)
        {
            if (username.Length == 10)
            {
                return (from p in dataContext.StudentInfos
                        where p.ID == username
                        select p).FirstOrDefault().LastName + ", "+(from p in dataContext.StudentInfos
                                                                   where p.ID == username
                                                                   select p).FirstOrDefault().FirstName;
            }
            else
            {
                return (from p in dataContext.Faculties
                        where p.EmployeeID == username
                        select p).FirstOrDefault().LastName + ", " + (from p in dataContext.Faculties
                                                                      where p.EmployeeID == username
                                                                      select p).FirstOrDefault().FirstName;
            }
        }
        public List<StudentInfo> GetStudentInfo(string username)
        {
            

            return (from p in dataContext.StudentInfos
                    where p.ID == username
                    select p).ToList();
        }
        public List<Faculty> GetFacultyInfo(string username)
        {
            
            return (from p in dataContext.Faculties
                    where p.EmployeeID == username
                    select p).ToList();
        }
        public List<Messaging> GetMessage(string username)
        {
            return (from p in dataContext.Messagings
                    where p.ID == username
                    select p).ToList();
        }
        public List<Grade> GetCourses(string id,string semester)
        {
            return (from p in dataContext.Grades
                    where p.StudentID == id && p.Semester == semester
                    select p).ToList();
        }

        public string GetCourseName(int p)
        {
            return (from q in dataContext.Courses
                    where q.CourseID == p
                    select q).FirstOrDefault().CourseName;
        }

        public int GetCredit(int p)
        {
            return (from q in dataContext.Courses
                    where q.CourseID == p
                    select q).FirstOrDefault().Cedit;
        }




        public List<Grade> GetCourseID(string p, string sem)
        {
            return (from q in dataContext.Grades
                    where q.EmployeeID == p && q.Semester == sem
                    select q).ToList();
        }

        public object GetFacultyID(string id)
        {
            return (from q in dataContext.Faculties
                    where q.EmployeeID == id
                    select q).FirstOrDefault().EmployeeID;
        }

        public List<ToDosTable> GetToDos(string id)
        {
            return (from p in dataContext.ToDosTables
                    where p.ID == id
                    select p).ToList();
        }
        public List<Messaging> GetSentMessage(string username)
        {
            return (from p in dataContext.Messagings
                    where p.From == username
                    select p).ToList();
        }
    }
}
