// <copyright file="IUserLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLaptopShop.Data.Models;

    /// <summary>
    /// Interface of the UserLogic class.
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// Gives back the istance witch belongs to the parameter ID.
        /// </summary>
        /// <param name="id">ID of the parameter we want to get.</param>
        /// <returns>The instance with the parameter ID.</returns>
        Brand BrandGetOne(int id);

        /// <summary>
        /// Gives back the istance witch belongs to the parameter ID.
        /// </summary>
        /// <param name="id">ID of the parameter we want to get.</param>
        /// <returns>The instance with the parameter ID.</returns>
        Laptop LaptopGetOne(int id);

        /// <summary>
        /// Gives back the istance witch belongs to the parameter ID.
        /// </summary>
        /// <param name="id">ID of the parameter we want to get.</param>
        /// <returns>The instance with the parameter ID.</returns>
        Specification SpecGetOne(int id);

        /// <summary>
        /// Gives back all the brands.
        /// </summary>
        /// <returns>List of all brands.</returns>
        IList<Brand> GetAllBrand();

        /// <summary>
        /// Gives back all the laptops.
        /// </summary>
        /// <returns>List of all laptops.</returns>
        IList<Laptop> GetAllLaptop();

        /// <summary>
        /// Gives back all the specifications.
        /// </summary>
        /// <returns>List of all specifications.</returns>
        IList<Specification> GetAllSpec();

        /// <summary>
        /// List the number of laptops group by brands.
        /// </summary>
        /// <returns>List of strings.</returns>
        IList<string> LaptopCount();

        /// <summary>
        /// Lists laptops with average specification prices.
        /// </summary>
        /// <returns>List of fromed strings of the results.</returns>
        IList<string> AvgSpecPrice();

        /// <summary>
        /// List Brands with the highest specification price.
        /// </summary>
        /// <returns>List of formed string of the result.</returns>
        IList<string> HghSpecBrand();
    }
}
