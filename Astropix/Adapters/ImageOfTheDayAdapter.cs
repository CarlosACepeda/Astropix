using System;

using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Astropix.DataRepository;
using System.Collections.Generic;
using Astropix.Factories;
using Android.Content;
using Android.App;
using Astropix.Activities;
using Android.Graphics;
using Android.Graphics.Drawables;
using Java.IO;

namespace Astropix.Adapters
{
    class ImageOfTheDayAdapter : RecyclerView.Adapter
    {
        private List<ImageOfTheDay> imagesOfTheDay = new List<ImageOfTheDay>();
        public static Bitmap bitmap;
        public ImageOfTheDayAdapter(List<ImageOfTheDay> imagesOfTheDay )
        {
            this.imagesOfTheDay = imagesOfTheDay;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.imageofthedayitemrow;
            itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new ImageOfTheDayAdapterViewHolder(itemView);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {

            // Replace the contents of the view with that element
            var holder = viewHolder as ImageOfTheDayAdapterViewHolder;
            holder.title.Text = imagesOfTheDay[position].Title;
            holder.explanation.Text = imagesOfTheDay[position].Explanation;
            holder.copyright.Text = imagesOfTheDay[position].Copyright;
            bitmap= ImageComposer.RetrieveImagey(imagesOfTheDay[position].Url);
            holder.image.SetImageBitmap(bitmap);
            holder.image.Click += Image_Click;

        }


        public override int ItemCount => imagesOfTheDay.Count;

        private void Image_Click(object sender, EventArgs e)
        {            
            using (Intent intent = new Intent(Application.Context, typeof(ImageViewerActivity)))
            {
                Application.Context.StartActivity(intent);
            }
        }

    }

    public class ImageOfTheDayAdapterViewHolder : RecyclerView.ViewHolder
    {
        public ImageView image;
        public TextView title;
        public TextView explanation;
        public TextView copyright;

        public ImageOfTheDayAdapterViewHolder(View itemView) : base(itemView)
        {

            image = itemView.FindViewById<ImageView>(Resource.Id.ivImageOfTheDay);
            title = itemView.FindViewById<TextView>(Resource.Id.tvTitle);
            explanation = itemView.FindViewById<TextView>(Resource.Id.tvExplanation);
            copyright = itemView.FindViewById<TextView>(Resource.Id.tvCopyright);

        }

        
    }

}