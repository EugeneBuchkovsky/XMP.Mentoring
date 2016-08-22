//using SQLite;
using System.IO;
using VTSClient.DataAccess.MockModel;

using SQLite.Net;


namespace VTSClient.DataAccess.Repositories
{
    public class PersonRepository : IRepository
    {
        private SQLiteConnection connection;
        private ISQLite sqlite;

        public PersonRepository(ISQLite _sqlite)
        {
            sqlite = _sqlite;
            this.connection = sqlite.GetConnection("Person.db");

            connection.CreateTable<Person>();
        }

        public void Create(Person model)
        {
            connection.Insert(model);
        }

        public Person Get(int id)
        {
            return connection.Get<Person>(id);
        }

        public Person GetCurrentUser()
        {
            var id = connection.Table<Person>().Count();
            return connection.Table<Person>().ElementAt(id-1);
        }
    }
}
