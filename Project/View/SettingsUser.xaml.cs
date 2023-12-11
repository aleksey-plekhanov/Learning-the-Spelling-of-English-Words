using LSEW;
using Microsoft.Win32;
using Spelling_of_words.Properties;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Spelling_of_words.View
{
    public partial class SettingsUser : Page
    {
        public SettingsUser()
        {
            InitializeComponent();

            pathFileBox.Text = Settings.Default.PathFileWords;

            state_generatewords.IsChecked = Settings.Default.GenerateRandomWords;
            state_timeLimiter.IsChecked = Settings.Default.TimeLimiter;
            state_notresponseresult.IsChecked = Settings.Default.NotDisplayingResponseResult;
            state_disabletimecounting.IsChecked = Settings.Default.DisableTimeCounting;
        }
        
        public void LoadTextTimeLimited()
        {
            if (Settings.Default.TimeLimiter)
            {
                state_timeLimiter.Content = $"  Ограничить время на ответ в диктанте. Ограничение: {Settings.Default.limitedTime} сек.";
            }
            else state_timeLimiter.Content = "  Ограничить время на ответ в диктанте  ";
        }  

        private void btn_SettingsBack(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_closeApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SelectFolder(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Title = "Выберите файла со словами";
                dialog.InitialDirectory = Settings.Default.PathFileWords;
                dialog.Filter = "Text files |*.txt;*.csv";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == true)
                {
                    Settings.Default.PathFileWords = dialog.FileName;
                    pathFileBox.Text = Settings.Default.PathFileWords;

                    MessageBox.Show($"Вы выбрали файл: {Settings.Default.PathFileWords}", "Выбор файла");
                    Settings.Default.Save();
                }
                
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void btn_timeLimiter(object sender, RoutedEventArgs e)
        {
            if (!Settings.Default.TimeLimiter)
            {
                NavigationService.Navigate(MainWindow.SettingsLimitedTime_);
            }

            Settings.Default.TimeLimiter = (bool)state_timeLimiter.IsChecked;
            Settings.Default.Save();

            LoadTextTimeLimited();
        }

        private void btn_generaterandomwords(object sender, RoutedEventArgs e)
        {
            Settings.Default.GenerateRandomWords = (bool)state_generatewords.IsChecked;
            Settings.Default.Save();
        }

        private void btn_hideresponseresult(object sender, RoutedEventArgs e)
        {
            Settings.Default.NotDisplayingResponseResult = (bool)state_notresponseresult.IsChecked;
            Settings.Default.Save();
        }

        private void btn_disabletimecounting(object sender, RoutedEventArgs e)
        {
            Settings.Default.DisableTimeCounting = (bool)state_disabletimecounting.IsChecked;
            Settings.Default.Save();
        }

        private void state_timeLimiter_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            LoadTextTimeLimited();
        }
    }
}
