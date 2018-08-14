using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using Android.App;
using Android.App.Job;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Astropix.DataRepository;
using Astropix.Factories;
using Newtonsoft.Json;

namespace Astropix.Services
{
    class Scheduler
    {
        public static void ScheduleJob(Context context)
        {
            ComponentName serviceComponent = new ComponentName(context, Java.Lang.Class.FromType(typeof(WorkerService)));
            JobInfo.Builder builder = new JobInfo.Builder(0, serviceComponent)
                                                            .SetPeriodic(AlarmManager.IntervalFifteenMinutes);//A day. //Configurable?
             JobScheduler jobScheduler = (JobScheduler)context.GetSystemService(Context.JobSchedulerService);
            JobInfo jobInfo = builder.Build();
            int result = jobScheduler.Schedule(jobInfo);
            if (result == JobScheduler.ResultSuccess)
            {
                Log.Info("Astropix","Job Result Sucess");
            }
            else
            {
                Log.Info("Astropix", "Job Result Not Sucess");
            }


        }
        public static void CancelSchedule(Context context)
        {
            using (var jobScheduler = (JobScheduler)context.GetSystemService(Context.JobSchedulerService))
            {
                jobScheduler.CancelAll();
            };
        }
    }
}


