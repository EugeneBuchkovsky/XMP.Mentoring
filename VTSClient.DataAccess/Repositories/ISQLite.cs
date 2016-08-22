//using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;

namespace VTSClient.DataAccess.Repositories
{
    public interface ISQLite
    {
        string GetPath(string fileName);
        SQLiteConnection GetConnection(string fileName);
    }
}
