// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using ConsoleTools;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Logic.Classes;
    using MyLaptopShop.Repository.Classes;

    /// <summary>
    /// This is the main class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main()
        {
        LaptopShopContext ctx = new LaptopShopContext();
        BrandRepository brandrepo = new BrandRepository(ctx);
        LaptopRepository laptoprepo = new LaptopRepository(ctx);
        SpecificationRepository specrepo = new SpecificationRepository(ctx);
        LaptopLogic laptoplogic = new LaptopLogic(brandrepo,laptoprepo,specrepo);

        ConsoleMenu menu = new ConsoleMenu()
                .Add(">> List all BRANDs", () => ListAllBrands(laptoplogic))
                .Add(">> List all LAPTOPs", () => ListAllLaptops(laptoplogic))
                .Add(">> List all SPECIFICATIONs", () => ListAllSpecs(laptoplogic))
                .Add(">> Add new BRAND", () => AddBrands(laptoplogic))
                .Add(">> Add new LAPTOP", () => AddLaptops(laptoplogic))
                .Add(">> Add new SPECIFICATION", () => AddSpecs(laptoplogic))
                .Add(">> Delete a BRAND", () => DeleteBrand(laptoplogic))
                .Add(">> Delete a LAPTOP", () => DeleteLaptop(laptoplogic))
                .Add(">> Delete a SPECIFICATION", () => DeleteSpec(laptoplogic))
                .Add(">> Update a BRAND", () => UpdateBrand(laptoplogic))
                .Add(">> Update a LAPTOP", () => UpdateLaptop(laptoplogic))
                .Add(">> Update a SPECIFICATION", () => UpdateSpec(laptoplogic))
                .Add(">> List a BRAND, by ID", () => ListBrand(laptoplogic))
                .Add(">> List a LAPTOP, by ID", () => ListLaptop(laptoplogic))
                .Add(">> List a SPECIFICATION, by ID", () => ListSpec(laptoplogic))
                .Add(">> List countries with their laptop count", () => CountLaptop(laptoplogic))
                .Add(">> List laptops with their average specification cost", () => AvgSpec(laptoplogic))
                .Add(">> List Brand name, laptop name and average highest specification cost", () => HghLaptop(laptoplogic));

        }

        private static void ListAllBrands(LaptopLogic laptoplogic)
            {
                Console.WriteLine("<< ALL BRANDS >>");
                laptoplogic.GetAllBrand()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.ToString()));
            }

        private static void ListAllLaptops(LaptopLogic laptoplogic)
            {
                Console.WriteLine("<< ALL LAPTOPS >>");
                laptoplogic.GetAllLaptop()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.ToString()));
            }

        private static void ListAllSpecs(LaptopLogic laptoplogic)
            {
                Console.WriteLine("<< ALL SPECIFICATIONS >>");
                laptoplogic.GetAllSpec()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.ToString()));
            }

        private static void AddBrands(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the new brands ID");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the new brands name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the new foundation year");
                int fyear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the new headquarters");
                string head = Console.ReadLine();
                Console.WriteLine("Enter the new CEO name");
                string ceo = Console.ReadLine();
                laptoplogic.AddBrand(id, name, fyear, head, ceo);
            }

        private static void AddLaptops(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the new laptops ID");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the new laptops brand ID");
                int bid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the new laptops name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the new release year");
                int ryear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the new price");
                int price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.AddLaptop(id, bid, name, ryear, price);
            }

            private static void AddSpecs(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the new specifications ID");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the new specifications laptop ID");
                int lid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the new specifications name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the CPU name");
                string cpu = Console.ReadLine();
                Console.WriteLine("Enter the new graphicscard name");
                string vga = Console.ReadLine();
                Console.WriteLine("Enter the RAM in Gb");
                int ram = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the specification price");
                int price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.AddSpec(id, lid, name, cpu, vga, ram, price);
            }

        private static void DeleteBrand(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the brands ID, you want to delete.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.DeleteBrand(id);
            }

        private static void DeleteLaptop(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the laptop ID, you want to delete.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.DeleteLaptop(id);
            }

        private static void DeleteSpec(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the specification ID, you want to delete.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.DeleteSpec(id);
            }

        private static void UpdateBrand(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the brands ID, you want to update");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the brands new name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the foundation new  year");
                int fyear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the new headquarters");
                string head = Console.ReadLine();
                Console.WriteLine("Enter the new CEO name");
                string ceo = Console.ReadLine();
                laptoplogic.BrandUpdate(id, name, fyear, head, ceo);
            }

        private static void UpdateLaptop(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the laptops ID, you want to update");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the laptops  new  brand ID");
                int bid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the laptops new name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the new release year");
                int ryear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the new price");
                int price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.LaptopUpdate(id, bid, name, ryear, price);
            }

        private static void UpdateSpec(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the specifications ID, you want to update");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the specifications new  laptop ID");
                int lid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the specifications new  name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the CPU new name");
                string cpu = Console.ReadLine();
                Console.WriteLine("Enter the new graphicscard name");
                string vga = Console.ReadLine();
                Console.WriteLine("Enter the RAM in Gb");
                int ram = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                Console.WriteLine("Enter the specification price");
                int price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.SpecUpdate(id, lid, name, cpu, vga, ram, price);
            }

        private static void ListBrand(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the ID of a brand, you want to find.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.BrandGetOne(id);
            }

        private static void ListLaptop(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the ID of a laptop, you want to find.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.LaptopGetOne(id);
            }

        private static void ListSpec(LaptopLogic laptoplogic)
            {
                Console.WriteLine("Enter the ID of a specification, you want to find.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.SpecGetOne(id);
            }

        private static void CountLaptop(LaptopLogic laptoplogic)
            {
                Console.WriteLine("TODO");
            }

        private static void AvgSpec(LaptopLogic laptoplogic)
            {
                Console.WriteLine("TODO");
            }

        private static void HghLaptop(LaptopLogic laptoplogic)
            {
                Console.WriteLine("TODO");
            }
      
    }
}
