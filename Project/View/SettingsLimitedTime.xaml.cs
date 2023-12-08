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
    public partial class SettingsLimitedTime : Page
    {
        public SettingsLimitedTime()
        {
            InitializeComponent();
        }

        private void btn_confirmTime(object sender, RoutedEventArgs e)
        {
            int value = 0;

            if (int.TryParse(inputsecond.Text, out value))
            {
                if (value >= 5 && value <= 600)
                {
                    Properties.Settings.Default.limitedTime = value;
                    Settings.Default.Save();

                    MessageBox.Show("Время сохранено!", "Ограничение времени на ответ");
                    NavigationService.GoBack();
                }
                else MessageBox.Show("Некорректное значение. Диапозон: от 5 сек. до 600 сек.", "Ограничение времени на ответ");
            }
            else MessageBox.Show("Введите корректное значение!", "Ошибка");
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
