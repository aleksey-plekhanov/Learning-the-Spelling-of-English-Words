using LSEW.Models;
using Spelling_of_words.Properties;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;


namespace Spelling_of_words.View
{
    public partial class VocabularyDictation : Page 
    {
        private List<Word> words;
        private List<Word> incorrect_words = new List<Word>();

        private int current_word_index = -1;
        private int correctWords = 0;

        private int timerCounter = 0;
        private int timerCountDown = 0;

        private DispatcherTimer time_working = new DispatcherTimer();
        private DispatcherTimer timer_limited = new DispatcherTimer();

        public VocabularyDictation(List<Word> words_)
        {
            InitializeComponent();

            // Загрузка слов с файла
            words = words_;

            if (Settings.Default.TimeLimiter)
            {
                timer_limited.Interval = TimeSpan.FromSeconds(1);
                timer_limited.Tick += new EventHandler(timerLimited_Tick);
                timer_limited.Start();
            }
            else
            {
                textlabel_timerLimited.Visibility = Visibility.Hidden;
                timerLimited_label.Visibility = Visibility.Hidden;
            }

            ShowNextWords();

            // (Настройка) Отображение время прохождения на экран
            if (!Settings.Default.DisableTimeCounting)
            {
                time_working.Interval = TimeSpan.FromSeconds(1);
                time_working.Tick += new EventHandler(timer_Tick);
                time_working.Start();
            }
            else {
                timer_label.Visibility = Visibility.Hidden;
                textlabel_timer.Visibility = Visibility.Hidden;
            }

            // (Настройка) Показывать результат ответа на экран
            if(Settings.Default.NotDisplayingResponseResult) {
                labelScore.Visibility = Visibility.Hidden;
                quantityScore.Visibility = Visibility.Hidden;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if(timerCounter > 60)
            {
                int minutes = Convert.ToInt32(timerCounter / 60);
                int seconds = timerCounter - minutes * 60;
                timer_label.Content = $"{minutes} мин. {seconds} сек.";
            }
            else timer_label.Content = $"{timerCounter} сек.";

            timerCounter++;
        }

        void timerLimited_Tick(object sender, EventArgs e)
        {
            int time = Settings.Default.limitedTime - timerCountDown;

            if (timerCountDown <= Settings.Default.limitedTime)
            {
                timerLimited_label.Content = $"{time} сек.";
                timerCountDown++;
            }
            else btnNextWord_Click(sender, e);
        }

        private void ShowNextWords()
        {
            word_label.Content = words[++current_word_index].Russian.ToString();

            inputWord.Text = string.Empty;
            checkСorrectly.Content = string.Empty;
            btn_check.Visibility = Visibility.Visible;
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
            btn_check.Visibility = Visibility.Hidden;

            Word current = words[current_word_index];

            if(inputWord.Text.ToLower() == current.English.ToLower())
            {
                quantityScore.Content = ++correctWords;
                if(!Settings.Default.NotDisplayingResponseResult) {
                    ResponseResult(Brushes.Green, "Правильно!");
                }
            }
            else
            {
                if (!Settings.Default.NotDisplayingResponseResult) {
                    ResponseResult(Brushes.Red, "Неправильно!");
                }
                incorrect_words.Add(current);
            }

            if (Settings.Default.TimeLimiter)
            {
                timer_limited.Stop();
            }
        }

        private void btnNextWord_Click(object sender, EventArgs e)
        {
            if (current_word_index == words.Count - 1)
            {
                if (Settings.Default.TimeLimiter)
                {
                    timer_limited.Stop();
                }

                NavigationService.Navigate(new AssessmentDication(correctWords, words.Count, incorrect_words));
                return;
            }

            if (Settings.Default.TimeLimiter)
            {
                timerCountDown = 0;
                incorrect_words.Add(words[current_word_index]);
                timer_limited.Start();
            }

            ShowNextWords();
        }

        private void btn_VDBack(object sender, MouseButtonEventArgs e)
        {
            time_working.Stop();
            NavigationService.GoBack();
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
