using NUnit.Framework;
using System.Linq;
using Moq;
using ProjectManagement.Data;
using EHealthcare.Entities;
using ProjectManagement.Api.Controllers;

namespace EHealthcareApi.Test
{
    [TestFixture]
    public class CartControllerTests : BaseController<Cart>
    {
        readonly Mock<IBaseRepository<Cart>> mockCart = new Mock<IBaseRepository<Cart>>();
        readonly Mock<IBaseRepository<CartItem>> mockCartItem = new Mock<IBaseRepository<CartItem>>();

        [Test]
        public void getUserByIDTest()
        {
             mockCart.Setup(x => x.Get().Where(a => a.OwnerID == It.IsAny<long>())).Returns((IQueryable<Cart>)new Cart() { ID=100, OwnerID=101, Owner=new User() { ID = 101, Address = "testaddress", Email = "test@mail", FirstName = "testname", IsAdmin = false, Password = "testpwd" } });
             CartController cartController = new CartController(mockCartItem.Object);
             var res = cartController.Get(101);
             Assert.IsNotNull(res);
        }

        [Test]
        public void PlaceOrderTest()
        {
             // when cart is not null
             mockCart.Setup(x => x.Get().Where(a => a.OwnerID == It.IsAny<long>())).Returns((IQueryable<Cart>)new Cart() { ID = 100, OwnerID = 101, Owner = new User() { ID = 101, Address = "testaddress", Email = "test@mail", FirstName = "testname", IsAdmin = false, Password = "testpwd" } });
             mockCartItem.Setup(x => x.Delete(It.IsAny<long>()));
             CartController cartController = new CartController(mockCartItem.Object);
             var res = cartController.PlaceOrder(101);
             Assert.IsNotNull(res);
             
             // when cart is null
             mockCart.Setup(x => x.Get().Where(a => a.OwnerID == It.IsAny<long>())).Returns((IQueryable<Cart>)null);
             mockCart.Setup(x => x.Add(It.IsAny<Cart>()));
             CartController cartController1 = new CartController(mockCartItem.Object);
             var res1 = cartController.PlaceOrder(101);
             Assert.IsNotNull(res1);

        }
        [Test]
        public void AddProductByIDTest()
        {
             //when cart is not null
             mockCart.Setup(x => x.Get().Where(a => a.OwnerID == It.IsAny<long>())).Returns((IQueryable<Cart>)new Cart() { ID = 100, OwnerID = 101, Owner = new User() { ID = 101, Address = "testaddress", Email = "test@mail", FirstName = "testname", IsAdmin = false, Password = "testpwd" } });
             mockCartItem.Setup(x => x.Add(It.IsAny<CartItem>()));
             CartController cartController = new CartController(mockCartItem.Object);
             var res = cartController.PlaceOrder(101);
             Assert.IsNotNull(res);
             
             // when cart is null
             mockCart.Setup(x => x.Get().Where(a => a.OwnerID == It.IsAny<long>())).Returns((IQueryable<Cart>)null);
             mockCart.Setup(x => x.Add(It.IsAny<Cart>()));
             CartController cartController1 = new CartController(mockCartItem.Object);
             var res1 = cartController.PlaceOrder(101);
             Assert.IsNotNull(res);
        }

        [Test]
        public void DeleteTest()
        {
             mockCartItem.Setup(x => x.Delete(It.IsAny<long>()));
             CartController cartController = new CartController(mockCartItem.Object);
             var res = cartController.Delete(101);
             Assert.IsNotNull(res);
        }

    }
}