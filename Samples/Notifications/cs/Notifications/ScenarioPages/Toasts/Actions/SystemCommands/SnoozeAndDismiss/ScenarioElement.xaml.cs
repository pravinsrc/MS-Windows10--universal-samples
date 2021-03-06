using System;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Notifications.ScenarioPages.Toasts.Actions.SystemCommands.SnoozeAndDismiss
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScenarioElement : UserControl
    {
        public ScenarioElement()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            // Clear all existing notifications
            ToastNotificationManager.History.Clear();

            // Pop notifications
            popToastControl.Payload =
                $@"
                <toast activationType='foreground' launch='args' scenario='reminder'>
                    <visual>
                        <binding template='ToastGeneric'>
                            <text>SystemCommands SnoozeAndDismiss</text>
                            <text>Make sure there's a dropbox for selecting snooze interval, a snooze button, and a dismiss button. Actions should be handled by system.</text>
                        </binding>
                    </visual>
                    <actions hint-systemCommands = 'SnoozeAndDismiss' />
                </toast>";
        }

        private async void Error(string message)
        {
            await new MessageDialog(message, "ERROR").ShowAsync();
        }
    }
}
