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
    /// <summary>
    /// Логика взаимодействия для LearningWords.xaml
    /// </summary>
    public partial class LearningWords : Page
    {
        public LearningWords()
        {
            InitializeComponent();
        }

        private void btn_LWBack(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnNextWord_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_VDBack(object sender, MouseButtonEventArgs e)
        {
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
