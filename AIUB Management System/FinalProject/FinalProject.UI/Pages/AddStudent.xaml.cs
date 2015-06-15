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
    /// Interaction logic for AddSudent.xaml
    /// </summary>
    public partial class AddStudent : UserControl
    {

        FinalProject.Logic.InsertControl c = new Logic.InsertControl();
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                c.AddNewStudent(studentIDTB.Text, passwordTB.Text, statusTB.Text, firstNameTB.Text, lastNameTB.Text,
                    departmentTB.Text, semesterTB.Text, creditCompletedTB.Text, dateOfBirthTB.Text,
                    bloodGroupTB.Text, fathersNameTB.Text, fatherNumberTB.Text, mothersNameTB.Text,
                    motherNumberTB.Text, guardianNameTB.Text, guardianNumberTB.Text, addressTB.Text,
                    mobileTB.Text, emailTB.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("ADDED");
            }


        }

        private void statusTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as TextBox).Text = null;
        }

       

        

    }
}
