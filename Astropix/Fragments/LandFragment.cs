using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Astropix.Fragments
{
    public class LandFragment : Fragment
    {
        TextView downloadfirst;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view= inflater.Inflate(Resource.Layout.land_fragment, container, false);

            downloadfirst = view.FindViewById<TextView>(Resource.Id.download_first);

            return view;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}