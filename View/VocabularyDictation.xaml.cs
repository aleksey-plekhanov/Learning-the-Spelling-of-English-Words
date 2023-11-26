using LSEW.Models;
using LSEW.ParsingText;
using Spelling_of_words.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
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
    public partial class VocabularyDictation : Page
    {
        private List<Word> words;

        private int current_word_index = 0;
        private int correctWords = 0;
        private int timerCounter = 0;

        private static Random rng = new Random();

        public VocabularyDictation()
        {
            InitializeComponent();
            InitializeWords();
            ShowNextWords();

            // (Настройка) Отображение время прохождения на экран
            if (!Settings.Default.DisableTimeCounting)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
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

        private void InitializeWords()
        {
            try
            {
                // TODO - ПРОВЕРКА
                words = ParsingTXT.ReadTXTFile(Settings.Default.PathFileWords);

                if (Settings.Default.GenerateRandomWords) {
                    words = words.OrderBy(a => rng.Next()).ToList();
                }

                MessageBox.Show($"Загружено {words.Count} слов(а)", "Слова из файла");
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

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
            if (current_word_index < words.Count - 1)
            {
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
                }
            }
            else
            {
                inputWord.Text = $"Слова закончились! Вы ответили правильно {correctWords} из {words.Count}";
            }
        }

        private void btnNextWord_Click(object sender, RoutedEventArgs e)
        {
            ShowNextWords();
        }

        private void btn_VDBack(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
