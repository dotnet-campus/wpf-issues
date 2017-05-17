# Window's Button cant get the mouse leave event when show dialog in WPF

We found that the Button cant raise the OnMouseLeave Event when show the window dialog.

We make a Window that call Window1 and write a button in Windows1.

We can get the OnMouseEnter and OnMouseLeave event on this button.

I hover my mouse on this button and I can see the button changed the background.

I move the mouse out of the two windows very quickly .Then I can see the button still has a effect of hovering.

See the gif:![](http://7xqpl8.com1.z0.glb.clouddn.com/AwCCAwMAItoFADbzBgABAAQArj4BAGZDAgBo6AkA6Nk%3D%2FMouseLeaveEvent.gif)

The code is in github: https://github.com/iip-easi/wpf-issues/tree/master/MouseLeaveEvent

<!--more-->

The step:

Step 1: Making a Window and add a button. I call this Window as Windows1.

Step 2: Showing this Window as dialog.

            Window1 window1 = new Window1 {Owner = this};
            window1.ShowDialog();

Step 3: Hover the mouse on the button and then move out the mouse to the two windows .

Now you can see that the button still has a effect of hovering.


