using System.Windows;

namespace ChildWindowDisplayedAndThenBackToMainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new Window()
            {
                
            };

            window.Show();
        }
    }
}
