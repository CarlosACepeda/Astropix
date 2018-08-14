using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Astropix.Services;

namespace Astropix.BroadcastReceivers
{
    //Broadcast is Disabled by default.
    //Will be only activated if the user enables the service, and the service needs this broadcast to reactivate the
    //Background works when the device is restarted, so the AlarmManager/JobScheduler runs normally.
    [BroadcastReceiver(Enabled =false)]
    [IntentFilter(new[] {Intent.ActionBootCompleted })]
    class BootBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //Reschuedule the Sync, because after a reboot all the AlarmManagers or Jobschedulers gets cleared.
            #region Ice Cream Sandwich Enable Alarm
            #endregion
            #region Lollipop and Beyond Enable JobScheduler
            Scheduler.ScheduleJob(Application.Context);
            #endregion
        }
    }
}