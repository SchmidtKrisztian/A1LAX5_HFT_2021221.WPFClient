﻿// <copyright file="Laptop.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// This the Model class of the Brands.
    /// </summary>
    [Table("Laptop")]
    public class Laptop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Laptop"/> class.
        /// </summary>
        /// <param name="id">ID of the laptop.</param>
        /// <param name="brandId">ID of the laptops brand.</param>
        /// <param name="name">Name of the laptop.</param>
        /// <param name="releaseYear">The release year of the laptop.</param>
        /// <param name="basePrice">The base price of the laptop.</param>
        public Laptop(int id, int brandId, string name, int releaseYear, int basePrice)
        {
            this.Id = id;
            this.BrandId = brandId;
            this.Name = name;
            this.ReleaseYear = releaseYear;
            this.BasePrice = basePrice;
        }

        /// <summary>
        /// Gets or sets the ID of a instance laptop, its a key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the laptos brand, it's a foreignkey.
        /// </summary>
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        /// <summary>
        /// Gets or sets the Name of a instance laptop.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the release Year of a instance laptop.
        /// </summary>
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Gets or sets the base price of a instance laptop.
        /// </summary>
        public int BasePrice { get; set; }
    }
}
