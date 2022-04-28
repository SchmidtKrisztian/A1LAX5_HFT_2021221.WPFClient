// <copyright file="MainRepository.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Abstract MainRepository class.
    /// </summary>
    /// <typeparam name="T">Generic parameter, class type.</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="ctx">BdContext parameter.</param>
        protected Repository(LaptopShopContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Gets or sets DbContext property.
        /// </summary>
        protected LaptopShopContext ctx;

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Method, youn can delete instances to the context.
        /// </summary>
        /// <param name="id">The id of the instance we want to delete.</param>
        public void Delete(int id)
        {
            this.ctx.Set<T>().Remove(this.GetOne(id));
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Function, you can get a set of the instances in the context.
        /// </summary>
        /// <returns>A set of instances.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Function, you can get the instance which belong to the parameter ID.
        /// </summary>
        /// <param name="id">We want the instance of this ID.</param>
        /// <returns>The instance with the parameter ID.</returns>
        public abstract T GetOne(int id);

        public abstract void Update(T item);
    }
}
