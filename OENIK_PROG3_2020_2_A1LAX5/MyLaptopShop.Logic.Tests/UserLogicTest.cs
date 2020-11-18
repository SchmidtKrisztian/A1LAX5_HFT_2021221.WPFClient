using Moq;
using MyLaptopShop.Logic.Classes;
using MyLaptopShop.Repository.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLaptopShop.Logic.Tests
{
    /// <summary>
    /// A class to test the UserLogic.
    /// </summary>
    class UserLogicTest
    {
        private static UserLogic userlogic;

        private static Mock<BrandRepository> brandRepoMock;
        private static Mock<LaptopRepository> laptopRepoMock;
        private static Mock<SpecificationRepository> specRepoMock;

        [SetUp]
        public static void Setup()
        {

        }
    }
}
