using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.DataAccess.WebServices.Interfaces;
using VTSClient.DataAccess.MockModel;


namespace VTSClient.DataAccess.WebServices.Services
{
    public class LoginWebService : ILoginWebService
    {
        public Person Login(PersonCredentials model)
        {
            return new Person();
        }
    }
}
