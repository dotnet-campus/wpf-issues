using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageMemoryLeak
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 每次点击此按钮会将当前呈现的图片移除视觉树，再将其Source属性设置为null。
            // 然后新建一个Image控件，并将其Source属性设置为RenderTargetBitmap对象，再呈现出来。
            // 再次过程中，RenderTargetBitmap对象从来不会被回收，造成内存泄露。
            // 可以从资源管理其中观察到程序的内存持续上涨的现象。

            // Remove the current Image control from the  visual tree and set source is null when click button.
            // Then new a image control and add source to the RenderTargetBitmap object and show it.
            // You can see the gc never delete the RenderTargetBitmap object that make  memory leak.


            var oldBorder = RootGrid.Children.OfType<Border>().LastOrDefault();
            if (oldBorder != null)
            {
                var oldImage = (Image)oldBorder.Child;


                // 如果在Image控件移除视觉树之前将其Source属性设为null，并调用UpdateLayout方法。
                // 则RenderTargetBitmap对象可被回收，不会导致内存泄露。
                // 取消注释下面的代码可以观察到上述现象。
                // In order to solve it , you should set the image.Source is null and use UpdateLayout.
                // The below code can solve it.
                // oldImage.Source = null;
                // oldImage.UpdateLayout();

                // 将当前的Image控件移除视觉树。
                // Remove the current Image control from the  visual tree.
                RootGrid.Children.Remove(oldBorder);
                oldImage.Source = null;
                Borders.Add(oldBorder);
            }

            var bitmap = new RenderTargetBitmap(1024, 1024, 96, 96, PixelFormats.Default);

            var image = new Image { Source = bitmap };
            var border = new Border { Child = image };
            RootGrid.Children.Add(border);

            // 为了便于观察内存的变化，每次操作后都会进行垃圾回收。
            // In order to facilitate changes in memory, after each operation will be garbage collection
            GC.Collect();
        }

        public readonly List<Border> Borders = new List<Border>();
    }
}
