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

namespace Astropix.Activities
{
    [Activity(Label = "ImageViewerActivity")]
    public class ImageViewerActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            //This Activity will serve to Display the Image in full screen along with all the Texts, Description
            //And also a button to save the image that is showing.
        }
    }
}