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
    /// Interaction logic for SentMessages.xaml
    /// </summary>
    public partial class SentMessages : UserControl
    {
        FinalProject.Logic.Control c = new Logic.Control();
        string id;
        int count = 0;
        List<FinalProject.Data.Messaging> m;
        public SentMessages()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                id = Properties.Settings.Default.UserID.Replace(" ", string.Empty);
                try
                {
                    var m = c.GetSentMessage(id);


                    foreach (var msg in m)
                    {


                        MessageList.Items.Insert(0, "To: " + c.GetName(msg.ID) 
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
            try
            {
                if (MessageList.SelectedItem != null)
                {
                    MessageBox.Show(MessageList.SelectedItem.ToString());
                }
            }
            catch
            {

            }
        }
    }
}
