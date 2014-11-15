Working with the Flyout control in Windows Runtime on Windows Phone
=============

Windows Runtime Flyout on Windows Phone is extremely versatile.The flyout control is a simple control you can attach to any FrameworkElement, or define as a resource and open it programatically.

### Placement
A flyout has five placement modes, Top, Bottom, Left, Right, and Full. However, when working on the phone, only Top (default) and Full will work. This means, either you get a full screen, or pinned to the top. Definitely not ideal when trying to create a menu related to an app bar button. This comes straight from [MSDN].(http://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn308515.aspx)

>On Windows Phone, a Flyout is shown at the top of the screen by default. You can change the Placement property to FlyoutPlacementMode.Full to make the flyout cover the full screen. The Top, Bottom, Left, and Right values don't have any effect in Windows Phone apps.

There are numerous ways to interact with a flyout, be it declarative, programmatic, or both.

[Read more](http://bit.ly/1zq5NPM) on my blog.
