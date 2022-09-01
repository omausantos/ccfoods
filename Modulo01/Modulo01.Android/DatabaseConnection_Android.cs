using System;
using System.IO;
using Modulo01.Droid;
using Modulo01.Infrastructure;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace Modulo01.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "CCFoods.db");
            return new SQLiteConnection(path);
        }
    }
}

