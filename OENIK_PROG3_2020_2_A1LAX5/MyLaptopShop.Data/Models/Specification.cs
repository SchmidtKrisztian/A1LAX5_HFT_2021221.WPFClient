// <copyright file="Specification.cs" company="PlaceholderCompany">
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
    /// This is the Model class of the specifications.
    /// </summary>
    [Table("Specifications")]
    public class Specification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Specification"/> class.
        /// </summary>
        /// <param name="id">ID of the specification.</param>
        /// <param name="laptopId">ID of the laptop which has the instance specification.</param>
        /// <param name="name">Name of the specification.</param>
        /// <param name="cpu">The name of the CPU, that the specification includes.</param>
        /// <param name="graphicsCardName">The name of the graphicscard, that the specification includes.</param>
        /// <param name="ramcapacity">This is how many Gigabyte RAM, the specification has.</param>
        /// <param name="price">This is the additional price of the specification.</param>
        public Specification(int id, int laptopId, string name, string cpu, string graphicsCardName, int ramcapacity, int price)
        {
            this.Id = id;
            this.LaptopId = laptopId;
            this.Name = name;
            this.CPU = cpu;
            this.GraphicsCardName = graphicsCardName;
            this.RAMCapacity = ramcapacity;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the ID of the specification, it is a key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the laptops ID, which has the instance specification, it is a forignkey.
        /// </summary>
        [ForeignKey(nameof(Laptop))]
        public int LaptopId { get; set; }

        /// <summary>
        /// Gets or sets the name of the specification.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the CPU.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string CPU { get; set; }

        /// <summary>
        /// Gets or sets the name of the graphicscard.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string GraphicsCardName { get; set; }

        /// <summary>
        /// Gets or sets the multiplicity GigaByte of RAM.
        /// </summary>
        [Required]
        public int RAMCapacity { get; set; }

        /// <summary>
        /// Gets or sets the additonac price of the specification.
        /// </summary>
        [Required]
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the laptop of the specification, not mapped poroperty.
        /// </summary>
        [NotMapped]
        public virtual Laptop Laptop { get; set; }
    }
}
