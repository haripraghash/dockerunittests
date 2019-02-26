using System;
using System.Collections.Generic;
using dockerunittests.dataaccess;
using dockerunittests.domain;
using dockerunittests.services;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private Mock<IProductsRepository> mockProductRepository;
        private string shouldFailTest = Environment.GetEnvironmentVariable("FAIL_TEST");
        [SetUp]
        public void Setup()
        {
            this.mockProductRepository = new Mock<IProductsRepository>();
        }

        [Test]
        public void Given_ProductId_ProductServices_Returns_Product()
        {
            this.mockProductRepository.Setup(x => x.Products).Returns(new List<Product>()
                {new Product() {Id = 1, Name = "product1"}, new Product() {Id = 1, Name = "product1"}});

            var productService = new ProductsService(this.mockProductRepository.Object);

            var actualResult = productService.GetById(1).Result;
            Assert.IsTrue(actualResult.Id == 1);
        }

        [Test]
        public void Given_ExistingProducts_ProductServices_Returns_All_Products()
        {
            this.mockProductRepository.Setup(x => x.Products).Returns(new List<Product>()
                {new Product() {Id = 1, Name = "product1"}, new Product() {Id = 1, Name = "product1"}});

            var productService = new ProductsService(this.mockProductRepository.Object);

            var actualResult = productService.GetAll().Result;
            Assert.IsTrue(actualResult.Count == 2);
        }

        [Test]
        public void Externally_Controlled_Test()
        {
            if (!string.IsNullOrEmpty(shouldFailTest))
            {
                Assert.Fail("Test failed because FAIL_TEST environment variable is set");
            }
            else
            {
                Assert.Pass();
            }
        }
    }
}