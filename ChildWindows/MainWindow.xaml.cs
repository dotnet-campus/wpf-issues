using System.Windows;

namespace ChildWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();


            Loaded += (sender, e) =>
            {
                var w = new Window
                {
                    Title = "ChildWindow",
                    Owner = this,
                    Width = 600,
                    Height = 500,
                    Content = "Step 1: Move a window of another appliation to over the MainWindow\r\n" +
                              "Step 2: Active this window from the Windows taskbar\r\n" +
                              "Step 3: Close this window (ChildWindow)\r\n" +
                              "\r\nNow you can see that the MainWindow drops down and coverd by another window.\r\n" +
                              "If you don't understand the description above, please refer to the video demo in this project."
                };
                w.Show();
            };
        }
    }
}
