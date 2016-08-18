using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.BusinessLogic.Services.Interfaces;
using VTSClient.DataAccess.MockModel;



namespace VTSClient.BusinessLogic.Services.Instances
{
    public class AccountService : IAccountService
    {
        private List<PersonCredentials> userList;
        

        public AccountService()
        {
            this.Init();
        }

        public PersonCredentials Authentication(string login, string password)
        {
            return userList.FirstOrDefault(u => u.Email == login && u.Password == password);
            //var result = webService.Login(login, password);
            //if (result != null)
            //{
            //    var user = new User
            //    {
            //        Login = result.FullName
            //    };
            //    return user;
            //}
            //return null;
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
