using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using VTSClient.DataAccess.MockModel;
using VtsMockClient.Domain.Models;


namespace VTSClient.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Person> Authentication(string login, string password);
    }
}
