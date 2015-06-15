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
using FinalProject.Data;

namespace FinalProject.UI.Pages
{
    /// <summary>
    /// Interaction logic for WriteMessage.xaml
    /// </summary>
    public partial class WriteMessage : UserControl
    {
        FinalProject.Logic.InsertControl ic = new Logic.InsertControl();
        string id;
        public WriteMessage()
        {
            InitializeComponent();
            
            id = Properties.Settings.Default.UserID.Replace(" ", string.Empty);
        }
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                ic.SendMessage(ToTB.Text, SubjectTB.Text, BodyTB.Text, id, DateTime.Now.ToString("F"));
                
                MessageBox.Show("Sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
