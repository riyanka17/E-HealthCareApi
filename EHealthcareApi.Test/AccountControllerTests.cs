using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Moq;
using ProjectManagement.Data;
using Ehealthcare.Entities;
using EHealthcare.Api.Controllers;

namespace EHealthcareApi.Test
{
    [TestFixture]
    public class AccountControllerTests: Controller
    {
       readonly Mock<IBaseRepository<Account>> mockRepoAccount = new Mock<IBaseRepository<Account>>();

        [Test]
        public void getAccountDetailsTest()
        {
               mockRepoAccount.Setup(x => x.Get().Where(a=>a.Email==It.IsAny<string>())).Returns((IQueryable<Account>)new Account() { AccNumber = 12345, Amount = 1000, Email = "testemail", ID = 1 });
               AccountController accountControllerobj = new AccountController(mockRepoAccount.Object);
               var res = accountControllerobj.getAccountDetails("testemail");
               Assert.IsNotNull(res);
        }

        [Test]
        public void addfundsTest()
        {
            
               mockRepoAccount.SetupGet(x => x.Get().Where(a => a.Email == It.IsAny<string>())).Returns((IQueryable<Account>)new Account() { AccNumber = 12345, Amount = 1000, Email = "testemail", ID = 1 });
               mockRepoAccount.Setup(x => x.Update(It.IsAny<Account>()));
               AccountController accountControllerobj = new AccountController(mockRepoAccount.Object);
               var res = accountControllerobj.AddFunds(new Account() { AccNumber = 12345, Amount = 1000, Email = "testemail", ID = 1 });
               Assert.IsNotNull(res);
        }
    }
}