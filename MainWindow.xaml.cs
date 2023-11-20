using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Microsoft.VisualBasic.FileIO;
using LSEW.Models;
using System.Globalization;
using System.IO;
using System.Windows.Media.Media3D;
using CsvHelper;
using Microsoft.VisualBasic.ApplicationServices;
using LSEW.ParsingText;

// Learning the Spelling of English Words (LSEW)

namespace LSEW
{

    public partial class MainWindow : Window
    {
        private List<Word> words;
        
        private int current_word_index = 0;
        private int correctWords = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWords();
            ShowNextWords();
        }

        private void InitializeWords()
        {
            // TODO Если файл не найден
            words = ParsingTXT.ReadCsvFile(@"D:\Documents\test.csv");

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
            if(current_word_index < words.Count - 1)
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
    }
}
