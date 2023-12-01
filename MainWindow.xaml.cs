using Spelling_of_words.View;
using System.Windows;
using System.Windows.Input;

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
