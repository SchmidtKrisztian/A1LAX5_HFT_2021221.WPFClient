// <copyright file="LaptopRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Repository.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Repository.Interfaces;

    /// <summary>
    /// This is the Laptop repository class.
    /// </summary>
    public class LaptopRepository : MainRepository<Laptop>, ILaptopRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaptopRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext from the original class.</param>
        public LaptopRepository(DbContext ctx)
            : base(ctx) => this.Ctx = ctx;

        /// <summary>
        /// Add a new laptop to the DB.
        /// </summary>
        /// <param name="brandid">ID of the laptops brand.</param>
        /// <param name="name">Name of the laptop.</param>
        /// <param name="releaseyear">The year when the laptop was released.</param>
        /// <param name="baseprice">Base price.</param>
        public void Add(int brandid, string name, int releaseyear, int baseprice)
        {
            Laptop tmp = new Laptop
            {
                BrandId = brandid,
                Name = name,
                ReleaseYear = releaseyear,
                BasePrice = baseprice,
            };
            this.Ctx.Add(tmp);
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Updating a laptops parameters.
        /// </summary>
        /// <param name="id">Id of the laptop.</param>
        /// <param name="name">The new name of the laptop.</param>
        /// <param name="releaseyear">The new year of the laptops release.</param>
        /// <param name="baseprice">The new price of the laptop.</param>
        public void Update(int id, string name, int releaseyear, int baseprice)
        {
            var laptop = this.GetOne(id);
            laptop.Name = name;
            laptop.BasePrice = baseprice;
            laptop.ReleaseYear = releaseyear;
            this.Ctx.SaveChanges();
        }
    }
}
