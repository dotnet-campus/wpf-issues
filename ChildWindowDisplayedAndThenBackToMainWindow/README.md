# ChildWindowDisplayedAndThenBackToMainWindow

We can see that the child window is displayed first, then the child window is displayed behind the main window, and then the child window is displayed again in front of the main window.

The steps

1. Set MainWindows as follows

```xml
WindowStyle="None" AllowsTransparency="True"
        WindowState="Maximized" 
```

2. Add a button to main window

```xml
        <Button Content="Show sub window" HorizontalAlignment="Center" VerticalAlignment="Center" Click="Button_OnClick"/>
```

3. Show a child window when button clicked

```csharp
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new Window()
            {
            };

            window.Show();
        }
```

When we using VisualStudio 2019 to debug and attache the process, we will find that the child window is displayed first, then the child window is displayed behind the main window, and then the child window is displayed again in front of the main window.

At this point if you don't have additional debugging in VisualStudio 2019, you won't see the child window flicker.

There are two solutions

The first method is to remove the AllowsTransparency property of the main window

The second method is to set the Owner of the child window as the main window

```csharp
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new Window()
            {
                Owner = this
            };

            window.Show();
        }
```

I publish the code to [github](https://github.com/dotnet-campus/wpf-issues/tree/master/ChildWindowDisplayedAndThenBackToMainWindow) and welcome you to visit.