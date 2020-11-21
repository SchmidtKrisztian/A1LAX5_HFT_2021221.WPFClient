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
        /// Method signature, you can change the name of a laptop with it.
        /// </summary>
        /// <param name="id">Int, the laptop with this ID, will have his name changed.</param>
        /// <param name="newname">String, the new name of a laptop.</param>
        void ChangeName(int id, string newname);

        /// <summary>
        /// Method signature, you can change the relese year of a laptop with it.
        /// </summary>
        /// <param name="id">Int, the laptop with this ID, will have his release year changed.</param>
        /// <param name="newreleaseyear">Int, the new release year of a Brand.</param>
        void ChangeReleaseYear(int id, int newreleaseyear);

        /// <summary>
        /// Method signature, you can change the base price of a laptop with it.
        /// </summary>
        /// <param name="id">Int, the laptop with this ID, will have his base price changed.</param>
        /// <param name="newbaseprice">Int, the new base price of a laptop.</param>
        void ChangeBasePrice(int id, int newbaseprice);
    }
}
