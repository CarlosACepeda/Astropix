using Android.App;
using Android.Graphics;
using System.Threading;

namespace Astropix.Factories
{
    /// <summary>
    /// This class is in charge of Composing the images from the url given.
    /// </summary>
    internal class ImageComposer
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
                ThreadPool.QueueUserWorkItem(m =>
                {
                    inputStream = new Java.Net.URL(urloftheimage).OpenStream();
                    photograph = BitmapFactory.DecodeStream(inputStream);
                    if (photograph == null)
                    {
                        System.Console.WriteLine("The photograph is null!");
                    }
                });
            }
            return photograph;
        }

        public static void SetDownloadedImageAsBackground(string urloftheimage)
        {
            ThreadPool.QueueUserWorkItem(async m =>
            {
                var inputStream = new Java.Net.URL(urloftheimage).OpenStream();
                var photograph = await BitmapFactory.DecodeStreamAsync(inputStream);
                WallpaperManager wallpaperManager = WallpaperManager.GetInstance(Application.Context);
                wallpaperManager.SetBitmap(photograph);
            }
            );
        }
    }
}