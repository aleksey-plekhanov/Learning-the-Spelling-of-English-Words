using LSEW;
using LSEW.ParsingText;
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
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btn_learnWords(object sender, RoutedEventArgs e) {

            var words = ParsingTXT.ReadFile();
            if (words == null || words.Count() == 0)
            {
                MessageBox.Show("Выбранный файл не читается программой.\nПосмотрите еще раз инструкцию!", "Изучение правописания слов | Ошибка чтения файла");
                return;
            }

            NavigationService.Navigate(new LearningWords(words));
        }
        private void btn_Dictation(object sender, RoutedEventArgs e) 
        {
            var words = ParsingTXT.ReadFile();
            if(words == null || words.Count() == 0)
            {
                MessageBox.Show("Выбранный файл не читается программой.\nПосмотрите еще раз инструкцию!", "Диктант | Ошибка чтения файла");
                return;
            }

            NavigationService.Navigate(new VocabularyDictation(words));
        }

        private void btn_Manual(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(MainWindow.ManualProgram_);
        }

        private void btn_Settings(object sender, RoutedEventArgs e) {
            NavigationService.Navigate(MainWindow.SettingsUser_);
        }

        private void btn_Files(object sender, RoutedEventArgs e) {

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
