// <copyright file="Repository.cs" company="PlaceholderCompany">
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
    /// Abstract Repository class.
    /// </summary>
    /// <typeparam name="T">Generic parameter, class type.</typeparam>
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// DbContext field.
        /// </summary>
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="ctx">BdContext parameter.</param>
        protected Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Method, you can add instances to the context.
        /// </summary>
        /// <param name="newInstance">The instance we want to add.</param>
        public void Add(T newInstance)
        {
            this.ctx.Set<T>().Add(newInstance);
            this.ctx.SaveChanges();
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
        public T GetOne(int id)
        {
            return this.ctx.Find(typeof(T), id) as T;
        }
    }
}
