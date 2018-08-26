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
using Android.Util;
using SQLite;
namespace Astropix.DataRepository
{
    class DBHelper: Java.Lang.Object
    {
        SQLiteConnection connection;
        readonly string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        readonly string databasename = "notifications.db";
        public bool CreateDatabase()
        {
            try
            {
                using (connection = new SQLiteConnection(System.IO.Path.Combine(folder, databasename)))
                {
                    connection.CreateTable<ImageOfTheDay>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warn("Error en la conexión a la base de datos", ex.Message);
                return false;
            }
        }
        public List<ImageOfTheDay> SelectTableImageOfTheDay()
        {
            try
            {
                using (connection = new SQLiteConnection(System.IO.Path.Combine(folder, databasename)))
                {
                    return connection.Table<ImageOfTheDay>().Reverse().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warn("Error.", ex.Message);
                return null;
            }
        }
        public bool InsertIntoTableImageOfTheDay(ImageOfTheDay imageOfTheDay)
        {
            try
            {
                using (connection = new SQLiteConnection(System.IO.Path.Combine(folder, databasename)))
                {
                    connection.Insert(imageOfTheDay);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warn("Error.", ex.Message);
                return false;
            }
        }
        //THis method is not neccesary, yet, anyway, is here if I need it some day.
        public bool UpdateTableImageOfTheDay(ImageOfTheDay imageOfTheDay)
        {
            try
            {
                using (connection = new SQLiteConnection(System.IO.Path.Combine(folder, databasename)))
                {
                    return false;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warn("Error.", ex.Message);
                return false;
            }
        }
        //This method is not necessary yet.
        public bool DeleteTableImageOfTheDay(ImageOfTheDay imageOfTheDay)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, databasename)))
                {
                    connection.Delete(imageOfTheDay);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Warn("Error.", ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Select a registry from the table using the url of the image, because that is the only way 
        /// I have to identify an Image of the Day, the API does not provide an unique Id.
        /// </summary>
        /// <param name="hd_url"></param>
        /// <returns></returns>
        public bool SelectQueryImageOfTheDay(string hd_url)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "notifications.db")))
                {
                    connection.Query<ImageOfTheDay>("SELECT * FROM ImageOfTheDay Where Hd_Url=?", hd_url);
                    return true;
                }
            }
            catch
            {
                return false;
            }
            
        }
    }
}