using LSEW.Models;
using LSEW.ParsingText;
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

namespace Spelling_of_words.View
{
    /// <summary>
    /// Логика взаимодействия для VocabularyDictation.xaml
    /// </summary>
    public partial class VocabularyDictation : Page
    {
        private List<Word> words;

        private int current_word_index = 0;
        private int correctWords = 0;

        public VocabularyDictation()
        {
            InitializeComponent();
            InitializeWords();
            ShowNextWords();
        }
        private void InitializeWords()
        {
            // TODO Если файл не найден
            words = ParsingTXT.ReadCsvFile(Settings.Default.PathFileWords);

            // Делаем рандомное положение слов в списке
            words = words.OrderBy(_ => new Random().Next()).ToList();
        }

        private void ShowNextWords()
        {
            word_label.Content = words[current_word_index++].Russian.ToString();

            inputWord.Text = string.Empty;
            checkСorrectly.Content = string.Empty;
            btn_check.Visibility = Visibility.Visible;
            btnNextWord.Visibility = Visibility.Hidden;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (current_word_index < words.Count - 1)
            {
                Word current = words[current_word_index];

                btnNextWord.Visibility = Visibility.Visible;

                if (inputWord.Text.ToLower() == current.English.ToLower())
                {
                    checkСorrectly.Content = "Правильно!";
                    checkСorrectly.Foreground = Brushes.Green;
                    quantityScore.Content = ++correctWords;

                    btn_check.Visibility = Visibility.Hidden;
                }
                else
                {
                    checkСorrectly.Content = "Неправильно!";
                    checkСorrectly.Foreground = Brushes.Red;
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
