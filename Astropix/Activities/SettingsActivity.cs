using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Astropix.Fragments;

namespace Astropix.Activities
{
    [Activity(Label = "@string/settings", Theme = "@style/AppTheme.NoActionBar")]
    public class SettingsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.settings_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            FragmentManager.BeginTransaction().Replace(Resource.Id.container, new PreferencesFragment()).Commit();
        }
    }
}