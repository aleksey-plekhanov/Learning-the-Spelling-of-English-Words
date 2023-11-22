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
    /// Логика взаимодействия для ManualProgram.xaml
    /// </summary>
    public partial class ManualProgram : Page
    {
        public ManualProgram()
        {
            InitializeComponent();
        }

        private void btn_ManualBack(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
