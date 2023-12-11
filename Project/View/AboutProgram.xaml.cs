using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Spelling_of_words.View
{
    /// <summary>
    /// Логика взаимодействия для AboutProgram.xaml
    /// </summary>
    public partial class AboutProgram : Page
    {
        public AboutProgram()
        {
            InitializeComponent();
        }

        private void btn_AboutBack(object sender, MouseButtonEventArgs e){
            NavigationService.GoBack();
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
