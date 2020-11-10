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
        /// Constructor of the brand name.
        /// </summary>
        /// <returns>Get,Set.</returns>
        string Brand();

        /// <summary>
        /// Constructor of the laptop name.
        /// </summary>
        /// <returns>Get,Set.</returns>
        string Laptopname();

        /// <summary>
        /// Constructor of the specification name.
        /// </summary>
        /// <returns>Get,Set.</returns>
        string Specname();

        /// <summary>
        /// Constructor of the fullprice.
        /// </summary>
        /// <returns>Gets,Sets.</returns>
        int Fullprice();
    }
}
