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

namespace Astropix.Misc
{
    class ConfigurationParameters
    {
        //These constants are the keys of the SharedPreferences this app is using.
        public const string imagequality = "imagequality";
        public const string enableservice = "enableservice";
        public const string isappfresh = "isappfresh";
    }
}