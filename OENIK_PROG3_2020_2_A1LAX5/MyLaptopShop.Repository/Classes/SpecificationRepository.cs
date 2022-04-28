// <copyright file="SpecificationRepository.cs" company="PlaceholderCompany">
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
    using MyLaptopShop.Repository;

    /// <summary>
    /// This is the repository class of the specifications.
    /// </summary>
    public class SpecificationRepository : Repository<Specification>, IRepository<Specification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificationRepository"/> class.
        /// </summary>
        /// <param name="ctx">Database context.</param>
        public SpecificationRepository(LaptopShopContext ctx)
          : base(ctx)
        {
        }

        public override Specification GetOne(int id)
        {
            return ctx.Specifications.FirstOrDefault(t => t.Id == id);
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
        public override void Update(Specification item)
        {
            var old = GetOne(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
