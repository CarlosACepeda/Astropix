using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Content;
using Astropix.Services;
using System.Threading;
using Astropix.Factories;
using System.Threading.Tasks;
using Android.Graphics;
using Astropix.Activities;
using Astropix.DataRepository;
using Android.Support.V7.Widget;
using Astropix.Adapters;
using System.Collections.Generic;
using Android.Support.V7.Preferences;
using Astropix.Misc;

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

            imagesOfTheDay = dbhelper.SelectTableImageOfTheDay();



            using (recyclerView = FindViewById<RecyclerView>(Resource.Id.imagesOfTheDayList))
            {
                imageOfTheDayAdapter = new ImageOfTheDayAdapter(imagesOfTheDay);
                layoutManager = new LinearLayoutManager(Application.Context);
                recyclerView.SetLayoutManager(layoutManager);
                recyclerView.SetAdapter(imageOfTheDayAdapter);
            };

            using (Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar))
            {
                SetSupportActionBar(toolbar);
            }
            using (background = FindViewById<ImageView>(Resource.Id.background))
            {
                using (var wallpaperManager = WallpaperManager.GetInstance(Application.Context))
                {
                    background.Background = wallpaperManager.FastDrawable;
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
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context))
            {
                if (sharedPreferences.GetBoolean(ConfigurationParameters.isappfresh, true) == true)
                {
                    CreateDatabase();
                    using (ISharedPreferencesEditor sharedPreferencesEditor = sharedPreferences.Edit())
                    {
                        sharedPreferencesEditor.PutBoolean(ConfigurationParameters.isappfresh, false);
                    }
                }
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

