using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.DataAccess.MockModel;

namespace VTSClient.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);

        void Create(T model);
    }
}
