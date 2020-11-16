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
                    join laptop in this.laptoprepo.GetAll() on spec.LaptopId equals laptop.Id
                    let item = new { LaptopId = laptop.Id, Name = spec.Name }
                    where item.Name.Equals("Gamer", StringComparison.Ordinal)
                    select new
                    {
                        item.LaptopId,
                    };
            var q2 = from laptop in this.laptoprepo.GetAll()
                     join x in q on laptop.Id equals x.LaptopId
                     let item = new { BrandId = laptop.BrandId, LaptopId = x.LaptopId }
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
            /*var q5 = from x in this.specrepo.GetAll()
                    join y in this.laptoprepo.GetAll() on x.LaptopId equals y.Id
                    join z in this.brandrepo.GetAll() on y.BrandId equals z.Id
                    where x.Name.Equals("Gamer", StringComparison.Ordinal)
                    select z.Name;*/
            foreach (var item in q3)
            {
                string tmp = item.ToString();
                list.Add(tmp);
            }

            return list;
        }
    }
}
