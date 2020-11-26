// <copyright file="UserLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Moq;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Logic.Classes;
    using MyLaptopShop.Repository.Classes;
    using MyLaptopShop.Repository.Interfaces;
    using NUnit.Framework;

    /// <summary>
    /// A class to test the UserLogic.
    /// </summary>
    [TestFixture]
    public class UserLogicTest
    {
        private UserLogic userlogic;

        private List<Brand> brandList;
        private List<Laptop> laptopList;
        private List<Specification> specList;

        private Mock<IBrandRepository> brandRepoMock;
        private Mock<ILaptopRepository> laptopRepoMock;
        private Mock<ISpecificationRepository> specRepoMock;

        /// <summary>
        /// Sets the tests up.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            this.brandRepoMock = new Mock<IBrandRepository>();
            this.laptopRepoMock = new Mock<ILaptopRepository>();
            this.specRepoMock = new Mock<ISpecificationRepository>();

            this.brandList = new List<Brand>
            {
                new Brand() { Id = 1, Name = "brandname1", FoundationYear = 2019, Headquarters = "place1", CEOName = "ceo1" },
                new Brand() { Id = 2, Name = "brandname2", FoundationYear = 2020, Headquarters = "place2", CEOName = "ceo2" },
            };

            this.laptopList = new List<Laptop>
            {
                new Laptop() { Id = 1, Name = "laptopname1", BrandId = 1, ReleaseYear = 2019, BasePrice = 10 },
                new Laptop() { Id = 2, Name = "laptopname2", BrandId = 2, ReleaseYear = 2020, BasePrice = 20 },
            };

            this.specList = new List<Specification>
            {
                new Specification() { Id = 1, LaptopId = 1, Name = "Gamer", CPU = "cpu1", GraphicsCardName = "vga1", RAM = 1, AdditionalPrice = 10 },
                new Specification() { Id = 2, LaptopId = 2, Name = "Work", CPU = "cpu2", GraphicsCardName = "vga2", RAM = 2, AdditionalPrice = 20 },
            };

            this.brandRepoMock.Setup(x => x.GetAll()).Returns(this.brandList.AsQueryable());
            this.laptopRepoMock.Setup(x => x.GetAll()).Returns(this.laptopList.AsQueryable());
            this.specRepoMock.Setup(x => x.GetAll()).Returns(this.specList.AsQueryable());

            this.userlogic = new UserLogic(this.brandRepoMock.Object, this.laptopRepoMock.Object, this.specRepoMock.Object);
        }

       /// <summary>
       /// Test the LaptopCount() method.
       /// </summary>
        [Test]
        public void TestLaptopCount()
        {
            // Arrange
            this.brandRepoMock.Setup(x => x.GetAll()).Returns(this.brandList.AsQueryable());
            this.laptopRepoMock.Setup(x => x.GetAll()).Returns(this.laptopList.AsQueryable());

            // Act
            List<string> expected = new List<string>();
            expected.Add("COUNTRY: place1\t LAPTOPS COUNT: 1");
            expected.Add("COUNTRY: place2\t LAPTOPS COUNT: 1");

            // Assert
            List<string> result = this.userlogic.LaptopCount().ToList<string>();
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.First(), Is.EqualTo(expected.First()));
            Assert.That(result.Last(), Is.EqualTo(expected.Last()));
            Assert.That(result, Is.EquivalentTo(expected));
        }

        /// <summary>
        /// Test the AvgSpecPrice() method.
        /// </summary>
        [Test]
        public void TestAvgSpecPrice()
        {
            // Arrange
            this.laptopRepoMock.Setup(x => x.GetAll()).Returns(this.laptopList.AsQueryable());
            this.specRepoMock.Setup(x => x.GetAll()).Returns(this.specList.AsQueryable());

            // Act
            List<string> expected = new List<string>();
            expected.Add("LAPTOP: laptopname1\t\t AVERAGE PRICE: 10");
            expected.Add("LAPTOP: laptopname2\t\t AVERAGE PRICE: 20");

            // Assert
            List<string> result = this.userlogic.AvgSpecPrice().ToList<string>();
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.First(), Is.EqualTo(expected.First()));
            Assert.That(result.Last(), Is.EqualTo(expected.Last()));
            Assert.That(result, Is.EquivalentTo(expected));
        }

        /// <summary>
        /// Tests the GamerBrand() method.
        /// </summary>
        [Test]
        public void TestGamerBrand()
        {
            // Arrange
            this.brandRepoMock.Setup(x => x.GetAll()).Returns(this.brandList.AsQueryable());
            this.laptopRepoMock.Setup(x => x.GetAll()).Returns(this.laptopList.AsQueryable());
            this.specRepoMock.Setup(x => x.GetAll()).Returns(this.specList.AsQueryable());

            // Act
            List<string> lista = new List<string>();
            lista.Add("brandname1");

            // Assert
            List<string> result = this.userlogic.GamerBrand().ToList<string>();
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.First(), Is.EqualTo(lista.First()));
            Assert.That(result.Last(), Is.EqualTo(lista.Last()));
            Assert.That(result, Is.EquivalentTo(lista));
        }

        /// <summary>
        /// Tests the SpecGetOne() method.
        /// </summary>
        /// <param name="id">ID of the Specification we want to list.</param>
        [TestCase(0)]
        public void TestSpecGetOne(int id)
        {
            // Arrange
            this.specRepoMock.Setup(r => r.GetOne(id)).Returns(this.specList[id]).Verifiable();

            // Act
            this.userlogic.SpecGetOne(id);

            // Assert
            this.specRepoMock.Verify(r => r.GetOne(id));
        }

       /// <summary>
       /// Test the GetAllBrand() method.
       /// </summary>
        [Test]
        public void TestGetAllBrand()
        {
            // Arrange
            this.brandRepoMock.Setup(r => r.GetAll()).Verifiable();

            // Act
            this.userlogic.GetAllBrand();

            // Assert
            this.brandRepoMock.Verify(r => r.GetAll());
        }
    }
}
