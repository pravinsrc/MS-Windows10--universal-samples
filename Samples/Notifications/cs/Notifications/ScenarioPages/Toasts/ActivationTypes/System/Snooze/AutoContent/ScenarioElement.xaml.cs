using System;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Notifications.ScenarioPages.Toasts.ActivationTypes.System.Snooze.AutoContent
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

            // Pop reminder
            popToastControl.Payload =
                $@"
                <toast scenario='reminder' launch='args'>
                    <visual>
                        <binding template='ToastGeneric'>
                            <text>System Snoozing (Auto Content)</text>
                            <text>The button for snoozing should be localized in your language, generated by the system when displaying the toast.</text>
                        </binding>
                    </visual>

                    <actions>

                        <input id='snoozeTime' type='selection' defaultInput='1'>
                            <selection id='1' content = '1 minute'/>
                            <selection id='2' content = '2 minutes'/>
                            <selection id='5' content = '5 minutes'/>
                        </input>

                        <action activationType='system' arguments='snooze' hint-inputId='snoozeTime' content=''/>

                        <action activationType='system' arguments='dismiss' content='dismiss (ignore my text)' />

                    </actions>
                </toast>";
        }

        private async void Error(string message)
        {
            await new MessageDialog(message, "ERROR").ShowAsync();
        }
    }
}
