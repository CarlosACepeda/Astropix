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
    public class PreferencesFragment : Android.Support.V14.Preferences.PreferenceFragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            AddPreferencesFromResource(Resource.Xml.prefs);
        }
        public override void OnCreatePreferences(Bundle savedInstanceState, string rootKey)
        {
            
        }
    }
}