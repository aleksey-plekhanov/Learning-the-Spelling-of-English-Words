using Spelling_of_words.View;
using System.Windows;
using System.Windows.Input;

// Learning the Spelling of English Words (LSEW)

namespace LSEW
{
    public partial class MainWindow : Window
    {
        public static MainWindow Window;

        public static StartMenu StartMenu_ = new StartMenu();
        public static AboutProgram AboutProgram_ = new AboutProgram();
        public static MainMenu MainMenu_ = new MainMenu();
        public static ManualProgram ManualProgram_ = new ManualProgram();
        public static SettingsUser SettingsUser_ = new SettingsUser();
        public static SettingsLimitedTime SettingsLimitedTime_ = new SettingsLimitedTime();
        public static FinishLearning FinishLearning_ = new FinishLearning();

        public MainWindow()
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;
            MainFrame.Content = StartMenu_;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}
