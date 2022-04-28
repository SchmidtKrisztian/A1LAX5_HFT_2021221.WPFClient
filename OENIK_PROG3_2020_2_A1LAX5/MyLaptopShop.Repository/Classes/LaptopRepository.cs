// <copyright file="LaptopRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Repository.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Repository;

    /// <summary>
    /// This is the Laptop repository class.
    /// </summary>
    public class LaptopRepository : Repository<Laptop>, IRepository<Laptop>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaptopRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext from the original class.</param>
        public LaptopRepository(LaptopShopContext ctx)
           : base(ctx)
        {
        }

        public override Laptop GetOne(int id)
        {
            return ctx.Laptops.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Updating a laptops parameters.
        /// </summary>
        /// <param name="id">Id of the laptop.</param>
        /// <param name="name">The new name of the laptop.</param>
        /// <param name="releaseyear">The new year of the laptops release.</param>
        /// <param name="baseprice">The new price of the laptop.</param>
        public override void Update(Laptop item)
        {
            var old = GetOne(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
