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
using SQLite;
namespace Astropix.DataRepository
{
    class DBHelper
    {
        SQLiteCommand sqlCommand;
        SQLiteConnection sqlConnection;
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        void CreateDatabase()
        {
            //
        }
    }
}