using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.BusinessLogic.Services.Interfaces;
//using VTSClient.DataAccess.MockModel;
using VTSClient.DataAccess.WebServices.Interfaces;
using VtsMockClient.Domain.Models;
using VTSClient.DataAccess.Repositories;

namespace VTSClient.BusinessLogic.Services.Instances
{
    public class AccountService : IAccountService
    {
        private List<PersonCredentials> userList;

        private IWEB loginWebService;
        private IRepository personrepository;

        public AccountService(IWEB _loginWebService, IRepository repo)
        {
            this.loginWebService = _loginWebService;
            this.personrepository = repo;
            //this.Init();
        }

        public async Task<Person> Authentication(string login, string password)
        {

            var model = new PersonCredentials { Email = login, Password = password };
            
            var person = await loginWebService.Login(model);

            //personrepository = new PersonRepository();

            if (!String.IsNullOrEmpty(person.Id.ToString()))
                personrepository.Create(new DataAccess.MockModel.Person {
                    FullName = person.FullName,
                    Id = person.Id
                });

            return person;
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
