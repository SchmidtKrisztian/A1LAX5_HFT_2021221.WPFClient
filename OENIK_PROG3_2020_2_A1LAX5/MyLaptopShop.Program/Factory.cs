// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Logic.Classes;
    using MyLaptopShop.Repository.Classes;

    /// <summary>
    /// Factory class to make an instances for alll the classses.
    /// </summary>
    public class Factory
    {
        private static LaptopShopContext ctx = new LaptopShopContext();
        private static BrandRepository brandrepo = new BrandRepository(ctx);
        private static LaptopRepository laptoprepo = new LaptopRepository(ctx);
        private static SpecificationRepository specrepo = new SpecificationRepository(ctx);

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.Laptoplogic = new AdministratorLogic(brandrepo, laptoprepo, specrepo);
        }

        /// <summary>
        /// Gets or sets the Laptoplogic instance.
        /// </summary>
        public AdministratorLogic Laptoplogic { get; set; }
    }
}
