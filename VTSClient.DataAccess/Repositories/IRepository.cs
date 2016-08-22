using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VtsMockClient.Domain.Models;
using VTSClient.DataAccess.MockModel;

namespace VTSClient.DataAccess.Repositories
{
    public interface IRepository
    {
        Person Get(int id);

        void Create(Person model);

        Person GetCurrentUser();
    }
}
