# WPF the windows stop render  when use BitmapCache

We make a control that use `CacheMode = new BitmapCache()` and it will make the windows stop render when we doing some operations like lock the screen and unlock it.

The demo that about this issue is in github: https://github.com/iip-easi/wpf-issues/tree/master/BitmapCache

We write a Button like the code.


```csharp
     public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // When one of these methods called, the bug will be reproduced.
            Reproduce1();
            //Reproduce2();

            Content = new Button
            {
                CacheMode = new BitmapCache(),
                Content = "Step 1: Lock screen (WIN+L)\r\n" +
                          "Step 2: Unlock screen\r\n" +
                          "Step 3: Click this button, or resize this window\r\n" +
                          "\r\nNow, this window should stop repainting itself...\r\n" +
                          "If you can't see that happening, please restart the application and try again :-D",
                // The same thing could still happen by other operations:
                // A:
                // - Step 1: Let the application run for a while. (e.g. 10~30min)
                // - Step 2: Click this button, or resize this window. Now, this window should stop repainting itself...
                // B:
                // - Step 1: Show a UAC window in any way by any other programs.
                // - Step 2: Click any button to close the UAC window.
                // - Step 3: Click this button, or resize this window. Now, this window should stop repainting itself...
            };
        }

        /// <summary>
        /// In this method, Window.Hide() is necessary.
        /// </summary>
        private void Reproduce1()
        {
            var hiddenWindow = new Window();
            hiddenWindow.Show();
            hiddenWindow.Hide();
        }

        /// <summary>
        /// In this method, the window is shown in another thread, thus Window.Hide() is not necessary.
        /// </summary>
        private void Reproduce2()
        {
            var backgroundThread = new Thread((() =>
            {
                var backgroundWindow = new Window { Title = $"Background Thread:{Thread.CurrentThread.ManagedThreadId}", Width = 500, Height = 500 };
                backgroundWindow.ShowDialog();
            }));
            backgroundThread.SetApartmentState(ApartmentState.STA);
            backgroundThread.Start();
        }
    }
```

We can see window stop repainting itself when we lock Screen and unlock it.

![](./BitmapCache.gif)

The step:

step 1: Add a control like button with the CacheMode is BitmapCache.

step 2: Lock screen (WIN+L)

step 3: Unlock screen

And you can see the windows stop render when you click the button or resize the window.

If you can't see that happening, please restart the application and try again.



## What is the impact of this issue

We dare not use this feature that it may make your software cant be use.

If we dont use the BitmapCache ,we will spend more memory.