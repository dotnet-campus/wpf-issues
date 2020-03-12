# WPF Issues

This repository provides small demo programs and code snippets to reproduce several wpf-related bugs. We hope these demos could do a little help to locate and debug the bugs.

#### WPF Main thread gets a deadlock when stylus input thread is waiting for the window to close
Please refer to the [MainThreadDeadlockWithStylusInputThread](./MainThreadDeadlockWithStylusInputThread/MainThreadDeadlockWhenTouchThreadWaitForWindowClosed) demo program for details.

#### [Fixed by .net 4.6.2] WPF program sometimes becomes untouchable after multi-touch operations.
Please refer to the [MultiDragDemo](./MultiDragDemo) demo program for details.

#### WPF window sometimes gets covered by other windows after its child window being closed.
Please refer to the [ChildWindows](./ChildWindows) demo program for details.

#### WPF translation animation sometimes shakes slightly.
Please refer to the [Animation](./Animation) demo program for details.

#### WPF UI thread sometimes stops rendering while another background thread shows a window.
Please refer to the [BitmapCache](./BitmapCache) demo program for details.

#### WPF child window may sometimes lost mouse leave event.
Please refer to the [MouseLeaveEvent](./MouseLeaveEvent) demo program for details.


#### WPF child window displayed behind the main window, and then the child window is displayed again in front of the main window
Please refer to the [ChildWindowDisplayedAndThenBackToMainWindow](./ChildWindowDisplayedAndThenBackToMainWindow) demo program for details.

