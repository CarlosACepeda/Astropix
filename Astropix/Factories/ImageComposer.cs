using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using Java.IO;
using System.Threading;

namespace Astropix.Factories
{
    /// <summary>
    /// This class is in charge of Composing the images from the url given.
    /// </summary>
    class ImageComposer
    {
        private static Bitmap photograph;
        /// <summary>
        /// this method will retrieve the actual image from the url given.
        /// </summary>
        /// <param name="urloftheimage">Self explaining</param>
        /// <returns></returns>
        public static Bitmap RetrieveImageInStandardQuality(string urloftheimage)
        {

            ThreadPool.QueueUserWorkItem(m =>
            {
                if (urloftheimage != null)
                {
                    System.IO.Stream inputStream = new Java.Net.URL(urloftheimage).OpenStream();
                    photograph = BitmapFactory.DecodeStream(inputStream);
                }
               
            });
            return photograph;
        }
        

    }
}