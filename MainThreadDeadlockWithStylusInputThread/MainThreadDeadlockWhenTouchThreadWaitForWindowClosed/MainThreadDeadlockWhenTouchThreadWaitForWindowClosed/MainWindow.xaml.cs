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
using System.Windows.Input.StylusPlugIns;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainThreadDeadlockWhenTouchThreadWaitForWindowClosed
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _fooWindow = new FooWindow();
            StylusPlugIns.Add(new FooStylusPlugIn(_fooWindow));
            _fooWindow.Show();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private FooWindow _fooWindow;
    }

    public class FooWindow : Window
    {

    }

    public class FooStylusPlugIn : StylusPlugIn
    {
        public FooStylusPlugIn(FooWindow fooWindow)
        {
            FooWindow = fooWindow;
        }

        public FooWindow FooWindow { get; }

        /// <inheritdoc />
        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            FooWindow.Dispatcher.Invoke(() => FooWindow.Close());
            base.OnStylusUp(rawStylusInput);
        }
    }
}
