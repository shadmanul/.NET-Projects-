using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalProject.UI.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : UserControl
    {

        string id;
        FinalProject.Logic.Control c = new Logic.Control();
        public ProfilePage()
        {
            InitializeComponent();
            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                id = Properties.Settings.Default.UserID.Replace(" ", string.Empty);
                if (id.Length == 10)
                {
                    var student = c.GetStudentInfo(id).FirstOrDefault();
                    studentIDTB.Text = student.ID;
                    nameTB.Text = student.LastName + ", " + student.FirstName; ;
                    departmentTB.Text = student.Department;
                    semesterTB.Text = student.Semester;
                    creditCompletedTB.Text = student.CreditCompleted.ToString();
                    dateOfBirthTB.Text = student.DateOfBirth.ToShortDateString();
                    bloodGroupTB.Text = student.BloodGroup;
                    fathersNameTB.Text = student.FatherName;
                    fatherNumberTB.Text = student.FatherNumber;
                    mothersNameTB.Text = student.MotherName;
                    motherNumberTB.Text = student.MotherNumber;
                    guardianNameTB.Text = student.GuardianName;
                    guardianNumberTB.Text = student.GuardianNumber;
                    addressTB.Text = student.Address;
                    mobileTB.Text = student.Mobile;
                    emailTB.Text = student.Email;
                    CGPATB.Text = student.CGPA.ToString(); ;
                }
                else if (id.Length == 13)
                {
                    var faculty = c.GetFacultyInfo(id).FirstOrDefault();
                    tb1.Text = "Faculty ID";
                    studentIDTB.Text = faculty.EmployeeID;
                    tb2.Text = "Name";
                    nameTB.Text = faculty.LastName + ", " + faculty.FirstName;
                    tb3.Text = "Address";
                    departmentTB.Text = faculty.Address;
                    tb4.Text = "City";
                    semesterTB.Text = faculty.City;
                    tb5.Text = "Country";
                    creditCompletedTB.Text = faculty.Country;
                    tb6.Text = "Department";
                    dateOfBirthTB.Text = faculty.Department;
                    tb7.Text = "Phone No.";
                    bloodGroupTB.Text = faculty.PhoneNumber;
                    tb8.Text = "Salary";
                    fathersNameTB.Text = faculty.Salary.ToString() + " BDT";
                    tb9.Text = "Email";
                    tb0.Text = "Date of Birth";
                    CGPATB.Text = faculty.DateOfBirth.Value.ToShortDateString();
                    fatherNumberTB.Text = faculty.Email;
                    
                    stack1.Children.Remove(tb10);
                    stack1.Children.Remove(tb11);
                    stack1.Children.Remove(tb12);
                    stack1.Children.Remove(tb13);
                    stack1.Children.Remove(tb14);
                    stack1.Children.Remove(tb15);
                    stack1.Children.Remove(tb16);
                    stack2.Children.Remove(mothersNameTB);
                    stack2.Children.Remove(motherNumberTB);
                    stack2.Children.Remove(guardianNameTB);
                    stack2.Children.Remove(guardianNumberTB);
                    stack2.Children.Remove(addressTB);
                    stack2.Children.Remove(emailTB);
                    stack2.Children.Remove(mobileTB);

                    
                    
                }

                
            }
            catch(Exception ex)
            {
                
            }
            
        }
    }
    
}
