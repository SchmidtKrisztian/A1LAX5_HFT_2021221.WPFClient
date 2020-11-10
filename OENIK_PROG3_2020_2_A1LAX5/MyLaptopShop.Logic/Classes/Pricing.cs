// <copyright file="Pricing.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Logic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLaptopShop.Logic.Interfaces;

    /// <summary>
    /// Class that saves the pricing datas.
    /// </summary>
    public class Pricing : IPricing
    {
        /// <summary>
        /// Gets or sets the brand name.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the full price.
        /// </summary>
        public int Fullprice { get; set; }

        /// <summary>
        /// Gets or sets the laptops name.
        /// </summary>
        public string Laptopname { get; set; }

        /// <summary>
        /// Gets or sets the specifications name.
        /// </summary>
        public string Specname { get; set; }

        /// <summary>
        /// Overriding the the ToString method.
        /// </summary>
        /// <returns>Retrunes formed string.</returns>
        public override string ToString()
        {
            return "BRAND: " + this.Brand + "LAPTOPNAME: " + this.Laptopname + "SPECIFICATION NAME: " + this.Specname + "FULL PRICE: " + this.Fullprice;
        }
    }
}
