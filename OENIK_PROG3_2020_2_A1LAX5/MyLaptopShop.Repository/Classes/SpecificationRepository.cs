// <copyright file="SpecificationRepository.cs" company="PlaceholderCompany">
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
    /// This is the repository class of the specifications.
    /// </summary>
    public class SpecificationRepository : MainRepository<Specification>, ISpecificationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificationRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context.</param>
        public SpecificationRepository(DbContext ctx)
            : base(ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Add a new specification to the DB.
        /// </summary>
        /// <param name="laptopid">The id of the laptop witch has the specification.</param>
        /// <param name="name">Name of the specification.</param>
        /// <param name="cpu">Name of the cpu.</param>
        /// <param name="graphicscard">Nem of the Graphicscard.</param>
        /// <param name="ram">Gb of RAM.</param>
        /// <param name="price">Additional price of the specification.</param>
        public void Add(int laptopid, string name, string cpu, string graphicscard, int ram, int price)
        {
            Specification tmp = new Specification
            {
                LaptopId = laptopid,
                Name = name,
                CPU = cpu,
                GraphicsCardName = graphicscard,
                RAM = ram,
                AdditionalPrice = price,
            };
            this.ctx.Add(tmp);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Updating a specification parameters.
        /// </summary>
        /// <param name="id">Id of the specification.</param>
        /// <param name="name">New name of the specification.</param>
        /// <param name="cpu">New CPUs name.</param>
        /// <param name="graphicscard">New nameof the graphicscard.</param>
        /// <param name="ram">New Gb of RAMs.</param>
        /// <param name="price">Additional price of the specification.</param>
        public void Update(int id, string name, string cpu, string graphicscard, int ram, int price)
        {
            var spec = this.GetOne(id);
            spec.AdditionalPrice = price;
            spec.CPU = cpu;
            spec.GraphicsCardName = graphicscard;
            spec.Name = name;
            spec.RAM = ram;
            this.ctx.SaveChanges();
        }
    }
}
