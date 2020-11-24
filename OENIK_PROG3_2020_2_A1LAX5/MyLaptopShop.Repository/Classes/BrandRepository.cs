// <copyright file="BrandRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Repository.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Repository.Interfaces;

    /// <summary>
    /// This is the Brands reposotory class.
    /// </summary>
    public class BrandRepository : MainRepository<Brand>, IBrandRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context.</param>
        public BrandRepository(DbContext ctx)
            : base(ctx)
        {
            this.Ctx = ctx;
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
            this.Ctx.Add(tmp);
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Updating a brands parameters.
        /// </summary>
        /// <param name="id">Id of the brand.</param>
        /// <param name="name">New name of the brand.</param>
        /// <param name="foundationyear">New year of foundation of the brand.</param>
        /// <param name="headquarters">New headquarters of the brand.</param>
        /// <param name="ceoname">New name of the brands CEO.</param>
        public void Update(int id, string name, int foundationyear, string headquarters, string ceoname)
        {
            var brand = this.GetOne(id);
            brand.Name = name;
            brand.Headquarters = headquarters;
            brand.FoundationYear = foundationyear;
            brand.CEOName = ceoname;
            this.Ctx.SaveChanges();
        }
    }
}
