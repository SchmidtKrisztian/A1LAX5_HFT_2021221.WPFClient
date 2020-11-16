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
            this.ctx = ctx;
        }

        /// <summary>
        /// Method, you can change the brands CEOs name.
        /// </summary>
        /// <param name="id">Int, the brand with this ID, will have his CEOs name changed.</param>
        /// <param name="newceoname">String, the new CEO Name.</param>
        public void ChangeCEOName(int id, string newceoname)
        {
            var brand = this.GetOne(id);
            brand.CEOName = newceoname;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method, you can change the brands year of foundation.
        /// </summary>
        /// <param name="id">Int, the brand with this ID, will have his foundation year changed.</param>
        /// <param name="newyear">Int, this will me the new foundation year.</param>
        public void ChangeFoundationYear(int id, int newyear)
        {
            var brand = this.GetOne(id);
            brand.FoundationYear = newyear;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method, you can change the brands headquarters place.
        /// </summary>
        /// <param name="id">Int, the brand headquarters with this id, will be changed.</param>
        /// <param name="newheadquarters">String, this wis the new Headquarters.</param>
        public void ChangeHeadguarters(int id, string newheadquarters)
        {
            var brand = this.GetOne(id);
            brand.Headquarters = newheadquarters;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method, you can change the Name of a brand with it.
        /// </summary>
        /// <param name="id">Int, the brand with this ID, will have his name changed.</param>
        /// <param name="newname">String, the new name of a Brand.</param>
        public void ChangeName(int id, string newname)
        {
            var brand = this.GetOne(id);
            brand.Name = newname;
            this.ctx.SaveChanges();
        }
    }
}
