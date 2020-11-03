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
        /// Method signature, you can change the Name of a brand with it.
        /// </summary>
        /// <param name="id">Int, the brand with this ID, will have his name changed.</param>
        /// <param name="newname">String, the new name of a Brand.</param>
        void ChangeName(int id, string newname);

        /// <summary>
        /// Method signature, you can change the brands year of foundation.
        /// </summary>
        /// <param name="id">Int, the brand with this ID, will have his foundation year changed.</param>
        /// <param name="newyear">Int, this will me the new foundation year.</param>
        void ChangeFoundationYear(int id, int newyear);

        /// <summary>
        /// Method signature, you can change the brands headquarters place.
        /// </summary>
        /// <param name="id">Int, the brand headquarters with this id, will be changed.</param>
        /// <param name="newheadquarters">String, this wis the new Headquarters.</param>
        void ChangeHeadguarters(int id, string newheadquarters);

        /// <summary>
        /// Method signature, you can change the brands CEOs name.
        /// </summary>
        /// <param name="id">Int, the brand with this ID, will have his CEOs name changed.</param>
        /// <param name="newceoname">String, the new CEO Name.</param>
        void ChangeCEOName(int id, string newceoname);
    }
}
