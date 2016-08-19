using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VTSClient.DataAccess.MockModel;
using VtsMockClient.Domain.Models;


namespace VTSClient.DataAccess.WebServices.Interfaces
{
    public interface ILoginWebService
    {
        Person Login(PersonCredentials model);
    }
}
