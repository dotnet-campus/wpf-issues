using System;
using System.Collections.Generic;
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

namespace MultiDragDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StepsTextBlock.Text = "Step1: Use your five fingers to slide on the blue canvas for serveral seconds."+"\r\n"
                + "Step2: Touch the button below."+"\r\n"+
                "\r\nThe button should be untouchable now.\r\n" +
                "If you don't understand the description above, please refer to the demo video in this project.";
        }

        private void UIElement_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(this, "OK", DragDropEffects.Move);
            }
        }

        private int i = 0;
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button1.Content = "Click me " + i++;
        }
    }
}
