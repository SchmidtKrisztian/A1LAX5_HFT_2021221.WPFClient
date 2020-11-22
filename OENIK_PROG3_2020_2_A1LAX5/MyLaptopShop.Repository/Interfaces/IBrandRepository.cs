// <copyright file="IBrandRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLaptopShop.Data.Models;

    /// <summary>
    /// This is the interface of the BrandRepository.
    /// </summary>
    public interface IBrandRepository : IRepository<Brand>
    {
        /// <summary>
        /// Add a new brand to the DB.
        /// </summary>
        /// <param name="name">Name of the new brand.</param>
        /// <param name="foundationyear">Foundation year of the new brand.</param>
        /// <param name="headquarters">Headquarters of the new brand.</param>
        /// <param name="ceoname">The CEOs name of the new brand.</param>
        void Add(string name, int foundationyear, string headquarters, string ceoname);

        /// <summary>
        /// Updating a brands parameters.
        /// </summary>
        /// <param name="id">Id of the brand.</param>
        /// <param name="name">New name of the brand.</param>
        /// <param name="foundationyear">New year of foundation of the brand.</param>
        /// <param name="headquarters">New headquarters of the brand.</param>
        /// <param name="ceoname">New name of the brands CEO.</param>
        void Update(int id, string name, int foundationyear, string headquarters, string ceoname);
    }
}
