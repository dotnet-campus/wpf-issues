using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Microsoft.Expression.Media.Effects;

namespace WpfBugDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            OuterGrid.Effect = new SlideInTransitionEffect
            {
                // To comment out the codes below, the first line text in the blue block will not shake while tansiting.  
                // This snapped bitmap is little blurry, that means the RenderTargetBitmap renders in a different way.
                // How can I get a the same screenshot as the control?
                Input = new ImageBrush(TakeImage(InnerGrid))
            };

            var animation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(0.8)))
            {
                AccelerationRatio = 0.5,
                DecelerationRatio = 0.5
            };

            Storyboard.SetTarget(animation, OuterGrid);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Effect.Progress"));

            var storyboard = new Storyboard();
            storyboard.Completed += Storyboard_Completed;

            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            OuterGrid.BeginAnimation(EffectProperty, null);
            OuterGrid.Effect = null;
        }

        private static ImageSource TakeImage(FrameworkElement element)
        {
            var width = (int) element.ActualWidth;
            if (width == 0)
            {
                width = (int) element.Width;
            }
            var height = (int) element.ActualHeight;
            if (height == 0)
            {
                height = (int) element.Height;
            }

            var bitmap = new RenderTargetBitmap(width, height, 96.0, 96.0, PixelFormats.Pbgra32);
            bitmap.Render(element);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            return bitmap;
        }
    }
}