using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WinRT.Flyouts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void ReplyButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Ensure we have an app bar
            if (BottomAppBar == null) return;

            // Get the button just clicked
            var replyButton = sender as AppBarButton;
            if (replyButton == null) return;
            
            // Get the attached flyout
            var replyFlyout = (Flyout) Resources["ReplyFlyout"];
            if (replyFlyout == null) return;

            // Close the app bar before opening the flyout
            replyFlyout.Opening += delegate(object o, object o1)
            {
                if (BottomAppBar != null && BottomAppBar.Visibility == Visibility.Visible)
                {
                    BottomAppBar.Visibility = Visibility.Collapsed;
                }
            };

            // Show the app bar after the flyout closes
            replyFlyout.Closed += delegate(object o, object o1)
            {
                if (BottomAppBar != null && BottomAppBar.Visibility == Visibility.Collapsed)
                {
                    BottomAppBar.Visibility = Visibility.Visible;
                }
            };

            var grid = replyFlyout.Content as Grid;
            if (grid == null) return;
            grid.Tapped += delegate(object o, TappedRoutedEventArgs args)
            {
                var transparentGrid = args.OriginalSource as Grid;
                if (transparentGrid != null)
                {
                    replyFlyout.Hide();
                }
            };

            // Use the ShowAt() method on the flyout to specify where exactly the flyout should be located
            replyFlyout.ShowAt(BottomAppBar);
        }

        private void DeclarativeAttached_Click(object sender, RoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
        }

        private void ShowAnotherButtonsFlyout_Click(object sender, RoutedEventArgs e)
        {
            if (DeclarativeInlineButton.Flyout == null) return;

            DeclarativeInlineButton.Flyout.ShowAt(sender as FrameworkElement);
        }

        private void ProgrammaticallyCreate_Click(object sender, RoutedEventArgs e)
        {
            var flyout = new Flyout();

            var grid = new Grid();
            grid.Children.Add(new TextBlock() {Text = "I'm from code", Foreground = new SolidColorBrush(Colors.White), FontSize = 20});

            flyout.Content = grid;
            flyout.ShowAt(sender as FrameworkElement);
        }
    }
}
