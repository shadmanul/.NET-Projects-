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
    /// Interaction logic for Inbox.xaml
    /// </summary>
    public partial class Inbox : UserControl
    {
           
        FinalProject.Logic.Control c = new Logic.Control();
        string id;
        int count = 0;
        //int i = 0;
        //string[] Array = new string[1000];
        List<FinalProject.Data.Messaging> m;
        public Inbox()
        {
            InitializeComponent();
            //id = Properties.Settings.Default.UserID.Replace(" ", string.Empty);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                id = Properties.Settings.Default.UserID.Replace(" ", string.Empty);
                try
                {
                    m = c.GetMessage(id);
                     
                    
                    foreach (var msg in m)
                    {


                        SubjectList.Items.Insert(0, "From: " + c.GetName(msg.From)
                            + "\nSubject: " + msg.Subject
                            + "\nTime: " + msg.Time
                            + "\n\nMessage: " + msg.Message);
                        
                    }
                    count++;
                }
                catch
                {

                }
            }
        }

        private void SubjectList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            //MessageBox.Show(m[SubjectList.SelectedIndex].Message);
            try
            {
                if (SubjectList.SelectedItem != null)
                {
                    MessageBox.Show(SubjectList.SelectedItem.ToString());
                }
            }
            catch
            {

            }
        }
    }
}
