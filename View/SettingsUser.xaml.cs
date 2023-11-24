using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.WindowsAPICodePack.Dialogs;
using Spelling_of_words.Settings;

namespace Spelling_of_words.View
{
    /// <summary>
    /// Логика взаимодействия для SettingsUser.xaml
    /// </summary>
    public partial class SettingsUser : Page
    {
        public SettingsUser()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();

                dialog.Title = "Выберите файл со словами";
                dialog.InitialDirectory = SettingsProgram.pathFileWords;
                dialog.IsFolderPicker = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    SettingsProgram.pathFileWords = dialog.FileName;
                    pathFileBox.Text = SettingsProgram.pathFileWords;

                    MessageBox.Show($"Вы выбрали папку: {SettingsProgram.pathFileWords}\nКоличество файлов в выбранной папке: {new DirectoryInfo(SettingsProgram.pathFileWords).GetFiles().Length}", "Выбор файла");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
