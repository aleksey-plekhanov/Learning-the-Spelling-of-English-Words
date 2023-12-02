using LSEW.Models;
using Spelling_of_words.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Spelling_of_words.View
{
    public partial class LearningWords : Page
    {
        private List<Word> words;

        private int current_word_index = -1;
        private int timerCounter = 0;

        DispatcherTimer timer = new DispatcherTimer();

        public LearningWords(List<Word> words_)
        {
            InitializeComponent();

            // Загружаем слова
            words = words_;

            // Подгрузка первого слова, подсказок
            LoadFunctionalComponents();
        }

        public void LoadFunctionalComponents()
        {
            ShowNextWords();
            LoadHints();

            // (Настройка) Отображение время прохождения на экран
            if (!Settings.Default.DisableTimeCounting)
            {
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

        private void ShowHints()
        {
            string current_words = words[current_word_index].English.ToString();

            if (String.IsNullOrEmpty(current_words)) return;

            switch (choiceHintsBox.SelectedIndex)
            {
                case 0:
                    hints_label.Content = string.Empty;
                    break;
                case 1:
                    hints_label.Content = current_words.Length;
                    break;
                case 2:
                    hints_label.Content = current_words.Substring(0, 2);
                    break;
                case 3:
                    hints_label.Content = current_words.Substring(0, current_words.Length / 2);
                    break;
                case 4:
                    {
                        StringBuilder word = new StringBuilder(current_words);

                        for(int i = 0; i < word.Length; i++)
                        {
                            if(i % 2 != 0) 
                            {
                                word[i] = '-';
                            }
                        }

                        hints_label.Content = word.ToString();
                    }
                    break;
                case 5:
                    hints_label.Content = current_words;
                    break;
            }
        }

        private void ShowNextWords()
        {
            word_label.Content = words[++current_word_index].Russian.ToString();
            ShowHints();

            inputWord.Text = string.Empty;
            checkСorrectly.Content = string.Empty;
            btnNextWord.Visibility = Visibility.Hidden;
        }

        private void ResponseResult(SolidColorBrush colorBrush, string text)
        {
            checkСorrectly.Foreground = colorBrush;
            checkСorrectly.Content = text;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(inputWord.Text)) return;

            btnNextWord.Visibility = Visibility.Visible;

            Word current = words[current_word_index];

            if (inputWord.Text.ToLower() == current.English.ToLower())
            {
                ResponseResult(Brushes.Green, "Правильно!");
            }
            else ResponseResult(Brushes.Red, "Неправильно!");
        }

        private void btnNextWord_Click(object sender, RoutedEventArgs e)
        {
            if (current_word_index == words.Count - 1)
            {
                NavigationService.Navigate(new FinishLearning());
                return;
            }

            ShowNextWords();
        }

        private void btn_VDBack(object sender, MouseButtonEventArgs e)
        {
            timer.Stop();
            NavigationService.Navigate(new MainMenu());
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void choiceHintsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowHints();

            Settings.Default.choiseHints = choiceHintsBox.SelectedIndex;
            Settings.Default.Save();
        }
    }
}
