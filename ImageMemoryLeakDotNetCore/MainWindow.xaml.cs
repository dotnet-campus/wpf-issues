using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageMemoryLeakDotNetCore
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Remove the current Image control from the  visual tree and set source is null when click button.
            // Then new a image control and add source to the RenderTargetBitmap object and show it.
            // You can see the gc never delete the RenderTargetBitmap object that make  memory leak.


            var oldBorder = RootGrid.Children.OfType<Border>().LastOrDefault();
            if (oldBorder != null)
            {
                var oldImage = (Image)oldBorder.Child;

                // In order to solve it , you should set the image.Source is null and use UpdateLayout.
                // The below code can solve it.
                // oldImage.Source = null;
                // oldImage.UpdateLayout();

                // Remove the current Image control from the  visual tree.
                RootGrid.Children.Remove(oldBorder);
                oldImage.Source = null;
                Borders.Add(oldBorder);
            }

            var bitmap = new RenderTargetBitmap(1024, 1024, 96, 96, PixelFormats.Default);

            var image = new Image { Source = bitmap };
            var border = new Border { Child = image };
            RootGrid.Children.Add(border);

            // In order to facilitate changes in memory, after each operation will be garbage collection
            GC.Collect();
        }

        public readonly List<Border> Borders = new List<Border>();
    }
}
