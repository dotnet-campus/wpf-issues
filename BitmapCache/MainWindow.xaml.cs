using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoveredWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var backgroundThread = new Thread((() =>
            {
                var backgroundWindow = new Window { Title = $"Background Thread:{Thread.CurrentThread.ManagedThreadId}", Width = 500, Height = 500 };
                backgroundWindow.ShowDialog();
            }));
            backgroundThread.SetApartmentState(ApartmentState.STA);
            backgroundThread.Start();

            Content = new Button
            {
                CacheMode = new BitmapCache(),
                Content = "Step 1: Lock screen (WIN+L)\r\n" +
                          "Step 2: Unlock screen\r\n" +
                          "Step 3: Click this button, or resize this window\r\n" +
                          "\r\nNow, this window should stop repainting itself...\r\n" +
                          "If you can't see that happening, please restart the application and try again :-D"
            };
        }
    }
}
