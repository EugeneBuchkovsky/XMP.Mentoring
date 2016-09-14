using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VTSClient.DataAccess.Repositories;

namespace VTSClient.UI.iOSNative
{
    public class SQLite_iOS : ISQLite
    {
        //public SQLite_iOS() { }
        public SQLiteConnection GetConnection(string sqliteFilename)
        {
            // определяем путь к бд
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // папка библиотеки
            var path = Path.Combine(libraryPath, sqliteFilename);

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            // создаем подключение
            var conn = new SQLiteConnection(platform, path);

            return conn;
        }

    }
}
