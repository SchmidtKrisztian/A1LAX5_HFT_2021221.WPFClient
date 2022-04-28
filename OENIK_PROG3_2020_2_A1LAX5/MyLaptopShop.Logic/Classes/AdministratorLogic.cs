// <copyright file="AdministratorLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Logic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Logic.Interfaces;
    using MyLaptopShop.Repository.Classes;
    using MyLaptopShop.Repository;

    /// <summary>
    /// AdministratorLogic class, has all the create delete or update methods.
    /// </summary>
    public class AdministratorLogic : IAdministratorLogic
    {
        private IRepository<Brand> brandrepo;
        private IRepository<Laptop> laptoprepo;
        private IRepository<Specification> specrepo;

        public AdministratorLogic(IRepository<Brand> brandrepo, IRepository<Laptop> laptoprepo, IRepository<Specification> specrepo)
        {
            this.brandrepo = brandrepo;
            this.laptoprepo = laptoprepo;
            this.specrepo = specrepo;
        }

        /// <summary>
        /// Add a new brand to the DB.
        /// </summary>
        /// <param name="name">Name of the new brand.</param>
        /// <param name="foundationyear">Foundation year of the new brand.</param>
        /// <param name="headquarters">Headquarters of the new brand.</param>
        /// <param name="ceoname">The CEOs name of the new brand.</param>
        public void AddBrand(Brand item)
        {
            this.brandrepo.Create(item);
        }

        /// <summary>
        /// Add a new laptop to the DB.
        /// </summary>
        /// <param name="brandid">ID of the laptops brand.</param>
        /// <param name="name">Name of the laptop.</param>
        /// <param name="releaseyear">The year when the laptop was released.</param>
        /// <param name="baseprice">Base price.</param>
        public void AddLaptop(Laptop item)
        {
            this.laptoprepo.Create(item);
        }

        /// <summary>
        /// Add a new specification to the DB.
        /// </summary>
        /// <param name="laptopid">The id of the laptop witch has the specification.</param>
        /// <param name="name">Name of the specification.</param>
        /// <param name="cpu">Name of the cpu.</param>
        /// <param name="graphicscard">Nem of the Graphicscard.</param>
        /// <param name="ram">Gb of RAM.</param>
        /// <param name="price">Additional price of the specification.</param>
        public void AddSpec(Specification item)
        {
            this.specrepo.Create(item);
        }

        /// <summary>
        /// Deleting the brand with the given ID.
        /// </summary>
        /// <param name="id">ID of the brand we want to delete.</param>
        public void DeleteBrand(int id)
        {
            this.brandrepo.Delete(id);
        }

        /// <summary>
        /// Deleting the laptop with the given ID.
        /// </summary>
        /// <param name="id">ID of the laptop we want to delete.</param>
        public void DeleteLaptop(int id)
        {
            this.laptoprepo.Delete(id);
        }

        /// <summary>
        /// Deleting the laptop with the given ID.
        /// </summary>
        /// <param name="id">ID of the laptop we want to delete.</param>
        public void DeleteSpec(int id)
        {
            this.specrepo.Delete(id);
        }

        /// <summary>
        /// Updating a brands parameters.
        /// </summary>
        /// <param name="id">Id of the brand.</param>
        /// <param name="name">New name of the brand.</param>
        /// <param name="foundationyear">New year of foundation of the brand.</param>
        /// <param name="headquarters">New headquarters of the brand.</param>
        /// <param name="ceoname">New name of the brands CEO.</param>
        public void BrandUpdate(Brand item)
        {
            this.brandrepo.Update(item);
        }

        /// <summary>
        /// Updating a laptops parameters.
        /// </summary>
        /// <param name="id">Id of the laptop.</param>
        /// <param name="name">The new name of the laptop.</param>
        /// <param name="releaseyear">The new year of the laptops release.</param>
        /// <param name="baseprice">The new price of the laptop.</param>
        public void LaptopUpdate(Laptop item)
        {
            this.laptoprepo.Update(item);
        }

        /// <summary>
        /// Updating a specification parameters.
        /// </summary>
        /// <param name="id">Id of the specification.</param>
        /// <param name="name">New name of the specification.</param>
        /// <param name="cpu">New CPUs name.</param>
        /// <param name="graphicscard">New nameof the graphicscard.</param>
        /// <param name="ram">New Gb of RAMs.</param>
        /// <param name="price">Additional price of the specification.</param>
        public void SpecUpdate(Specification item)
        {
            this.specrepo.Update(item);
        }
    }
}
