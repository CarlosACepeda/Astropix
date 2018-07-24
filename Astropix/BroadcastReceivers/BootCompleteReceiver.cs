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
    [BroadcastReceiver(Label ="BootCompleteReceiver", Permission = "android.permission.RECEIVE_BOOT_COMPLETED")]
    [IntentFilter(new[] {Intent.ActionBootCompleted })]
    public class BootCompleteReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            //Schedule a job when user starts device back.
            Scheduler.ScheduleJob(context);
        }
    }
}