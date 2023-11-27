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
using Spelling_of_words.View;

// Learning the Spelling of English Words (LSEW)

namespace LSEW
{
    public partial class MainWindow : Window
    {
        public static MainWindow Window;

        public MainWindow()
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;
            MainFrame.Content = new StartMenu();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
