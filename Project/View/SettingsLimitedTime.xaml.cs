using Spelling_of_words.Properties;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

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
