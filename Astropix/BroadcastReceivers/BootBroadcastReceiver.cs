using Android.App;
using Android.Content;

namespace Astropix.BroadcastReceivers
{
    //Broadcast is Disabled by default.
    //Will be only activated if the user enables the service, and the service needs this broadcast to reactivate the
    //Background works when the device is restarted, so the AlarmManager/JobScheduler runs normally.
    [BroadcastReceiver(Enabled = false)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    internal class BootBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //Reschuedule the Sync, because after a reboot the AlarmManager gets cleared.
        }
    }
}