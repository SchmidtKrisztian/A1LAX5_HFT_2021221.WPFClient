// <copyright file="LaptopLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Logic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Logic.Interfaces;
    using MyLaptopShop.Repository.Interfaces;

    /// <summary>
    /// Logic class.
    /// </summary>
    public class LaptopLogic : ILaptopLogic<Pricing>
    {
        private IBrandRepository brandrepo;
        private ILaptopRepository laptoprepo;
        private ISpecificationRepository specrepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="LaptopLogic"/> class.
        /// </summary>
        /// <param name="brandrepo">Brand repository instance.</param>
        /// <param name="laptoprepo">Laptop repository instance.</param>
        /// <param name="specrepo">Specification repository instance.</param>
        public LaptopLogic(IBrandRepository brandrepo, ILaptopRepository laptoprepo, ISpecificationRepository specrepo)
        {
            this.brandrepo = brandrepo;
            this.laptoprepo = laptoprepo;
            this.specrepo = specrepo;
        }

        /// <summary>
        /// Add a new brand to the DB.
        /// </summary>
        /// <param name="name">Name of the brand.</param>
        /// <param name="foundationyear">Year of foundation.</param>
        /// <param name="headquarters">Headquarters place.</param>
        /// <param name="ceoname">Name of the companys CEO.</param>
        public void AddBrand(string name, int foundationyear, string headquarters, string ceoname)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a new laptop to the DB.
        /// </summary>
        /// <param name="brandid">ID of the laptops brand.</param>
        /// <param name="name">Name of the laptop.</param>
        /// <param name="releaseyear">The year when the laptop was released.</param>
        /// <param name="baseprice">Base price.</param>
        public void AddLaptop(int brandid, string name, int releaseyear, int baseprice)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a new specification to the DB.
        /// </summary>
        /// <param name="laptopid">The id of the laptop witch has the specification.</param>
        /// <param name="name">Name of the specification.</param>
        /// <param name="cpu">Name of the cpu.</param>
        /// <param name="graphicscard">Nem of the Graphicscard.</param>
        /// <param name="ram">Gb of RAM.</param>
        public void AddSpec(int laptopid, string name, string cpu, string graphicscard, int ram)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deleting the brand with the given ID.
        /// </summary>
        /// <param name="id">ID of the brand we want to delete.</param>
        public void DeleteBrand(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deleting the laptop with the given ID.
        /// </summary>
        /// <param name="id">ID of the laptop we want to delete.</param>
        public void DeleteLaptop(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deleting the laptop with the given ID.
        /// </summary>
        /// <param name="id">ID of the laptop we want to delete.</param>
        public void DeleteSpec(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back the istance witch belongs to the parameter ID.
        /// </summary>
        /// <param name="id">ID of the parameter we want to get.</param>
        /// <returns>The instance with the parameter ID.</returns>
        public Brand BrandGetOne(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back the istance witch belongs to the parameter ID.
        /// </summary>
        /// <param name="id">ID of the parameter we want to get.</param>
        /// <returns>The instance with the parameter ID.</returns>
        public Laptop LaptopGetOne(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back the istance witch belongs to the parameter ID.
        /// </summary>
        /// <param name="id">ID of the parameter we want to get.</param>
        /// <returns>The instance with the parameter ID.</returns>
        public Specification SpecGetOne(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updating a brands parameters.
        /// </summary>
        /// <param name="name">New name of the brand.</param>
        /// <param name="foundationyear">New year of foundation of the brand.</param>
        /// <param name="headquarters">New headquarters of the brand.</param>
        /// <param name="ceoname">New name of the brands CEO.</param>
        public void BrandUpdate(string name, int foundationyear, string headquarters, string ceoname)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updating a laptops parameters.
        /// </summary>
        /// <param name="brandid">The ID of the laptops brand.</param>
        /// <param name="name">The new name of the laptop.</param>
        /// <param name="releaseyear">The new year of the laptops release.</param>
        /// <param name="baseprice">The new price of the laptop.</param>
        public void LaptopUpdate(int brandid, string name, int releaseyear, int baseprice)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updating a specification parameters.
        /// </summary>
        /// <param name="laptopid">Id of the specifications laptop.</param>
        /// <param name="name">New name of the specification.</param>
        /// <param name="cpu">New CPUs name.</param>
        /// <param name="graphicscard">New nameof the graphicscard.</param>
        /// <param name="ram">New Gb of RAMs.</param>
        public void SpecUpdate(int laptopid, string name, string cpu, string graphicscard, int ram)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back all the brands.
        /// </summary>
        /// <returns>List of all brands.</returns>
        public IList<Brand> GetAllBrand()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back all the laptops.
        /// </summary>
        /// <returns>List of all laptops.</returns>
        public IList<Laptop> GetAllLaptop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gives back all the specifications.
        /// </summary>
        /// <returns>List of all specifications.</returns>
        public IList<Specification> GetAllSpec()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists the name, brand name and the total price of the laptop with a chosen specification.
        /// </summary>
        /// <returns>List of Pricing type.</returns>
        public IList<Pricing> Pricing()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List the number of laptops group by brands.
        /// </summary>
        /// <returns>List of strings.</returns>
        public IList<string> LaptopCount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists laptops with average specification prices.
        /// </summary>
        /// <returns>List of fromed strings of the results.</returns>
        public IList<string> AvgSpecPrice()
        {
            throw new NotImplementedException();
        }
    }
}
