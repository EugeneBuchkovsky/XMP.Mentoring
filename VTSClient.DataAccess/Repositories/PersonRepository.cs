using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.DataAccess.MockModel;

namespace VTSClient.DataAccess.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private SQLiteConnection connection;

        public PersonRepository(SQLiteConnection _connection)
        {
            this.connection = _connection;
            //string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"ormdemo.db3");
            //connection = 
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
    }
}
