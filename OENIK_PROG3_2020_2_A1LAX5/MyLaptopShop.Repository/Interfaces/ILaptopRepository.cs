// <copyright file="ILaptopRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLaptopShop.Data.Models;

    /// <summary>
    /// This is the Interface of the LaptopRepository.
    /// </summary>
    public interface ILaptopRepository : IRepository<Laptop>
    {
        /// <summary>
        /// Add a new laptop to the DB.
        /// </summary>
        /// <param name="brandid">ID of the laptops brand.</param>
        /// <param name="name">Name of the laptop.</param>
        /// <param name="releaseyear">The year when the laptop was released.</param>
        /// <param name="baseprice">Base price.</param>
        void Add(int brandid, string name, int releaseyear, int baseprice);

        /// <summary>
        /// Updating a laptops parameters.
        /// </summary>
        /// <param name="id">Id of the laptop.</param>
        /// <param name="name">The new name of the laptop.</param>
        /// <param name="releaseyear">The new year of the laptops release.</param>
        /// <param name="baseprice">The new price of the laptop.</param>
        void Update(int id, string name, int releaseyear, int baseprice);
    }
}
