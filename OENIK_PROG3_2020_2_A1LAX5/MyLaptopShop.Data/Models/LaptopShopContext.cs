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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyLaptopShopDatabase.mdf;Integrated Security=True");
            }
        }

        /// <summary>
        /// Overriding the original OnModelCreating method. Creating instances and setting connections between the tables.
        /// </summary>
        /// <param name="modelBuilder">Modelbuilder instance.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Brand brand0 = new Brand(0, "Samsung", 1990, "place0", "name0");
            Brand brand1 = new Brand(1, "Dell", 1990, "place1", "name1");
            Brand brand2 = new Brand(2, "Acer", 1990, "place2", "name2");
            Brand brand3 = new Brand(3, "Asus", 1990, "place3", "name3");
            Brand brand4 = new Brand(4, "Apple", 1990, "place4", "name4");
            Brand brand5 = new Brand(5, "Lenovo", 1990, "place5", "name5");
            Brand brand6 = new Brand(6, "HP", 1990, "place6", "name6");

            Laptop laptop0 = new Laptop(0, 5, "YogaBook", 2010, 500);
            Laptop laptop1 = new Laptop(1, 1, "AlienWare 700", 2014, 5000);
            Laptop laptop2 = new Laptop(2, 3, "ROG-G51", 2015, 1000);
            Laptop laptop3 = new Laptop(3, 4, "Mac Book G11", 2019, 6000);
            Laptop laptop4 = new Laptop(4, 2, "Predator Helios 500", 2016, 2000);
            Laptop laptop5 = new Laptop(5, 5, "Legion 400", 2012, 1500);
            Laptop laptop6 = new Laptop(6, 5, "IdeaPad 2300", 2008, 700);

            Specification spec0 = new Specification(0, 1, "Gamer", "i7-6460", "GTX2060Ti", 32, 20);
            Specification spec1 = new Specification(1, 3, "Work", "i3-8450", "GTX1050Ti", 8, 50);
            Specification spec2 = new Specification(2, 5, "Consumer", "i5-4460", "GTX150Ti", 8, 30);
            Specification spec3 = new Specification(3, 2, "EverydayUse", "i5-10020", "Radeon R7", 8, 200);
            Specification spec4 = new Specification(4, 1, "Editor", "i9-9990K", "Radeon R9", 32, 400);
            Specification spec5 = new Specification(5, 4, "Gamer", "Ryzen 4450", "Radeon R7", 16, 150);
            Specification spec6 = new Specification(6, 6, "Consumer", "i5-6720", "none", 4, 10);
            Specification spec7 = new Specification(7, 2, "Work", "i5-9050M", "GT750", 8, 100);
            Specification spec8 = new Specification(8, 3, "Gamer", "5-4460", "GTX150Ti", 8, 110);
            Specification spec9 = new Specification(9, 5, "Server", "Xeon 10990", "none", 64, 400);

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
        }
    }
}
