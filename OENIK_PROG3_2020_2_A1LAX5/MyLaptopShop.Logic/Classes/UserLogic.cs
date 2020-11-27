// <copyright file="UserLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Logic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
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
        /// List the number of laptops group by countries.
        /// </summary>
        /// <returns>List of strings.</returns>
        public IList<string> LaptopCount()
        {
            List<string> list = new List<string>();
            var q = from x in this.laptoprepo.GetAll()
                    group x by x.BrandId into g
                    select new
                    {
                        BRAND_ID = g.Key,
                        COUNT = g.Count(),
                    };
            var q2 = from x in this.brandrepo.GetAll()
                     join y in q on x.Id equals y.BRAND_ID
                     let item = new { x.Headquarters, y.COUNT }
                     group item by item.Headquarters into grp
                     select new
                     {
                         Place = grp.Key,
                         Count = grp.Sum(x => x.COUNT),
                     };
            foreach (var item in q2)
            {
                string tmp = "COUNTRY: " + item.Place + "\t LAPTOPS COUNT: " + item.Count;
                list.Add(tmp);
            }

            return list;
        }

        /// <summary>
        /// Lists laptops with average specification prices.
        /// </summary>
        /// <returns>List of fromed strings of the results.</returns>
        public IList<string> AvgSpecPrice()
        {
            List<string> list = new List<string>();
            var q = from x in this.specrepo.GetAll()
                    group x by x.LaptopId into g
                    select new
                    {
                        LaptopId = g.Key,
                        Avg = g.Average(a => a.AdditionalPrice),
                    };
            var q2 = from x in this.laptoprepo.GetAll()
                     join y in q on x.Id equals y.LaptopId
                     let item = new { x.Id, x.Name, y.Avg }
                     group item by item.Name into grp
                     select new
                     {
                         Name = grp.Key,
                         Avg = grp.Average(x => x.Avg),
                     };
            foreach (var item in q2)
            {
                string tmp = "LAPTOP: " + item.Name + "\t\t AVERAGE PRICE: " + item.Avg;
                list.Add(tmp);
            }

            return list;
        }

        /// <summary>
        /// List Brands with the highest specification price.
        /// </summary>
        /// <returns>List of formed string of the result.</returns>
        public IList<string> GamerBrand()
        {
            List<string> list = new List<string>();
            var q = from spec in this.specrepo.GetAll()
                    where spec.Name.ToUpper() == "GAMER"
                    select spec;

            var q2 = from laptop in this.laptoprepo.GetAll()
                     join spec in q on laptop.Id equals spec.LaptopId
                     let item = new { BrandId = laptop.BrandId, LaptopId = spec.LaptopId }
                     select new
                     {
                         BrandID = item.BrandId,
                     };
            var q3 = from brand in this.brandrepo.GetAll()
                     join y in q2 on brand.Id equals y.BrandID
                     let item = new { BrandName = brand.Name, BrandId = y.BrandID }
                     select new
                     {
                        item.BrandName,
                     };
            foreach (var item in q3)
            {
                string tmp = item.BrandName;
                list.Add(tmp);
            }

            return list;
        }

       /// <summary>
       /// Async method to LaptopCount().
       /// </summary>
       /// <returns>async Task.</returns>
        public Task<IList<string>> LaptopCountAsync()
        {
            return Task.Run(() => this.LaptopCount());
        }

        /// <summary>
        /// Async method to AvgSpecPrice().
        /// </summary>
        /// <returns>async Task.</returns>
        public Task<IList<string>> AvgSpecPriceAsync()
        {
            return Task.Run(() => this.AvgSpecPrice());
        }

        /// <summary>
        /// Async method to GamerBrand().
        /// </summary>
        /// <returns>async Task.</returns>
        public Task<IList<string>> GamerBrandAsync()
        {
            return Task.Run(() => this.GamerBrand());
        }
    }
}