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
        AdministratorLogic adminlogic = new AdministratorLogic(brandrepo, laptoprepo, specrepo);
        UserLogic userlogic = new UserLogic(brandrepo, laptoprepo, specrepo);

        ConsoleMenu menu = new ConsoleMenu()
                .Add(">> List all BRANDs", () => ListAllBrands(userlogic))
                .Add(">> List all LAPTOPs", () => ListAllLaptops(userlogic))
                .Add(">> List all SPECIFICATIONs", () => ListAllSpecs(userlogic))
                .Add(">> Add new BRAND", () => AddBrands(adminlogic))
                .Add(">> Add new LAPTOP", () => AddLaptops(adminlogic))
                .Add(">> Add new SPECIFICATION", () => AddSpecs(adminlogic))
                .Add(">> Delete a BRAND", () => DeleteBrand(adminlogic))
                .Add(">> Delete a LAPTOP", () => DeleteLaptop(adminlogic))
                .Add(">> Delete a SPECIFICATION", () => DeleteSpec(adminlogic))
                .Add(">> Update a BRAND", () => UpdateBrand(adminlogic))
                .Add(">> Update a LAPTOP", () => UpdateLaptop(adminlogic))
                .Add(">> Update a SPECIFICATION", () => UpdateSpec(adminlogic))
                .Add(">> List a BRAND, by ID", () => ListBrand(userlogic))
                .Add(">> List a LAPTOP, by ID", () => ListLaptop(userlogic))
                .Add(">> List a SPECIFICATION, by ID", () => ListSpec(userlogic))
                .Add(">> List countries with their laptop count", () => CountLaptop(userlogic))
                .Add(">> List laptops with their average specification cost", () => AvgSpec(userlogic))
                .Add(">> List Brand name, laptop name and average highest specification cost", () => HghLaptop(userlogic));

        menu.Show();
        }

        private static void ListAllBrands(UserLogic userlogic)
            {
                Console.WriteLine("<< ALL BRANDS >>");
                userlogic.GetAllBrand()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.ToString()));
                Console.ReadLine();
            }

        private static void ListAllLaptops(UserLogic userlogic)
            {
                Console.WriteLine("<< ALL LAPTOPS >>");
                userlogic.GetAllLaptop()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.ToString()));
            }

        private static void ListAllSpecs(UserLogic userlogic)
            {
                Console.WriteLine("<< ALL SPECIFICATIONS >>");
                userlogic.GetAllSpec()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.ToString()));
            }

        private static void AddBrands(AdministratorLogic laptoplogic)
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

        private static void AddLaptops(AdministratorLogic laptoplogic)
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

        private static void AddSpecs(AdministratorLogic laptoplogic)
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

        private static void DeleteBrand(AdministratorLogic laptoplogic)
            {
                Console.WriteLine("Enter the brands ID, you want to delete.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.DeleteBrand(id);
            }

        private static void DeleteLaptop(AdministratorLogic laptoplogic)
            {
                Console.WriteLine("Enter the laptop ID, you want to delete.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.DeleteLaptop(id);
            }

        private static void DeleteSpec(AdministratorLogic laptoplogic)
            {
                Console.WriteLine("Enter the specification ID, you want to delete.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                laptoplogic.DeleteSpec(id);
            }

        private static void UpdateBrand(AdministratorLogic laptoplogic)
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

        private static void UpdateLaptop(AdministratorLogic laptoplogic)
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

        private static void UpdateSpec(AdministratorLogic laptoplogic)
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

        private static void ListBrand(UserLogic userlogic)
            {
                Console.WriteLine("Enter the ID of a brand, you want to find.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                userlogic.BrandGetOne(id);
            }

        private static void ListLaptop(UserLogic userlogic)
            {
                Console.WriteLine("Enter the ID of a laptop, you want to find.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                userlogic.LaptopGetOne(id);
            }

        private static void ListSpec(UserLogic userlogic)
            {
                Console.WriteLine("Enter the ID of a specification, you want to find.");
                int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                userlogic.SpecGetOne(id);
            }

        private static void CountLaptop(UserLogic userlogic)
            {
                Console.WriteLine("TODO");
            }

        private static void AvgSpec(UserLogic userlogic)
            {
                Console.WriteLine("TODO");
            }

        private static void HghLaptop(UserLogic userlogic)
            {
                Console.WriteLine("TODO");
            }
    }
}
