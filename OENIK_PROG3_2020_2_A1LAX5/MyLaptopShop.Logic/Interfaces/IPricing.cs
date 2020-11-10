// <copyright file="IPricing.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Interface of the Pricing class.
    /// </summary>
    public interface IPricing
    {
        /// <summary>
        /// Gets or sets the brand name.
        /// </summary>
        string Brand { get; set; }

        /// <summary>
        /// Gets or sets the laptops name.
        /// </summary>
        string Laptopname { get; set; }

        /// <summary>
        /// Gets or sets the specification name.
        /// </summary>
        string Specname { get; set; }

        /// <summary>
        /// Gets or sets the full price.
        /// </summary>
        int Fullprice { get; set; }
    }
}
