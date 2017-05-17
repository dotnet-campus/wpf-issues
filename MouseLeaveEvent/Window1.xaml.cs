using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace MouseLeaveEvent
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1/*:Window*/ //That is the same problem whether inherit Window
    {
        public Window1()
        {
            InitializeComponent();

            Button.Content = "Step 1: Hover your mouse on this button.\r\n" +
                                   "Step 2: Move your mouse out of the two windows very quickly.\r\n" +
                                   "\r\nNow you can see that the button still has a effect of hovering.\r\n";
        }
        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Enter");
        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Leave");
        }
    }
}