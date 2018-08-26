using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Astropix.Adapters;

namespace Astropix.Activities
{
    [Activity(Label = "ImageViewerActivity")]
    public class ImageViewerActivity : Activity
    {
        FloatingActionButton fab;
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