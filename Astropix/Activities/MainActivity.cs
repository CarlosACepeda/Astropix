﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Preferences;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Astropix.Activities;
using Astropix.Adapters;
using Astropix.DataRepository;
using Astropix.Misc;
using Astropix.Services;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Astropix
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ImageView background;
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager layoutManager;
        private ImageOfTheDayAdapter imageOfTheDayAdapter;
        private List<ImageOfTheDay> imagesOfTheDay = new List<ImageOfTheDay>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.content_main);
            IsApplicationFresh();
            DBHelper dbhelper = new DBHelper();

            recyclerView = FindViewById<RecyclerView>(Resource.Id.imagesOfTheDayList);
            ThreadPool.QueueUserWorkItem(method =>
            {
                imagesOfTheDay = dbhelper.SelectTableImageOfTheDay();

                imageOfTheDayAdapter = new ImageOfTheDayAdapter(imagesOfTheDay);
                layoutManager = new LinearLayoutManager(Application.Context);
                recyclerView.SetLayoutManager(layoutManager);
                RunOnUiThread(() =>
                recyclerView.SetAdapter(imageOfTheDayAdapter));
            });

            using (Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar))
            {
                SetSupportActionBar(toolbar);
            }
            using (background = FindViewById<ImageView>(Resource.Id.background))
            {
                using (var wallpaperManager = WallpaperManager.GetInstance(Application.Context))
                {
                    try
                    {
                        background.Background = wallpaperManager.FastDrawable;
                    }
                    catch
                    {
                        Log.Info("Astropix", "We don't have permission");
                    }
                }
            }

            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                //TODO: GO to settings screen
                Intent intent = new Intent(this, typeof(SettingsActivity));
                StartActivity(intent);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            //View view = (View) sender;
            //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            //Intent intent = new Intent(this, typeof(AstropixRetrieverService));
            //StartService(intent);
        }

        private void IsApplicationFresh()
        {
            if (new ConfigurationManager().RetrieveAValue(ConfigurationParameters.IsAppNotFresh)==false)
            {
                CreateDatabase();
                new ConfigurationManager().SaveAValue(ConfigurationParameters.IsAppNotFresh, true);
            }
        }

        private void CreateDatabase()
        {
            using (var dbhelper = new DBHelper())
            {
                dbhelper.CreateDatabase();
            }
        }
    }
}