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
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using Android.Graphics;
using Astropix.Factories;

namespace Astropix.Services
{
    [Service(Label ="Image of the Day retriever service")]
    class AstropixRetrieverService : Service
    {
        private readonly string url = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
        private readonly string urlplussecret = "https://api.nasa.gov/planetary/apod?api_key=h7fNJpWLRMhp0DLCOn2FmrXNuEVhx3yzLpolkEs9";
        public static bool isInfoAvailable = false;
        ImageOfTheDay imageOfTheDay;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            imageOfTheDay = ImageOfTheDay.ImageOfTheDayInstance();
            ThreadPool.QueueUserWorkItem(m => RetrieveTheImageOfTheDayData());
            
            return base.OnStartCommand(intent, flags, startId);
        }

        /// <summary>
        /// This method retrieves the actual image data of the day from the NASA Apod API.
        /// </summary>
        private async void RetrieveTheImageOfTheDayData()
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
                imageOfTheDay.Image =ImageComposer.RetrieveImageInStandardQuality(post.Url);
                isInfoAvailable = true;
                Console.WriteLine("the information is filled");
                WallpaperManager wallpaperManager = WallpaperManager.GetInstance(this);
                wallpaperManager.SetBitmap(imageOfTheDay.Image); 

            }
            catch
            {
                Console.WriteLine("No internet connection or failing Api call");
            }
            //TODO:
            //Define a JobScheduler to Retrieve the image each day.

        }
    }
}