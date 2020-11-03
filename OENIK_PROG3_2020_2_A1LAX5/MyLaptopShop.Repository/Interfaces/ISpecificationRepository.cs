// <copyright file="ISpecificationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Repository.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyLaptopShop.Data.Models;

    /// <summary>
    /// This is the interface of the SpecificationRepository.
    /// </summary>
    public interface ISpecificationRepository : IRepository<Specification>
    {
        /// <summary>
        /// Method signature, you can change the name of a specification with it.
        /// </summary>
        /// <param name="id">Int, the specification with this ID, will have his name changed.</param>
        /// <param name="newname">String, the new name of a specification.</param>
        void ChangeName(int id, string newname);

        /// <summary>
        /// Method signature, you can change the CPU of a specification with it.
        /// </summary>
        /// <param name="id">Int, thespecification with this ID, will have his CPU changed.</param>
        /// <param name="newcpu">String, the new CPU of a specification.</param>
        void ChangeCPU(int id, string newcpu);

        /// <summary>
        /// Method signature, you can change the graphicscard of a specification with it.
        /// </summary>
        /// <param name="id">Int, the specification with this ID, will have his graphicscard changed.</param>
        /// <param name="newgraphicscard">String, the new graphicscard of a specification.</param>
        void ChangeGraphicsCard(int id, string newgraphicscard);

        /// <summary>
        /// Method signature, you can change the RAM of a specification with it.
        /// </summary>
        /// <param name="id">Int, the specification with this ID, will have his RAM changed.</param>
        /// <param name="newram">String, the new RAM of a specification.</param>
        void ChangeRAM(int id, int newram);

        /// <summary>
        /// Method signature, you can change the newadditionalprice of a specification with it.
        /// </summary>
        /// <param name="id">Int, the specification with this ID, will have his newadditionalprice changed.</param>
        /// <param name="newadditionalprice">String, the new newadditionalprice of a specification.</param>
        void ChangeAdditionalPrice(int id, int newadditionalprice);
    }
}
