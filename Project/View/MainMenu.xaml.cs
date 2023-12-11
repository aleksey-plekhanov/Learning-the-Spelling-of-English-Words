using LSEW;
using LSEW.ParsingText;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Spelling_of_words.View
{
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn_learnWords(object sender, RoutedEventArgs e) {

            var words = ParsingTXT.ReadFile();
            if (words.Count() == 0) return;

            NavigationService.Navigate(new LearningWords(words));
        }
        private void btn_Dictation(object sender, RoutedEventArgs e) 
        {
            var words = ParsingTXT.ReadFile();
            if (words.Count() == 0) return;
            NavigationService.Navigate(new VocabularyDictation(words));
        }

        private void btn_Manual(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(MainWindow.ManualProgram_);
        }

        private void btn_Settings(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(MainWindow.SettingsUser_);
        }

        private void btn_Files(object sender, RoutedEventArgs e) {
            Process.Start("https://github.com/alexgger/Learning-the-Spelling-of-English-Words/tree/master/Ready-made-files-with-words");
        }

        private void btn_MainWindowBack(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(MainWindow.StartMenu_);
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
