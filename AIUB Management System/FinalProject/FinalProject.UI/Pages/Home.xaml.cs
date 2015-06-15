using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
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
using System.Windows.Threading;

namespace FinalProject.UI.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        FinalProject.Logic.Control c;
        DispatcherTimer dispatcherTimer;
        
        public Home()
        {
            InitializeComponent();
            usernameTB.Text = Properties.Settings.Default.Username;
            passwordTB.Password = Properties.Settings.Default.Password;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0);
            dispatcherTimer.Start(); 
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimeTB.Text = DateTime.Now.ToString("F");
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                c = new Logic.Control();
                string user = usernameTB.Text;


                string s = c.GetPassword(user);

                if (s == passwordTB.Password)
                {
                    Properties.Settings.Default.UserID = usernameTB.Text;

                    if (RememberCB.IsChecked == true)
                    {
                        Properties.Settings.Default.Username = usernameTB.Text;
                        Properties.Settings.Default.Password = passwordTB.Password;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Username = null;
                        Properties.Settings.Default.Password = null;
                        Properties.Settings.Default.Save();
                    }

                    
 
                    var frame = NavigationHelper.FindFrame(null, this);
                    if (frame != null)
                    {
                        frame.Source = new Uri ("Pages/TabPage.xaml", UriKind.Relative);
                    }
                    //this.IsEnabled = false;
                    

                    
                }
                else
                    TryAgainTB.Text = "Please Try Again";
                

            }
            catch
            {
                TryAgainTB.Text = "Please enter valid username & password";

            }


        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            usernameTB.Text = null;
            passwordTB.Password = null;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = NavigationHelper.FindFrame(null, this);
            if (frame != null)
            {
                frame.Source = new Uri("Pages/TabPage.xaml", UriKind.Relative);
            }
        }

        private void passwordTB_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            
            if (e.KeyboardDevice.IsKeyDown(Key.Tab))
            passwordTB.SelectAll();

        }

        
    }
}
