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
    /// Interaction logic for ToDoPage.xaml
    /// </summary>
    public partial class ToDoPage : UserControl
    {
        string id;
        FinalProject.Logic.InsertControl ic = new Logic.InsertControl();
        FinalProject.Logic.Control c = new Logic.Control();
        int count = 0;
        public ToDoPage()
        {
            InitializeComponent();
            id = Properties.Settings.Default.UserID;
        }
        

        void cb_Unchecked(object sender, RoutedEventArgs e)
        {
            
            ic.DeleteToDo((sender as CheckBox).Content, id);
            stackPanel.Children.Remove((sender as CheckBox));
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (tb.Text != "")
                {
                    CheckBox cb = new CheckBox();
                    cb.Content = tb.Text;
                    cb.IsChecked = true;
                    cb.FontSize = 20;
                    cb.FontFamily = new FontFamily("Franklin Gothic Heavy");
                    ic.InsertToDo(tb.Text, id);
                    stackPanel.Children.Add(cb);
                    cb.Unchecked += cb_Unchecked;
                    tb.Text = null;
                }
            }
        }

        private void tb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tb.Text = null;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (count == 0)
            {
                var m = c.GetToDos(id);
                foreach (var n in m)
                {
                    CheckBox cb = new CheckBox();
                    cb.Content = n.ToDo;
                    cb.IsChecked = true;
                    cb.FontSize = 20;
                    cb.FontFamily = new FontFamily("Franklin Gothic Heavy");
                    stackPanel.Children.Add(cb);
                    cb.Unchecked += cb_Unchecked;
                }
                count++;
            }
        }
    }
}
