// <copyright file="Laptop.cs" company="PlaceholderCompany">
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
    [Table("Laptops")]
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

        public Laptop()
        {
            Specifications = new HashSet<Specification>();
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
        [Required]
        public int BrandId { get; set; }

        /// <summary>
        /// Gets or sets the Name of a instance laptop.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the release Year of a instance laptop.
        /// </summary>
        [Required]
        public int ReleaseYear { get; set; }

        /// <summary>
        /// Gets or sets the base price of a instance laptop.
        /// </summary>
        [Required]
        public int BasePrice { get; set; }

        /// <summary>
        /// Gets or Sets the brand of the laptop, not mapped poroperty.
        /// </summary>
        [NotMapped]
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// Gets or sets the specifications of the laptop, not mapped poroperty.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Specification> Specifications { get; set; }

        /// <summary>
        /// Overriding the ToString() method.
        /// </summary>
        /// <returns>Formed string.</returns>
        public override string ToString()
        {
            return "NAME: " + this.Name + "RELEASE YEAR: " + this.ReleaseYear + "BASE PRICE: " + this.BasePrice;
        }
    }
}
