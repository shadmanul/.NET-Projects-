using FinalProject.UI.Content;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
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

namespace FinalProject.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ModernWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsAppearanceViewModel s = new SettingsAppearanceViewModel();
            s.SelectedTheme = s.themes.FirstOrDefault(l => l.Source.Equals(AppearanceManager.DarkThemeSource));
            //Properties.Settings.Default.UserID = null;
            
        }
    }
}
