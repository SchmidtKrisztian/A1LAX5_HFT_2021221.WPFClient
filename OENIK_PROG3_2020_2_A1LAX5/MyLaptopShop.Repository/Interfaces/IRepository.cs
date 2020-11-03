// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This is the base interface of the Resopitory layer.
    /// </summary>
    /// <typeparam name="T">Generic type, T is a class.</typeparam>
    public interface IRepository<T>
         where T : class
     {
        /// <summary>
        /// Method that can add a new instance to the datebase.
        /// </summary>
        /// <param name="newInstance">A Laptop instance.</param>
        void Add(T newInstance);

        /// <summary>
        /// A method that can delete from the database.
        /// </summary>
        /// <param name="id">The ID of the instance we want to delete.</param>
        void Delete(int id);

        /// <summary>
        /// Method signature.
        /// </summary>
        /// <param name="id">Wants an int id.</param>
        /// <returns>Retruns an object that has the parameter id.</returns>
        T GetOne(int id);

        /// <summary>
        /// Method signature.
        /// </summary>
        /// <returns>All the objects.</returns>
        IQueryable<T> GetAll();
     }
}
