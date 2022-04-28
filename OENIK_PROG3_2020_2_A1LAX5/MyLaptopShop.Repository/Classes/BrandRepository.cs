// <copyright file="BrandRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Repository.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Repository;

    /// <summary>
    /// This is the Brands reposotory class.
    /// </summary>
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context.</param>
        public BrandRepository(LaptopShopContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Add a new brand to the DB.
        /// </summary>
        /// <param name="name">Name of the new brand.</param>
        /// <param name="foundationyear">Foundation year of the new brand.</param>
        /// <param name="headquarters">Headquarters of the new brand.</param>
        /// <param name="ceoname">The CEOs name of the new brand.</param>
        public void Add(string name, int foundationyear, string headquarters, string ceoname)
        {
            Brand tmp = new Brand
            {
                Name = name,
                FoundationYear = foundationyear,
                Headquarters = headquarters,
                CEOName = ceoname,
            };
            this.ctx.Add(tmp);
            this.ctx.SaveChanges();
        }

        public override Brand GetOne(int id)
        {
            return ctx.Brands.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Updating a brands parameters.
        /// </summary>
        /// <param name="id">Id of the brand.</param>
        /// <param name="name">New name of the brand.</param>
        /// <param name="foundationyear">New year of foundation of the brand.</param>
        /// <param name="headquarters">New headquarters of the brand.</param>
        /// <param name="ceoname">New name of the brands CEO.</param>
        public override void Update(Brand item)
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
