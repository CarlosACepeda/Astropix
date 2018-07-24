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
                                                            .SetPeriodic(24*60*60000, 15000);//A day. //Configurable?
             JobScheduler jobScheduler = (JobScheduler)context.GetSystemService(Context.JobSchedulerService);
            JobInfo jobInfo = builder.Build();
            int result = jobScheduler.Schedule(jobInfo);
            if (result == JobScheduler.ResultSuccess)
            {
                Console.WriteLine("Job Result Sucess");
            }
            else
            {
                Console.Write("Job Result Failed");
            }


        }
    }
}


