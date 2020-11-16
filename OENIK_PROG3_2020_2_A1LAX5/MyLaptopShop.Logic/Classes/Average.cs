// <copyright file="Average.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Logic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Average class.
    /// </summary>
    public class Average
    {
        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        public double Avg { get; set; }

        /// <summary>
        /// Overriding the base ToString method.
        /// </summary>
        /// <returns>Formed string og the properties.</returns>
        public override string ToString()
        {
            return $"{this.Name}: {this.Avg}";
        }

        /// <summary>
        /// Overriding the base Equals function.
        /// </summary>
        /// <param name="obj">An instance of a given class.</param>
        /// <returns>A boolean.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Overriding the base GetHasCode() function.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
