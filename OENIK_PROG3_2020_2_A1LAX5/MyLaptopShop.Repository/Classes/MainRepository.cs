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

    /// <summary>
    /// Abstract MainRepository class.
    /// </summary>
    /// <typeparam name="T">Generic parameter, class type.</typeparam>
    public abstract class MainRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainRepository{T}"/> class.
        /// </summary>
        /// <param name="ctx">BdContext parameter.</param>
        protected MainRepository(DbContext ctx)
        {
            this.Ctx = ctx;
        }

        /// <summary>
        /// Gets or sets DbContext property.
        /// </summary>
        protected DbContext Ctx { get; set; }

        /// <summary>
        /// Method, youn can delete instances to the context.
        /// </summary>
        /// <param name="id">The id of the instance we want to delete.</param>
        public void Delete(int id)
        {
            this.Ctx.Set<T>().Remove(this.GetOne(id));
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Function, you can get a set of the instances in the context.
        /// </summary>
        /// <returns>A set of instances.</returns>
        public IQueryable<T> GetAll()
        {
            return this.Ctx.Set<T>();
        }

        /// <summary>
        /// Function, you can get the instance which belong to the parameter ID.
        /// </summary>
        /// <param name="id">We want the instance of this ID.</param>
        /// <returns>The instance with the parameter ID.</returns>
        public T GetOne(int id)
        {
            return this.Ctx.Find(typeof(T), id) as T;
        }
    }
}
