using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Astropix.Activities;
using Astropix.DataRepository;
using System;
using System.Collections.Generic;

namespace Astropix.Adapters
{
    internal class ImageOfTheDayAdapter : RecyclerView.Adapter
    {
        private List<ImageOfTheDay> imagesOfTheDay = new List<ImageOfTheDay>();

        public ImageOfTheDayAdapter(List<ImageOfTheDay> imagesOfTheDay)
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
            holder.container.Click += Container_Click;

            if (DateTime.Now.Day == imagesOfTheDay[position].Date.Day)
            {
                holder.when.Text = "Today";
            }
            else
            {
                holder.when.Text = imagesOfTheDay[position].Date.ToShortDateString();
            }
        }

        private void Container_Click(object sender, EventArgs e)
        {
            LinearLayout container = sender as LinearLayout;
            using (Intent intent = new Intent(container.Context, Java.Lang.Class.FromType(typeof(ImageViewerActivity))))
            {
                Application.Context.StartActivity(intent);
            }
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
        public TextView title;
        public TextView explanation;
        public TextView copyright;
        public TextView when;
        public LinearLayout container;

        public ImageOfTheDayAdapterViewHolder(View itemView) : base(itemView)
        {
            when = itemView.FindViewById<TextView>(Resource.Id.tvWhen);
            title = itemView.FindViewById<TextView>(Resource.Id.tvTitle);
            explanation = itemView.FindViewById<TextView>(Resource.Id.tvExplanation);
            copyright = itemView.FindViewById<TextView>(Resource.Id.tvCopyright);
            container = itemView.FindViewById<LinearLayout>(Resource.Id.itemcontainer);
        }
    }
}