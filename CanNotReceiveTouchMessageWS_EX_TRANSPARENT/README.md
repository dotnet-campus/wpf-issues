# WPF can not receive the touch message when set WS_EX_TRANSPARENT to window

We can create an empty WPF application, and then we can output message when we receive the mouse down and touch down event

But when we set the WS_EX_TRANSPARENT property to the window, that we can find that we can only receive the mouse event and can not receive the touch event

```csharp
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        }
```

Here is the mini demo code: https://github.com/dotnet-campus/wpf-issues/tree/master/CanNotReceiveTouchMessageWS_EX_TRANSPARENT