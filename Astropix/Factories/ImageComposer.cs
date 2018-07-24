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
using System.Threading.Tasks;

namespace Astropix.Factories
{
    /// <summary>
    /// This class is in charge of Composing the images from the url given.
    /// </summary>
    class ImageComposer
    {
        private static System.IO.Stream inputStream;
        private static Bitmap photograph;
        /// <summary>
        /// this method will retrieve the actual image from the url given.
        /// </summary>
        /// <param name="urloftheimage">Self explaining</param>
        /// <returns></returns>
        public static Bitmap RetrieveImagey(string urloftheimage)
        {
            inputStream = new System.IO.MemoryStream();
                if (urloftheimage != null)
                {
                    inputStream = new Java.Net.URL(urloftheimage).OpenStream();
                    photograph = BitmapFactory.DecodeStream(inputStream);
                }
            if(photograph==null)
            {
                System.Console.WriteLine("The photograph is null!");
            }
            return photograph;
        }       
    }
}