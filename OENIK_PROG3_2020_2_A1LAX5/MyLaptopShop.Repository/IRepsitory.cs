// <copyright file="IRepsitory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public interface IRepsitory<T>
         where T : class
     {
        T GetOne(int id);

        IQueryable<T> GetAll();
     }
}
