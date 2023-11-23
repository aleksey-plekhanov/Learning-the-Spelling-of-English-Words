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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn_learnWords(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new LearningWords());
        }
        private void btn_Dictation(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new VocabularyDictation());
        }

        private void btn_Manual(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new ManualProgram());
        }

        private void btn_Settings(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(new SettingsUser());
        }

        private void btn_Files(object sender, RoutedEventArgs e) {

        }

        private void textlabel_Github(object sender, MouseButtonEventArgs e) {
            Process.Start("https://github.com/alexgger");
        }

        private void btn_MainWindowBack(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
