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
using SQLite.Net;
using System.IO;

namespace VTSClient.UI.DroidNative
{
    public class SQLite_Droid : ISQLite
    {
        public SQLiteConnection GetConnection(string fileName)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            // создаем подключение
            //var connection = new SQLiteConnection(path);

            //var a = new SQLiteConnection(platform, path);
            return new SQLiteConnection(platform, path);
        }
    }
}