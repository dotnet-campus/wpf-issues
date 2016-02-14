using System.Diagnostics;
using System.Windows.Input;

namespace MouseLeaveEvent
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1
    {
        public Window1()
        {
            InitializeComponent();
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