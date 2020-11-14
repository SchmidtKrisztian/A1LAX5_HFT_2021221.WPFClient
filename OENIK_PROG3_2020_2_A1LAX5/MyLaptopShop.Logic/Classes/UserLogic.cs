// <copyright file="UserLogic.cs" company="PlaceholderCompany">
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
    using MyLaptopShop.Repository.Interfaces;

    /// <summary>
    /// Class that does the listing methods.
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private IBrandRepository brandrepo;
        private ILaptopRepository laptoprepo;
        private ISpecificationRepository specrepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogic"/> class.
        /// </summary>
        /// <param name="brandrepo">Brand repository instance.</param>
        /// <param name="laptoprepo">Laptop repository instance.</param>
        /// <param name="specrepo">Specification repository instance.</param>
        public UserLogic(IBrandRepository brandrepo, ILaptopRepository laptoprepo, ISpecificationRepository specrepo)
        {
            this.brandrepo = brandrepo;
            this.laptoprepo = laptoprepo;
            this.specrepo = specrepo;
        }

        /// <summary>
        /// Gives back the istance witch belongs to the parameter ID.
        /// </summary>
        /// <param name="id">ID of the parameter we want to get.</param>
        /// <returns>The instance with the parameter ID.</returns>
        public Brand BrandGetOne(int id)
        {
            return this.brandrepo.GetOne(id);
        }

        /// <summary>
        /// Gives back the istance witch belongs to the parameter ID.
        /// </summary>
        /// <param name="id">ID of the parameter we want to get.</param>
        /// <returns>The instance with the parameter ID.</returns>
        public Laptop LaptopGetOne(int id)
        {
            return this.laptoprepo.GetOne(id);
        }

        /// <summary>
        /// Gives back the istance witch belongs to the parameter ID.
        /// </summary>
        /// <param name="id">ID of the parameter we want to get.</param>
        /// <returns>The instance with the parameter ID.</returns>
        public Specification SpecGetOne(int id)
        {
            return this.specrepo.GetOne(id);
        }

        /// <summary>
        /// Gives back all the brands.
        /// </summary>
        /// <returns>List of all brands.</returns>
        public IList<Brand> GetAllBrand()
        {
            return this.brandrepo.GetAll().ToList();
        }

        /// <summary>
        /// Gives back all the laptops.
        /// </summary>
        /// <returns>List of all laptops.</returns>
        public IList<Laptop> GetAllLaptop()
        {
            return this.laptoprepo.GetAll().ToList();
        }

        /// <summary>
        /// Gives back all the specifications.
        /// </summary>
        /// <returns>List of all specifications.</returns>
        public IList<Specification> GetAllSpec()
        {
            return this.specrepo.GetAll().ToList();
        }

        /// <summary>
        /// List the number of laptops group by brands.
        /// </summary>
        /// <returns>List of strings.</returns>
        public IList<string> LaptopCount()
        {
            var q = from brand in this.brandrepo.GetAll()
                    join laptop in this.laptoprepo.GetAll() on brand.Id equals laptop.BrandId
                    let item = new { BrandName = brand.Name, LaptopName = laptop.Id }
                    group item by item.BrandName into brandres
                    select new
                    {
                        COUNTRY = brandres.Key,
                        Count = brandres.LaptopId.Count(),
                    };
            return q.ToList();
        }

        /// <summary>
        /// Lists laptops with average specification prices.
        /// </summary>
        /// <returns>List of fromed strings of the results.</returns>
        public IList<string> AvgSpecPrice()
        {
            var q = from laptop in this.laptoprepo.GetAll()
                    join spec in this.specrepo.GetAll() on laptop.Id equals spec.LaptopId
                    let avg = 
                    select new
                    {
                        LaptopName = item.LaptopName,
                        AveragePrice = item.Average(item => item.Price) ?? 0
                    };
            return q.ToList();
        }

        /// <summary>
        /// List Brands with the highest specification price.
        /// </summary>
        /// <returns>List of formed string of the result.</returns>
        public IList<string> HghSpecBrand()
        {
            var q = from brand in this.brandrepo.GetAll()
                    join laptop in this.laptoprepo.GetAll() on brand.Id equals laptop.BrandId
                    join spec in this.specrepo.GetAll() on laptop.Id equals spec.LaptopId
                    let item = new { BrandName = brand.Name, SpecPrice = spec.AdditionalPrice }
                    orderby item.SpecPrice
                    select new
                    {
                        BrandName= item.BrandName.Value,
                        SpecPrice =item.SpecPrice,
                    };
            return q.ToList();
        }
    }
}
