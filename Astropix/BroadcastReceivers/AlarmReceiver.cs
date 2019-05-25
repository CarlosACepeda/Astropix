using Android.App;
using Android.Content;
using Android.Widget;
using Astropix.DataRepository;
using Astropix.Factories;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;

namespace Astropix.BroadcastReceivers
{
    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        private string urlplussecret = "https://api.nasa.gov/planetary/apod?api_key=h7fNJpWLRMhp0DLCOn2FmrXNuEVhx3yzLpolkEs9";
        private ImageOfTheDay imageOfTheDay;

        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Its time to download the data", ToastLength.Short).Show();
            try
            {
                ThreadPool.QueueUserWorkItem(async m =>
                {
                    var httpClient = new HttpClient();
                    var result = await httpClient.GetStringAsync(urlplussecret);
                    var post = JsonConvert.DeserializeObject<ImageOfTheDay>(result);
                    imageOfTheDay = post;
                    using (var dbhelper = new DBHelper())
                    {
                        dbhelper.InsertIntoTableImageOfTheDay(imageOfTheDay);
                        if (post.Media_Type == "image")
                        {
                            WallpaperManager wallpaperManager = WallpaperManager.GetInstance(Application.Context);
                            wallpaperManager.SetBitmap(ImageComposer.RetrieveImagey(post.Hdurl));
                        }
                    }
                });
            }
            catch
            {
                //Failed download
            }
        }
    }
}