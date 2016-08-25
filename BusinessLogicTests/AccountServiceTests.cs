using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using VTSClient.DataAccess.WebServices.Interfaces;
using VtsMockClient.Domain.Models;
using VTSClient.BusinessLogic.Services.Instances;
using VTSClient.DataAccess.Repositories;

namespace BusinessLogicTests
{
    [TestClass]
    public class AccountServiceTests
    {
        [TestMethod]
        public void Authentication_when_user_exist()
        {
            //arrange

            var login = "testName";
            var password = "testPassword";

            var accountWebServiceMock = new Mock<IWEB>();
            accountWebServiceMock.Setup(a => a.Login(It.IsAny<PersonCredentials>())).Returns(new Person() { Credentials = new PersonCredentials { Email = login, Password = password } });

            AccountService accountService = new AccountService(accountWebServiceMock.Object, Mock.Of<IRepository>());

            //act
            accountService.Authentication(login, password);

            //assert
            accountWebServiceMock.Verify(a => a.Login(It.Is<PersonCredentials>(p=>p.Email==login && p.Password == password)), Times.Once);
        }
    }
}
