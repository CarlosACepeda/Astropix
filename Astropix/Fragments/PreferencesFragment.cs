using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Astropix.BroadcastReceivers;
using Astropix.Misc;
using Astropix.Services;

namespace Astropix.Fragments
{
    public class PreferencesFragment : Android.Support.V14.Preferences.PreferenceFragment, ISharedPreferencesOnSharedPreferenceChangeListener
    {
        ISharedPreferences sharedPreferences;
        AlarmManager alarmManager;
        PendingIntent pendingIntent;
        private ComponentName receiver;
        private PackageManager pm;
        private Intent intent;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Xml.prefs);
             sharedPreferences = PreferenceManager.SharedPreferences;
            sharedPreferences.RegisterOnSharedPreferenceChangeListener(this);
            alarmManager = (AlarmManager)Activity.GetSystemService(Context.AlarmService);
            
            
        }

        public override void OnDestroy()
        {
            sharedPreferences.UnregisterOnSharedPreferenceChangeListener(this);
            base.OnDestroy();
        }

        public override void OnCreatePreferences(Bundle savedInstanceState, string rootKey)
        {
            
        }

        public void OnSharedPreferenceChanged(ISharedPreferences sharedPreferences, string key)
        {
            //Killswitch to decide if user wants to stop downloading images.
            //Stop All receivers, alarms, etc.
            if (key == ConfigurationParameters.enableservice)
            {
                if (sharedPreferences.GetBoolean(key, false) == true)
                {
                    #region Enable AlarmManager Ice Cream Sandwich.
                    if (Build.VERSION.SdkInt < BuildVersionCodes.KitkatWatch)
                    {
                        intent = new Intent(Application.Context, typeof(AlarmReceiver));
                        pendingIntent = PendingIntent.GetBroadcast(Application.Context, 2, intent, PendingIntentFlags.UpdateCurrent);
                        //If the user enables the service, schedule the alarm or Scheduler to download data each day.
                        EnableBootReceiver();

                        //Kitkat or Less.
                        //>Schedule an alarm to run after 30 minutes after this call(second parameter), and once a day after that.(third parameter)
                        alarmManager.SetInexactRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + AlarmManager.IntervalFifteenMinutes, AlarmManager.IntervalDay, pendingIntent);
                    }
                    #endregion
                    #region Enable JobScheduler Lollipop and Beyond.
                    Scheduler.ScheduleJob(Application.Context);
                    EnableBootReceiver();
                    #endregion
                }
                else if (sharedPreferences.GetBoolean(key, false) == false)
                {

                    #region Disable AlarmManager Ice Cream Sandwich
                    if (Build.VERSION.SdkInt < BuildVersionCodes.KitkatWatch)
                    {
                        alarmManager?.Cancel(pendingIntent);
                        DisableBootReceiver();
                    }
                    #endregion
                    #region Disable JobScheduler Lollipop and Beyond.
                    Scheduler.CancelSchedule(Application.Context);
                    #endregion
                }


            }
        }
        void EnableBootReceiver()
        {
            receiver = new ComponentName(Application.Context, Java.Lang.Class.FromType(typeof(BootBroadcastReceiver)));
            pm = Application.Context.PackageManager;

            pm.SetComponentEnabledSetting(receiver, ComponentEnabledState.Enabled, ComponentEnableOption.DontKillApp);
        }
        void DisableBootReceiver()
        {
            receiver = new ComponentName(Application.Context, Java.Lang.Class.FromType(typeof(BootBroadcastReceiver)));
            pm = Application.Context.PackageManager;

            pm.SetComponentEnabledSetting(receiver, ComponentEnabledState.Disabled, ComponentEnableOption.DontKillApp);
        }
    }
}