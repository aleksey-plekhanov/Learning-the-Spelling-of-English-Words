using LSEW.ParsingText;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Spelling_of_words.View
{
    public partial class FinishLearning : Page
    {
        public FinishLearning()
        {
            InitializeComponent();
        }

        private void btn_startLearningAgain(object sender, RoutedEventArgs e)
        {
            var words = ParsingTXT.ReadFile();
            if (words.Count == 0) return;

            NavigationService.Navigate(new LearningWords(words));
        }

        private void btn_returnMainMenu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void btn_FLBack(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
