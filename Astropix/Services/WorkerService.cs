using System;
using System.Collections.Generic;
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
using Astropix.Factories;
using Astropix.DataRepository;
using Newtonsoft.Json;

namespace Astropix.Services
{
    [Service(Exported =true, Permission ="android.permission.BIND_JOB_SERVICE")]
    class WorkerService : JobService
    {
        private readonly string urlplussecret = "https://api.nasa.gov/planetary/apod?api_key=h7fNJpWLRMhp0DLCOn2FmrXNuEVhx3yzLpolkEs9";
        ImageOfTheDay imageOfTheDay;
        public override bool OnStartJob(JobParameters @params)
        {
            imageOfTheDay = ImageOfTheDay.ImageOfTheDayInstance();

            Console.WriteLine("OnStartJob Called");
            ThreadPool.QueueUserWorkItem(async m =>
            {
                var client = new HttpClient();
                try
                {
                    var result = await client.GetStringAsync(urlplussecret);
                    var post = JsonConvert.DeserializeObject<ImageOfTheDay>(result);
                    imageOfTheDay.Title = post.Title;
                    imageOfTheDay.Explanation = post.Explanation;
                    imageOfTheDay.Url = post.Url;
                    imageOfTheDay.Hdurl = post.Hdurl;
                    imageOfTheDay.Copyright = post.Copyright;
                    if (post.Media_Type == "image")//If is a video, will retain the past image
                    {
                        imageOfTheDay.Image = ImageComposer.RetrieveImagey(post.Url);
                        Console.WriteLine();
                        WallpaperManager wallpaperManager = WallpaperManager.GetInstance(Application.Context);
                        wallpaperManager.SetBitmap(imageOfTheDay.Image);
                    }

                    JobFinished(@params, false);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No internet connection or failing Api call" +ex);
                    JobFinished(@params, true); //Failed, need to reschedule again.
                }
            });
            return true;
        }

        public override bool OnStopJob(JobParameters @params)
        {
            Console.Write("OnStopJob Called");
            return true;
            
        }
    }
}