using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Spelling_of_words.View
{
    public partial class StartMenu : Page
    {
        AboutProgram about_program = new AboutProgram();

        public StartMenu()
        {
            InitializeComponent();
        }

        private void btn_Start(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new MainMenu());
        }

        private void btn_About(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(about_program);
        }

        private void btn_CloseApp(object sender, MouseButtonEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
