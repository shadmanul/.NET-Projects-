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
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace FinalProject.UI.Pages
{
    /// <summary>
    /// Interaction logic for MailPage.xaml
    /// </summary>
    public partial class MailPage : UserControl
    {
        string a1, a2, a3;
        public MailPage()
        {
            InitializeComponent();
        }
        private string DialogBox()
        {
            string filePath = null;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "All Files *.*|*.*";
            dlg.Title = "Attach File";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                filePath = dlg.FileName.ToString();
            }
            else
                filePath = "No Attachment";
            return filePath;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a1 = DialogBox();
            a1Button.Content = a1;
        }
        

        private void a2Button_Click(object sender, RoutedEventArgs e)
        {
            a2 = DialogBox();
            a2Button.Content = a2;
        }

        private void a3Button_Click(object sender, RoutedEventArgs e)
        {
            a3 = DialogBox();
            a3Button.Content = a3;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage m = new MailMessage();
                m.From = new MailAddress(UserMailTB.Text);
                m.To.Add(new MailAddress(ToTB.Text));

                m.Subject = SubjectTB.Text;
                m.Body = BodyTB.Text;
                if (a1 != null)
                    m.Attachments.Add(new Attachment(a1));
                if (a2 != null)
                    m.Attachments.Add(new Attachment(a2));
                if (a3 != null)
                    m.Attachments.Add(new Attachment(a3));
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                if (UserMailTB.Text.Contains("@gmail.com"))
                {
                    smtp.Host = "smtp.gmail.com";
                }
                if (UserMailTB.Text.Contains("@yahoo.com"))
                {
                    smtp.Host = "smtp.mail.yahoo.com";
                }
                if (UserMailTB.Text.Contains("@hotmail.com"))
                {
                    smtp.Host = "smtp.live.com";
                }
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(UserMailTB.Text, MailPasswordTB.Password);
                smtp.Send(m);
                MessageBox.Show("MAIL SENT");
                //ComfirmTB.Text = "MAIL SENT";
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        
        }

        private void UserMailTB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UserMailTB.Text = null;
            //UserMailTB.Foreground = Brushes.Black;
        }
    }
    
}
