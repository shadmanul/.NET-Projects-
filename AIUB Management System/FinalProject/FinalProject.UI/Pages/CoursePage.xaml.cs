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
    /// Interaction logic for CoursePage.xaml
    /// </summary>
    public partial class CoursePage : UserControl
    {
        FinalProject.Logic.Control c = new Logic.Control();
        string id;
        List<FinalProject.Data.Grade> n;
        public CoursePage()
        {
            InitializeComponent();
        }

        //private void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
            
        //}

        

        

        private void semesterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            id = Properties.Settings.Default.UserID;
            if (id.Length == 10)
            {
                try
                {

                    CourseList.Items.Clear();
                    n = c.GetCourses(id, semesterCB.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", string.Empty));
                    foreach (var crs in n)
                    {
                        CourseList.Items.Insert(0, "Course ID: " + crs.CourseID 
                            + "\nCourse Name: " + c.GetCourseName(crs.CourseID) 
                            + "\nCredit: " + c.GetCredit(crs.CourseID) 
                            + "\nFaculty: " + c.GetName(crs.EmployeeID));
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (id.Length > 10)
            {
                try
                {
                    
                    CourseList.Items.Clear();

                    var m = c.GetFacultyID(id);
                    var f = c.GetCourseID(m.ToString(), semesterCB.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", string.Empty)).GroupBy(test => test.CourseID).Select(group => group.First());
                    foreach(var crs in f)
                    {
                        CourseList.Items.Insert(0, "Course ID: " + crs.CourseID
                            + "\nCourse Name: " + c.GetCourseName(crs.CourseID)
                            + "\nCredit: " + c.GetCredit(crs.CourseID));

                            //+ "\nCourse Name: " + c.GetCourseName(Convert.ToInt32(c.GetCourseID(crs.EmployeeID))));
                            
                    }
                    
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
