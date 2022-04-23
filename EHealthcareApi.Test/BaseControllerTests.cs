using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectManagement.Data;
using Ehealthcare.Entities;
using EHealthcare.Entities;
using Microsoft.AspNetCore.Http;
using ProjectManagement.Api.Controllers;

namespace EHealthcareApi.Test
{
    [TestFixture]
    public class BaseControllerTests <T> : ControllerBase where T : BaseEntity
    {
       readonly Mock<IBaseRepository<Account>> mockRepoAccount = new Mock<IBaseRepository<Account>>();
         readonly Mock<IBaseRepository<T>> Repository=new Mock<IBaseRepository<T>>();
        private readonly Mock<IBaseRepository<User>> UserRepository=new Mock<IBaseRepository<User>>();
        private readonly Mock<IHttpContextAccessor> HttpContextAccessor=new Mock<IHttpContextAccessor>();

        [Test]
        public void GetTest()
        {
            
             BaseController<T> basecontrollerobj = new BaseController<T>();
             // when result is not null
             BaseEntity Id = new BaseEntity() { ID = 1 };
             Repository.Setup(x => x.Get(It.IsAny<long>())).Returns((T)Id);
             var res = basecontrollerobj.Get(1);
             Assert.IsNotNull(res);
             
             // when id is null
             var res1 = basecontrollerobj.Get(null);
            Assert.IsNotNull(res1);

            //  when result is null
            BaseEntity Id1 = null;
             Repository.Setup(x => x.Get(It.IsAny<long>())).Returns((T)Id1);
             var res2 = basecontrollerobj.Get(1);
            Assert.IsNotNull(res2);

        }

        [Test]
        public void PostTest()
        {
             BaseController<T> basecontrollerobj = new BaseController<T>();
             BaseEntity Id = new BaseEntity() { ID = 1 };
             Repository.Setup(x => x.Add(It.IsAny<T>()));
             var res = basecontrollerobj.Post((T)Id);
            Assert.IsNotNull(res);
        }

        [Test]
        public void PutTest()
        {
             BaseController<T> basecontrollerobj = new BaseController<T>();
             BaseEntity Id = new BaseEntity() { ID = 1 };
             Repository.Setup(x => x.Update(It.IsAny<T>()));
             var res = basecontrollerobj.Put((T)Id);
             Assert.IsNotNull(res);
        }

        [Test]
        public void DeleteTest()
        {
             BaseController<T> basecontrollerobj = new BaseController<T>();
             // existing is not null
             BaseEntity Id = new BaseEntity() { ID = 1 };
             Repository.Setup(x => x.Get(It.IsAny<long>())).Returns((T)Id);
             Repository.Setup(x => x.Delete(It.IsAny<long>()));
             var res = basecontrollerobj.Delete(1);
             Assert.IsNotNull(res);

            // existing is null
            Repository.Setup(x => x.Get(It.IsAny<long>())).Returns((T)null);
            var res1 = basecontrollerobj.Delete(1);
            Assert.IsNotNull(res1);

        }
    }
}