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

using VTSClient.DataAccess.Repositories;
using SQLite;
using System.IO;
using Xamarin.Forms;
using VTSClient.UI.Droid;
using SQLite.Net;


[assembly: Dependency(typeof(SQLite_Droid))]
namespace VTSClient.UI.Droid
{
    public class SQLite_Droid : ISQLite
    {
        //public SQLite_Droid() { }
        public SQLiteConnection GetConnection(string fileName)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            // создаем подключение
            //var connection = new SQLiteConnection(path);

            var a = new SQLiteConnection(platform, path);
            return new SQLiteConnection(platform, path);
        }

        public string GetPath(string fileName)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            // создаем подключение

            return path;
        }
    }
}