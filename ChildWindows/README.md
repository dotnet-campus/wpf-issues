# The MainWindow will lose focus when close the sub window in WPF 

I am showed a SubWindow in software and then move another software window over the MainWindow.

I show the SubWindow with click the task bar that I can see the MainWindow and SubWindow is at the top of the window.

But when I close the SubWindow ,I will see the the MainWindow be back of the another software.

The demo code is in github : https://github.com/iip-easi/wpf-issues/tree/master/ChildWindows

And you can see the https://github.com/iip-easi/wpf-issues/blob/master/ChildWindows/demo.mp4 or the image :![](http://7xqpl8.com1.z0.glb.clouddn.com/AwCCAwMAItoFADbzBgABAAQArj4BAGZDAgBo6AkA6Nk%3D%2FChildWindows.gif)

<!--more-->
The step:

1. Creating a window

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

2. Show the SubWindow.

3. Move a window of another appliation to over the MainWindow.

4. Active this window from the Windows taskbar

5. Close this window (ChildWindow)

Now you can see that the MainWindow drops down and coverd by another window.

If you don't understand the description above, please refer to the video demo in this project.


