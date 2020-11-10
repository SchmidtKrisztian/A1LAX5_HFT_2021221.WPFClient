// <copyright file="ILaptopLogic.cs" company="PlaceholderCompany">
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
    public interface ILaptopLogic<T>
        where T : class
    {
        /// <summary>
        /// Add a new brand to the DB.
        /// </summary>
        /// <param name="name">Name of the brand.</param>
        /// <param name="foundationyear">Year of foundation.</param>
        /// <param name="headquarters">Headquarters place.</param>
        /// <param name="ceoname">Name of the companys CEO.</param>
        void AddBrand(string name, int foundationyear, string headquarters, string ceoname);

        /// <summary>
        /// Add a new laptop to the DB.
        /// </summary>
        /// <param name="brandid">ID of the laptops brand.</param>
        /// <param name="name">Name of the laptop.</param>
        /// <param name="releaseyear">The year when the laptop was released.</param>
        /// <param name="baseprice">Base price.</param>
        void AddLaptop(int brandid, string name, int releaseyear, int baseprice);

        /// <summary>
        /// Add a new specification to the DB.
        /// </summary>
        /// <param name="laptopid">The id of the laptop witch has the specification.</param>
        /// <param name="name">Name of the specification.</param>
        /// <param name="cpu">Name of the cpu.</param>
        /// <param name="graphicscard">Nem of the Graphicscard.</param>
        /// <param name="ram">Gb of RAM.</param>
        void AddSpec(int laptopid, string name, string cpu, string graphicscard, int ram);

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
        /// <param name="name">New name of the brand.</param>
        /// <param name="foundationyear">New year of foundation of the brand.</param>
        /// <param name="headquarters">New headquarters of the brand.</param>
        /// <param name="ceoname">New name of the brands CEO.</param>
        void BrandUpdate(string name, int foundationyear, string headquarters, string ceoname);

        /// <summary>
        /// Updating a laptops parameters.
        /// </summary>
        /// <param name="brandid">The ID of the laptops brand.</param>
        /// <param name="name">The new name of the laptop.</param>
        /// <param name="releaseyear">The new year of the laptops release.</param>
        /// <param name="baseprice">The new price of the laptop.</param>
        void LaptopUpdate(int brandid, string name, int releaseyear, int baseprice);

        /// <summary>
        /// Updating a specification parameters.
        /// </summary>
        /// <param name="laptopid">Id of the specifications laptop.</param>
        /// <param name="name">New name of the specification.</param>
        /// <param name="cpu">New CPUs name.</param>
        /// <param name="graphicscard">New nameof the graphicscard.</param>
        /// <param name="ram">New Gb of RAMs.</param>
        void SpecUpdate(int laptopid, string name, string cpu, string graphicscard, int ram);

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
        /// Lists the name, brand name and the total price of the laptop with a chosen specification.
        /// </summary>
        /// <returns>List of Pricing type.</returns>
        IList<T> Pricing();
    }
}
