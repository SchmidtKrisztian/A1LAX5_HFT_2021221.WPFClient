// <copyright file="LaptopShopContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is The Context class of the database.
    /// </summary>
    public class LaptopShopContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaptopShopContext"/> class.
        /// </summary>
        public LaptopShopContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LaptopShopContext"/> class.
        /// </summary>
        /// <param name="options">options.</param>
        public LaptopShopContext(DbContextOptions<LaptopShopContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Brands table.
        /// </summary>
        public virtual DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Gets or sets the Laptops table.
        /// </summary>
        public virtual DbSet<Laptop> Laptops { get; set; }

        /// <summary>
        /// Gets or sets the Specifications table.
        /// </summary>
        public virtual DbSet<Specification> Specifications { get; set; }

        /// <summary>
        /// Overrideing the original OnConfiguring method.
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionBuilder instance.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }
            else
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder
                        .UseLazyLoadingProxies()
                        .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyLaptopShopDatabase.mdf;Integrated Security=True");
                }
            }
        }

        /// <summary>
        /// Overriding the original OnModelCreating method. Creating instances and setting connections between the tables.
        /// </summary>
        /// <param name="modelBuilder">Modelbuilder instance.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Brand brand1 = new Brand() { Id = 1, Name = "Samsung", FoundationYear = 1990, Headquarters = "Place1", CEOName = "name" };
            Brand brand2 = new Brand() { Id = 2, Name = "Dell", FoundationYear = 1990, Headquarters = "Place2", CEOName = "name" };
            Brand brand3 = new Brand() { Id = 3, Name = "Acer", FoundationYear = 1990, Headquarters = "Place3", CEOName = "name" };
            Brand brand4 = new Brand() { Id = 4, Name = "Asus", FoundationYear = 1990, Headquarters = "Place4", CEOName = "name" };
            Brand brand5 = new Brand() { Id = 5, Name = "Apple", FoundationYear = 1990, Headquarters = "Place5", CEOName = "name" };
            Brand brand6 = new Brand() { Id = 6, Name = "Lenovo", FoundationYear = 1990, Headquarters = "Place6", CEOName = "name" };
            Brand brand7 = new Brand() { Id = 7, Name = "HP", FoundationYear = 1990, Headquarters = "Place7", CEOName = "name" };

            Laptop laptop1 = new Laptop() { Id = 1, BrandId = 6, Name = "YogaBook", ReleaseYear = 2010, BasePrice = 500 };
            Laptop laptop2 = new Laptop() { Id = 2, BrandId = 2, Name = "AlienWare 700", ReleaseYear = 2014, BasePrice = 5000 };
            Laptop laptop3 = new Laptop() { Id = 3, BrandId = 4, Name = "ROG-G51", ReleaseYear = 2015, BasePrice = 1000 };
            Laptop laptop4 = new Laptop() { Id = 4, BrandId = 5, Name = "Mac Book G11", ReleaseYear = 2019, BasePrice = 6000 };
            Laptop laptop5 = new Laptop() { Id = 5, BrandId = 3, Name = "Predator Helios 500", ReleaseYear = 2016, BasePrice = 2000 };
            Laptop laptop6 = new Laptop() { Id = 6, BrandId = 6, Name = "Legion 400", ReleaseYear = 2012, BasePrice = 1500 };
            Laptop laptop7 = new Laptop() { Id = 7, BrandId = 6, Name = "IdeaPad 2300", ReleaseYear = 2008, BasePrice = 700 };

            Specification spec1 = new Specification() { Id = 1, LaptopId = 1, Name = "Gamer", CPU = "i7-6460", GraphicsCardName = "GTX2060Ti", RAM = 32, AdditionalPrice = 20 };
            Specification spec2 = new Specification() { Id = 2, LaptopId = 4, Name = "Work", CPU = "i3-8450", GraphicsCardName = "GTX1050Ti", RAM = 8, AdditionalPrice = 50 };
            Specification spec3 = new Specification() { Id = 3, LaptopId = 6, Name = "Consumer", CPU = "i5-4460", GraphicsCardName = "GTX1050Ti", RAM = 8, AdditionalPrice = 30 };
            Specification spec4 = new Specification() { Id = 4, LaptopId = 3, Name = "EverydayUse", CPU = "i5-10020", GraphicsCardName = "Radeon R7", RAM = 8, AdditionalPrice = 200 };
            Specification spec5 = new Specification() { Id = 5, LaptopId = 2, Name = "Editor", CPU = "i9-9990K", GraphicsCardName = "Radeon R)", RAM = 32, AdditionalPrice = 400 };
            Specification spec6 = new Specification() { Id = 6, LaptopId = 5, Name = "Gamer", CPU = "Ryzen 4450", GraphicsCardName = "Radeon R7", RAM = 16, AdditionalPrice = 150 };
            Specification spec7 = new Specification() { Id = 7, LaptopId = 6, Name = "Consumer", CPU = "i5-6720", GraphicsCardName = "none", RAM = 4, AdditionalPrice = 10 };
            Specification spec8 = new Specification() { Id = 8, LaptopId = 7, Name = "Work", CPU = "i5-9050M", GraphicsCardName = "GT750", RAM = 8, AdditionalPrice = 100 };
            Specification spec9 = new Specification() { Id = 9, LaptopId = 2, Name = "Gamer", CPU = "i5-4460", GraphicsCardName = "GTX1050Ti", RAM = 8, AdditionalPrice = 110 };
            Specification spec10 = new Specification() { Id = 10, LaptopId = 1, Name = "Server", CPU = "Xeon 10990", GraphicsCardName = "none", RAM = 64, AdditionalPrice = 400 };

            laptop1.BrandId = brand6.Id;
            laptop2.BrandId = brand2.Id;
            laptop3.BrandId = brand4.Id;
            laptop4.BrandId = brand5.Id;
            laptop5.BrandId = brand3.Id;
            laptop6.BrandId = brand6.Id;
            laptop7.BrandId = brand6.Id;

            spec1.LaptopId = laptop1.Id;
            spec2.LaptopId = laptop4.Id;
            spec3.LaptopId = laptop6.Id;
            spec4.LaptopId = laptop3.Id;
            spec5.LaptopId = laptop2.Id;
            spec6.LaptopId = laptop5.Id;
            spec7.LaptopId = laptop6.Id;
            spec8.LaptopId = laptop7.Id;
            spec9.LaptopId = laptop2.Id;
            spec10.LaptopId = laptop1.Id;

            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
            else
            {
                modelBuilder.Entity<Brand>(entity =>
                {
                    entity.HasMany(l => l.Laptops)
                    .WithOne(b => b.Brand)
                    .HasForeignKey(l => l.BrandId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

                modelBuilder.Entity<Specification>(entity =>
                {
                    entity.HasOne(l => l.Laptop)
                    .WithMany(s => s.Specifications)
                    .HasForeignKey(l => l.LaptopId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

                modelBuilder.Entity<Brand>().HasData(brand1, brand2, brand3, brand4, brand5, brand6);
                modelBuilder.Entity<Laptop>().HasData(laptop1, laptop2, laptop3, laptop4, laptop5, laptop6, laptop7);
                modelBuilder.Entity<Specification>().HasData(spec1, spec2, spec3, spec4, spec5, spec6, spec7, spec8, spec9, spec10);
            }
        }
    }
}
