using LSEW.Models;
using Spelling_of_words.Properties;
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
using System.Windows.Threading;

namespace Spelling_of_words.View
{
    public partial class LearningWords : Page
    {
        private List<Word> words;

        private int current_word_index = 0;
        private int correctWords = 0;
        private int timerCounter = 0;

        private static Random rng = new Random();

        public LearningWords()
        {
            InitializeComponent();
            LoadHints();

            // (Настройка) Отображение время прохождения на экран
            if (!Settings.Default.DisableTimeCounting)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            else
            {
                timer_label.Visibility = Visibility.Hidden;
                textlabel_timer.Visibility = Visibility.Hidden;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (timerCounter > 60)
            {
                int minutes = Convert.ToInt32(timerCounter / 60);
                int seconds = timerCounter - minutes * 60;
                timer_label.Content = $"{minutes} мин. {seconds} сек.";
            }
            else timer_label.Content = $"{timerCounter} сек.";

            timerCounter++;
        }

        private void LoadHints()
        {
            choiceHintsBox.ItemsSource = new List<string>()
            {
                "Не использовать подсказки",
                "Подсказывать количество букв",
                "Подсказывать первые две буквы",
                "Подсказывать половину слова",
                "Подсказывать каждую вторую букву",
                "Показывать полностью правописание"
            };

            choiceHintsBox.SelectedIndex = Settings.Default.choiseHints;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnNextWord_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_VDBack(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void choiceHintsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Settings.Default.choiseHints = choiceHintsBox.SelectedIndex;
            Settings.Default.Save();
        }
    }
}
