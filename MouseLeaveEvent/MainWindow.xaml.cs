using System.Windows;

namespace MouseLeaveEvent
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1 {Owner = this};
            window1.ShowDialog();
        }
    }
}