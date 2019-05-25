using Android.App;
using Android.App.Job;
using Android.Content;
using Android.Util;

namespace Astropix.Services
{
    internal class Scheduler
    {
        public static void ScheduleJob(Context context)
        {
            ComponentName serviceComponent = new ComponentName(context, Java.Lang.Class.FromType(typeof(WorkerService)));
            JobInfo.Builder builder = new JobInfo.Builder(0, serviceComponent)
                                                            .SetPersisted(true)
                                                            .SetPeriodic(AlarmManager.IntervalDay);//A day. //Configurable?
            JobScheduler jobScheduler = (JobScheduler)context.GetSystemService(Context.JobSchedulerService);
            JobInfo jobInfo = builder.Build();
            int result = jobScheduler.Schedule(jobInfo);
            if (result == JobScheduler.ResultSuccess)
            {
                Log.Info("Astropix", "Job Result Sucess");
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