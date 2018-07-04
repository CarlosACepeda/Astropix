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
namespace Astropix.Services
{
    [Service(Label ="Image of the Day retriever service")]
    class AstropicRetrieverService : Service
    {
        private readonly string url = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
        
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            RetrieveTheImageOfTheDay();
            return base.OnStartCommand(intent, flags, startId);
        }
        /// <summary>
        /// This method retrieves the actual image od the day from the NASA Apod API.
        /// </summary>
        private async void RetrieveTheImageOfTheDay()
        {
            var client = new HttpClient();
            var result= await client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<ImageOfTheDay>(result);
        }
    }
}