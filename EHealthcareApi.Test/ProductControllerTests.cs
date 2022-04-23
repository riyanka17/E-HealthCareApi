using NUnit.Framework;
using Moq;
using ProjectManagement.Data;
using ProjectManagement.Api.Controllers;
using EHealthcare.Entities;

namespace EHealthcareApi.Test
{
    [TestFixture]
    public class ProductControllerTests : BaseController<Product>
    {
       readonly Mock<IBaseRepository<Category>> mockCartRepo = new Mock<IBaseRepository<Category>>();
       readonly Mock<BaseController<Product>> mockBase = new Mock<BaseController<Product>>();

        [Test]
        public void AddMedicineTest()
        {
             mockBase.Setup(x => x.Post(It.IsAny<Product>()));
             ProductController productController = new ProductController(mockCartRepo.Object);
             var res = productController.AddMedicine(new Product());
             Assert.IsNotNull(res);
        }

        [Test]
        public void UpdateMedicineTest()
        {
             mockBase.Setup(x => x.Post(It.IsAny<Product>()));
             ProductController productController = new ProductController(mockCartRepo.Object);
             var res = productController.UpdateMedicine(new Product());
             Assert.IsNotNull(res);
        }
        
        [Test]
        public void UpdateMedicineByIDTest()
        {
             mockBase.Setup(x => x.Get(It.IsAny<long>()));
             ProductController productController = new ProductController(mockCartRepo.Object);
             var res = productController.UpdateMedicine(201);
             Assert.IsNotNull(res);
        }

        [Test]
        public void DeleteMedicineTest()
        {
             mockBase.Setup(x => x.Delete(It.IsAny<long>()));
             ProductController productController = new ProductController(mockCartRepo.Object);
             var res = productController.Delete(201);
             Assert.IsNotNull(res);
        }
    }
}