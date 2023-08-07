using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.Business.DependencyResolvers;
using DevFramework.Northwind.DataAccess.Abstracts;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DevFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void ProductValidationTest()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
           // ProductManager productManager = new ProductManager(mock.Object,new AutoMapperModule());
           // productManager.Add(new Product());
        }
    }
}
