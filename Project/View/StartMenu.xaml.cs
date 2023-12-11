using LSEW;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Spelling_of_words.View
{
    public partial class StartMenu : Page
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void btn_Start(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(MainWindow.MainMenu_);
        }

        private void btn_About(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(MainWindow.AboutProgram_);
        }

        private void btn_CloseApp(object sender, MouseButtonEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
