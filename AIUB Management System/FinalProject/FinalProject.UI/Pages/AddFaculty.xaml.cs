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
    /// Interaction logic for AddFaculty.xaml
    /// </summary>
    public partial class AddFaculty : UserControl
    {
        
        FinalProject.Logic.InsertControl c = new Logic.InsertControl();
        public AddFaculty()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                c.AddNewFaculty(employeeIDTB.Text, passwordTB.Text, statusTB.Text,
                    firstNameTB.Text, lastNameTB.Text, addressTB.Text, cityTB.Text,
                    countryTB.Text, phoneNoTB.Text, emailTB.Text, salaryTB.Text, 
                    departmentTB.Text, dateOfBirthTB.Text);
                MessageBox.Show("ADDED");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void statusTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            statusTB.Text = null;
        }

        private void dateOfBirthTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            dateOfBirthTB.Text = null;
        }
    }
}
