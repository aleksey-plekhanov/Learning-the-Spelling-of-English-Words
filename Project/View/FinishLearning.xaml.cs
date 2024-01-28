using LSEW.ParsingText;
using Spelling_of_words.Models;
using Spelling_of_words.Properties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Spelling_of_words.View
{
    public partial class FinishLearning : Page
    {
        public FinishLearning(SecCounter timer)
        {
            InitializeComponent();

            if (!Settings.Default.DisableTimeCounting)
            {
                timer_label.Content = $"{timer.GetMinutes()} мин. {timer.GetSeconds()} сек.";
            }
            else
            {
                timer_label.Visibility = Visibility.Hidden;
                textlabel_timer.Visibility = Visibility.Hidden;
            }
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
