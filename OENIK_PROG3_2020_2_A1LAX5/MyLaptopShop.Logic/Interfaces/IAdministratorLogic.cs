// <copyright file="IAdministratorLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Logic.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLaptopShop.Data.Models;

    /// <summary>
    /// This is the Laptoplogic interface.
    /// </summary>
    /// <typeparam name="T">Genreic parameter, class type.</typeparam>
    public interface IAdministratorLogic
    {
        /// <summary>
        /// Add a new brand to the DB.
        /// </summary>
        /// <param name="id">ID of the new brand.</param>
        /// <param name="name">Name of the brand.</param>
        /// <param name="foundationyear">Year of foundation.</param>
        /// <param name="headquarters">Headquarters place.</param>
        /// <param name="ceoname">Name of the companys CEO.</param>
        void AddBrand(int id, string name, int foundationyear, string headquarters, string ceoname);

        /// <summary>
        /// Add a new laptop to the DB.
        /// </summary>
        /// <param name="id">Id of the laptop.</param>
        /// <param name="brandid">ID of the laptops brand.</param>
        /// <param name="name">Name of the laptop.</param>
        /// <param name="releaseyear">The year when the laptop was released.</param>
        /// <param name="baseprice">Base price.</param>
        void AddLaptop(int id, int brandid, string name, int releaseyear, int baseprice);

        /// <summary>
        /// Add a new specification to the DB.
        /// </summary>
        /// <param name="id">Id of the specification.</param>
        /// <param name="laptopid">The id of the laptop witch has the specification.</param>
        /// <param name="name">Name of the specification.</param>
        /// <param name="cpu">Name of the cpu.</param>
        /// <param name="graphicscard">Nem of the Graphicscard.</param>
        /// <param name="ram">Gb of RAM.</param>
        /// <param name="price">Additional price of the specification.</param>
        void AddSpec(int id, int laptopid, string name, string cpu, string graphicscard, int ram, int price);

        /// <summary>
        /// Deleting the brand with the given ID.
        /// </summary>
        /// <param name="id">ID of the brand we want to delete.</param>
        void DeleteBrand(int id);

        /// <summary>
        /// Deleting the laptop with the given ID.
        /// </summary>
        /// <param name="id">ID of the laptop we want to delete.</param>
        void DeleteLaptop(int id);

        /// <summary>
        /// Deleting the laptop with the given ID.
        /// </summary>
        /// <param name="id">ID of the laptop we want to delete.</param>
        void DeleteSpec(int id);

        /// <summary>
        /// Updating a brands parameters.
        /// </summary>
        /// <param name="id">Id of the brand.</param>
        /// <param name="name">New name of the brand.</param>
        /// <param name="foundationyear">New year of foundation of the brand.</param>
        /// <param name="headquarters">New headquarters of the brand.</param>
        /// <param name="ceoname">New name of the brands CEO.</param>
        void BrandUpdate(int id, string name, int foundationyear, string headquarters, string ceoname);

        /// <summary>
        /// Updating a laptops parameters.
        /// </summary>
        /// <param name="id">Id of the laptop.</param>
        /// <param name="brandid">The ID of the laptops brand.</param>
        /// <param name="name">The new name of the laptop.</param>
        /// <param name="releaseyear">The new year of the laptops release.</param>
        /// <param name="baseprice">The new price of the laptop.</param>
        void LaptopUpdate(int id, int brandid, string name, int releaseyear, int baseprice);

        /// <summary>
        /// Updating a specification parameters.
        /// </summary>
        /// <param name="id">Id of the specification.</param>
        /// <param name="laptopid">Id of the specifications laptop.</param>
        /// <param name="name">New name of the specification.</param>
        /// <param name="cpu">New CPUs name.</param>
        /// <param name="graphicscard">New nameof the graphicscard.</param>
        /// <param name="ram">New Gb of RAMs.</param>
        /// <param name="price">Additional price of the specification.</param>
        void SpecUpdate(int id, int laptopid, string name, string cpu, string graphicscard, int ram, int price);
    }
}
