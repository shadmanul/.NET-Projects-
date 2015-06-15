using FinalProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Logic
{
    public class InsertControl
    {
        FinalProject.Data.DataContext dataContext = new Data.DataContext();
        public InsertControl()
        {
            dataContext.DeferredLoadingEnabled = false;
        }
        public void SendMessage(string to,string subject,string body,string from, string time)
        {
            Messaging m = new Messaging()
            {
                ID = to,
                Subject = subject,
                Message = body,
                From = from,
                Time = time
            };

            dataContext.GetTable<Messaging>().InsertOnSubmit(m);
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {

            } 
        }



        public void AddNewStudent(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12, string p13, string p14, string p15, string p16, string p17, string p18, string p19)
        {
            LoginInfo l = new LoginInfo()
            {
                ID = p1,
                Password = p2,
                Status = p3
            };
            dataContext.GetTable<LoginInfo>().InsertOnSubmit(l);
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {

            }

            StudentInfo s = new StudentInfo()
            {
                ID = p1,
                FirstName = p4,
                LastName = p5,
                Department = p6,
                Semester = p7,
                CreditCompleted = Convert.ToInt32(p8),
                DateOfBirth = Convert.ToDateTime(p9),
                BloodGroup = p10,
                FatherName = p11,
                FatherNumber = p12,
                MotherName = p13,
                MotherNumber = p14,
                GuardianName = p15,
                GuardianNumber = p16,
                Address = p17,
                Mobile = p18,
                Email = p19,
                CGPA = 0
            };
            dataContext.GetTable<StudentInfo>().InsertOnSubmit(s);
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {

            }
 
        }

        public void AddNewFaculty(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12, string p13)
        {
            LoginInfo l = new LoginInfo()
            {
                ID = p1,
                Password = p2,
                Status = p3
            };
            dataContext.GetTable<LoginInfo>().InsertOnSubmit(l);
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {

            }
            Faculty f = new Faculty()
            {
                EmployeeID = p1,
                FirstName = p4,
                LastName = p5,
                Address = p6,
                City = p7,
                Country = p8,
                PhoneNumber = p9,
                Email = p10,
                Salary = Convert.ToDouble(p11),
                Department = p12,
                DateOfBirth = Convert.ToDateTime(p13)
            };
            dataContext.GetTable<Faculty>().InsertOnSubmit(f);
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public void InsertToDo(string p, string id)
        {
            ToDosTable t = new ToDosTable()
            {
                ToDo = p,
                ID = id
            };
            dataContext.GetTable<ToDosTable>().InsertOnSubmit(t);
            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteToDo(object q, string id)
        {
            var t = from p in dataContext.ToDosTables
                    where p.ID == id && p.ToDo == q
                    select p;

            foreach (var p in t)
            {
                dataContext.ToDosTables.DeleteOnSubmit(p);
            }

            try
            {
                dataContext.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
        }
    }
}
