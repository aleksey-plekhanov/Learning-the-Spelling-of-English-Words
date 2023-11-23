using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Spelling_of_words.View
{
    /// <summary>
    /// Логика взаимодействия для StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Page
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void btn_Start(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new MainMenu());
        }

        private void btn_About(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new AboutProgram());
        }

        private void textlabel_Github(object sender, MouseButtonEventArgs e) {
            Process.Start("https://github.com/alexgger");
        }

        private void btn_CloseApp(object sender, MouseButtonEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
