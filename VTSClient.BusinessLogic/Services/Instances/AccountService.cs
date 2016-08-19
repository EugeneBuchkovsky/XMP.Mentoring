using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.BusinessLogic.Services.Interfaces;
//using VTSClient.DataAccess.MockModel;
using VTSClient.DataAccess.WebServices.Interfaces;
using VtsMockClient.Domain.Models;

namespace VTSClient.BusinessLogic.Services.Instances
{
    public class AccountService : IAccountService
    {
        private List<PersonCredentials> userList;

        private IWEB loginWebService;

        public AccountService(IWEB _loginWebService)
        {
            this.loginWebService = _loginWebService;
            this.Init();
        }

        public Person Authentication(string login, string password)
        {

            var model = new PersonCredentials { Email = login, Password = password };
            return loginWebService.Login(model);
        }

        public void Registration(PersonCredentials user)
        {
            throw new NotImplementedException();
        }

        private void Init()
        {

            userList = new List<PersonCredentials>();
            var user1 = new PersonCredentials
            {
                Email = "Eugene",
                Password = "1"
            };

            var user2 = new PersonCredentials
            {
                Email = "Dinka",
                Password = "1"
            };

            var user3 = new PersonCredentials
            {
                Email = "Nat",
                Password = "1"
            };

            userList.Add(user1);
            userList.Add(user2);
            userList.Add(user3);
        }
    }
}
