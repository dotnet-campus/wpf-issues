using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace RenderTargetBitmapThrowsCOMExceptionWhenCreatedTooFast
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;


            Loaded += (s, e) => { FastCreated(); };
        }

        private async void FastCreated()
        {
            var ran = new Random();

            while (true)
            {
                await Task.Delay(100).ContinueWith(_ =>
                {
                    ImageList.Clear();
                    var n = ran.Next(int.MaxValue / 10);
                    for (int i = n; i < n + 1000; i++)
                    {
                        try
                        {
                            DrawingVisual drawingVisual = new DrawingVisual();
                            DrawingContext drawingContext = drawingVisual.RenderOpen();

                            var text = new FormattedText(i.ToString(),
                                CultureInfo.GetCultureInfo("zh-cn"),
                                FlowDirection.LeftToRight,
                                new Typeface("Verdana"),
                                36, Brushes.Black);
                            drawingContext.DrawText(text,
                                new Point(0, 0));

                            drawingContext.Close();

                            var image = new RenderTargetBitmap((int) text.Width, (int) text.Height, 96, 96,
                                PixelFormats.Pbgra32);
                            image.Render(drawingVisual);

                            ImageList.Add(image);
                        }
                        catch (Exception e)
                        {
                            // RenderTargetBitmap throws COM exception when created too fast: MILERR_WIN32ERROR (Exception from HRESULT: 0x88980003)
                            Console.WriteLine(e);
                        }

                        GC.WaitForPendingFinalizers();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }


        public ObservableCollection<ImageSource> ImageList { get; set; } = new ObservableCollection<ImageSource>();
    }
}