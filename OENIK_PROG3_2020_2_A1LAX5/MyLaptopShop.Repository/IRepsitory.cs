// <copyright file="IRepsitory.cs" company="PlaceholderCompany">
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
    public interface IRepsitory<T>
         where T : class
     {
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
