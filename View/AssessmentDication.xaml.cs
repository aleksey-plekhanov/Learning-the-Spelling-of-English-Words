using LSEW.Models;
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
    public partial class AssessmentDication : Page
    {
        // Неправильные написанные слова
        private List<Word> incorrect_words_;

        public AssessmentDication(int correct_answers, int count_questions, List<Word> incorrect_words)
        {
            InitializeComponent();
            CalculateEstimation(correct_answers, count_questions);

            // Загрузка неправильно написанных слов пользователем
            incorrect_words_ = incorrect_words;

            // Отображение количества баллов в статистике
            label_countscore.Content = $"{correct_answers} из {count_questions}";
        }

        private void CalculateEstimation(int correct_answers, int count_questions)
        {
            int estimation_procent = correct_answers * 100 / count_questions;

            if (estimation_procent < 50)
            {
                label_estimation.Content = "2";
            }
            else if (estimation_procent >= 50 && estimation_procent < 75)
            {
                label_estimation.Content = "3";
            }
            else if (estimation_procent >= 75 && estimation_procent < 90)
            {
                label_estimation.Content = "4";
            }
            else label_estimation.Content = "5";

            // Отображение оценки (результат) в процентах
            label_procentresult.Content = $"{estimation_procent}%";
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_backMainMenu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenu());
        }

        private void btn_worksOnBugs(object sender, RoutedEventArgs e)
        {
            if(incorrect_words_.Count == 0)
            {
                MessageBox.Show("Список ошибок пуст!", "Оценка за диктант | Предупреждение");
                return;
            }

            NavigationService.Navigate(new LearningWords(incorrect_words_));
        }
    }
}
