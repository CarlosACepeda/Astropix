using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Widget;
using System;

namespace Astropix.Activities
{
    [Activity(Label = "ImageViewerActivity")]
    public class ImageViewerActivity : Activity
    {
        private FloatingActionButton fab;
        private ImageView image;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.image_viewer);

            fab = FindViewById<FloatingActionButton>(Resource.Id.downloadImage);
            image = FindViewById<ImageView>(Resource.Id.SpaceImage);

            fab.Click += FabOnClick;

            // Create your application here

            //This Activity will serve to Display the Image in full screen along with all the Texts, Description
            //And also a button to save the image that is showing.
        }

        private void FabOnClick(object sender, EventArgs e)
        {
            //Save the Image to the disk.
        }
    }
}