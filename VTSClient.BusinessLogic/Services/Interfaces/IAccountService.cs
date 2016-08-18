using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.DataAccess.MockModel;


namespace VTSClient.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        PersonCredentials Authentication(string login, string password);
    }
}
