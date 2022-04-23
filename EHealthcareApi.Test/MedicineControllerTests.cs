using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Moq;
using ProjectManagement.Data;
using EHealthcare.Entities;
using System.Collections.Generic;
using Ehealthcare.Api.Controllers;

namespace EHealthcareApi.Test
{
    [TestFixture]
    public class MedicineControllerTests: Controller
    {
       readonly Mock<IBaseRepository<Product>> mockRepoProduct = new Mock<IBaseRepository<Product>>();

        [Test]
        public void SearchMedicineByDiseaseTest()
        {
             List<Product> list=new List<Product>() { new Product() { ID = 1, CompanyName = "testcompany", ExpireDate = "testdate", ImageUrl = "testurl", Name = "testname", Price = 123, Quantity = 1, Uses = "testuse" } };
             mockRepoProduct.Setup(x => x.Get().Where(p => p.Uses.Contains(It.IsAny<string>()))).Returns((IQueryable<Product>)list);
             MedicineController medControllerobj = new MedicineController(mockRepoProduct.Object);
             var res = medControllerobj.SearchMedicineByDisease("testuses");
             Assert.IsNotNull(res);
        }

        [Test]
        public void getAllTest()
        {
             List<Product> list = new List<Product>() { new Product() { ID = 1, CompanyName = "testcompany", ExpireDate = "testdate", ImageUrl = "testurl", Name = "testname", Price = 123, Quantity = 1, Uses = "testuse" } };
             mockRepoProduct.Setup(x => x.Get()).Returns((IQueryable<Product>)list);
             MedicineController medControllerobj = new MedicineController(mockRepoProduct.Object);
             var res = medControllerobj.GetAll();
             Assert.IsNotNull(res);
        }
    }
}