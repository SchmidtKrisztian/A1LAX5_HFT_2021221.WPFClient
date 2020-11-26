// <copyright file="AdministratorLogicTest.cs" company="PlaceholderCompany">
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
    /// Test class of the AdministratorLogic class.
    /// </summary>
    [TestFixture]
    public class AdministratorLogicTest
    {
        private AdministratorLogic adminlogic;

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

            this.adminlogic = new AdministratorLogic(this.brandRepoMock.Object, this.laptopRepoMock.Object, this.specRepoMock.Object);
        }

        /// <summary>
        /// Tests the DeleteSpec() method.
        /// </summary>
        /// <param name="id">ID of the specification we want to delete.</param>
        [TestCase(1)]
        public void TestDeleteSpec(int id)
        {
            // Arrange
            this.specRepoMock.Setup(r => r.Delete(id)).Verifiable();

            // Act
            this.adminlogic.DeleteSpec(id);

            // Assert
            this.specRepoMock.Verify(b => b.Delete(id));
        }

        /// <summary>
        /// Tests the AddLaptop() method.
        /// </summary>
        /// <param name="bid">The brandid of the Laptop, we want to add.</param>
        /// <param name="name">The name of the laptop, we want to add.</param>
        /// <param name="ryear">The release year of the laptop, we want to add.</param>
        /// <param name="price">The additional price of the laptop, we want to add.</param>
        [TestCase(1, "name3", 2020, 30)]
        public void TestAddLaptop(int bid, string name, int ryear, int price)
        {
            // Arrange
            this.laptopRepoMock.Setup(r => r.Add(bid, name, ryear, price)).Verifiable();

            // Act
            this.adminlogic.AddLaptop(bid, name, ryear, price);

            // Assert
            this.laptopRepoMock.Verify(b => b.Add(bid, name, ryear, price));
        }

        /// <summary>
        /// Test the BrandUpdate() method.
        /// </summary>
        /// <param name="id">The ID of the brand we want to update.</param>
        /// <param name="name">The new name.</param>
        /// <param name="fyear">The new foundation year.</param>
        /// <param name="headquarters">The new Headquarters.</param>
        /// <param name="ceo">The new CEOs name.</param>
        [TestCase(1, "newname", 2020, "newplace", "newceo")]
        public void TestBrandUpdate(int id, string name, int fyear, string headquarters, string ceo)
        {
            // Arrange
            this.brandRepoMock.Setup(r => r.Update(id, name, fyear, headquarters, ceo)).Verifiable();

            // Act
            this.adminlogic.BrandUpdate(id, name, fyear, headquarters, ceo);

            // Assert
            this.brandRepoMock.Verify(b => b.Update(id, name, fyear, headquarters, ceo));
        }
    }
}
