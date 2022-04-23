using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Moq;
using ProjectManagement.Data;
using EHealthcare.Entities;
using Ehealthcare.Api.Controllers;

namespace EHealthcareApi.Test
{
    [TestFixture]
    public class UserControllerTests: ControllerBase
    {
       readonly Mock<IBaseRepository<User>> mockUserRepo = new Mock<IBaseRepository<User>>();

        [Test]
        public void RegisterTest()
        {
             mockUserRepo.Setup(x => x.Add(It.IsAny<User>()));
             UserController userController = new UserController(mockUserRepo.Object);
             var res = userController.Register(new User());
             Assert.AreEqual("User created", res);
        }

        [Test]
        public void UpdateTest()
        {
             mockUserRepo.Setup(x => x.Update(It.IsAny<User>()));
             UserController userController = new UserController(mockUserRepo.Object);
             var res = userController.Update(new User());
             Assert.AreEqual("User is updated", res);
        }

        [Test]
        public void FindUserByMailTest()
        {
             mockUserRepo.Setup(x => x.Get().Where(u => u.Email == It.IsAny<string>()));
             UserController userController = new UserController(mockUserRepo.Object);
             var res = userController.Find("test@mail");
             Assert.IsNotNull(res);
        }
    }
}