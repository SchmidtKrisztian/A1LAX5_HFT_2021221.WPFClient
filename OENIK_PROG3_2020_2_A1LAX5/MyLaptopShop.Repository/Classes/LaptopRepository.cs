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
            : base(ctx) => this.ctx = ctx;

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
            this.ctx.Add(tmp);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method, you can change the base price of a laptop with it.
        /// </summary>
        /// <param name="id">Int, the laptop with this ID, will have his base price changed.</param>
        /// <param name="newbaseprice">Int, the new base price of a laptop.</param>
        public void ChangeBasePrice(int id, int newbaseprice)
        {
            var laptop = this.GetOne(id);
            laptop.BasePrice = newbaseprice;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method, you can change the name of a laptop with it.
        /// </summary>
        /// <param name="id">Int, the laptop with this ID, will have his name changed.</param>
        /// <param name="newname">String, the new name of a laptop.</param>
        public void ChangeName(int id, string newname)
        {
            var laptop = this.GetOne(id);
            laptop.Name = newname;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method, you can change the relese year of a laptop with it.
        /// </summary>
        /// <param name="id">Int, the laptop with this ID, will have his release year changed.</param>
        /// <param name="newreleaseyear">Int, the new release year of a Brand.</param>
        public void ChangeReleaseYear(int id, int newreleaseyear)
        {
            var laptop = this.GetOne(id);
            laptop.ReleaseYear = newreleaseyear;
            this.ctx.SaveChanges();
        }
    }
}
