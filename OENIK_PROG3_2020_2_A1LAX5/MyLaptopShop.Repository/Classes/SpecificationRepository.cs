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
        /// Method signature, you can change the newadditionalprice of a specification with it.
        /// </summary>
        /// <param name="id">Int, the specification with this ID, will have his newadditionalprice changed.</param>
        /// <param name="newadditionalprice">String, the new newadditionalprice of a specification.</param>
        public void ChangeAdditionalPrice(int id, int newadditionalprice)
        {
            var spec = this.GetOne(id);
            spec.AdditionalPrice = newadditionalprice;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method, you can change the CPU of a specification with it.
        /// </summary>
        /// <param name="id">Int, thespecification with this ID, will have his CPU changed.</param>
        /// <param name="newcpu">String, the new CPU of a specification.</param>
        public void ChangeCPU(int id, string newcpu)
        {
            var spec = this.GetOne(id);
            spec.CPU = newcpu;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method, you can change the graphicscard of a specification with it.
        /// </summary>
        /// <param name="id">Int, the specification with this ID, will have his graphicscard changed.</param>
        /// <param name="newgraphicscard">String, the new graphicscard of a specification.</param>
        public void ChangeGraphicsCard(int id, string newgraphicscard)
        {
            var spec = this.GetOne(id);
            spec.GraphicsCardName = newgraphicscard;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method, you can change the name of a specification with it.
        /// </summary>
        /// <param name="id">Int, the specification with this ID, will have his name changed.</param>
        /// <param name="newname">String, the new name of a specification.</param>
        public void ChangeName(int id, string newname)
        {
            var spec = this.GetOne(id);
            spec.Name = newname;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Method signature, you can change the RAM of a specification with it.
        /// </summary>
        /// <param name="id">Int, the specification with this ID, will have his RAM changed.</param>
        /// <param name="newram">String, the new RAM of a specification.</param>
        public void ChangeRAM(int id, int newram)
        {
            var spec = this.GetOne(id);
            spec.RAM = newram;
            this.ctx.SaveChanges();
        }
    }
}
