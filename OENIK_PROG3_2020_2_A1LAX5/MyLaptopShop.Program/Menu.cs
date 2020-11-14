// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using ConsoleTools;
    using MyLaptopShop.Data.Models;
    using MyLaptopShop.Logic.Classes;
    using MyLaptopShop.Logic.Interfaces;

    /// <summary>
    /// This is the Menu class.
    /// </summary>
    public class Menu
    {
        private Factory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
            this.factory = new Factory();
        }

        /// <summary>
        /// Te main menu method.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
        /// <param name="userlogic">UserLogic instance.</param>
        public static void MainMenu(AdministratorLogic adminlogic, UserLogic userlogic)
        {
            var menu = new ConsoleMenu()
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
        }

        private static void ListAllBrands(UserLogic userlogic)
        {
            Console.WriteLine("<< ALL BRANDS >>");
            userlogic.GetAllBrand()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadKey();
        }

        private static void ListAllLaptops(UserLogic userlogic)
        {
            Console.WriteLine("<< ALL LAPTOPS >>");
            userlogic.GetAllLaptop()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadKey();
        }

        private static void ListAllSpecs(UserLogic userlogic)
        {
            Console.WriteLine("<< ALL SPECIFICATIONS >>");
            userlogic.GetAllSpec()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadKey();
        }

        private static void AddBrands(AdministratorLogic adminlogic)
        {
            var msg1 = new { msg = "Enter the new brands name" };
            Console.WriteLine(msg1.msg);
            string name = Console.ReadLine();
            var msg2 = new { msg = "Enter the new foundation year" };
            Console.WriteLine(msg1.msg);
            int fyear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg3 = new { msg = "Enter the new headquarters" };
            Console.WriteLine(msg1.msg);
            string head = Console.ReadLine();
            var msg4 = new { msg = "Enter the new CEO name" };
            Console.WriteLine(msg1.msg);
            string ceo = Console.ReadLine();
            adminlogic.AddBrand(name, fyear, head, ceo);
        }

        private static void AddLaptops(AdministratorLogic adminlogic)
        {
            var msg1 = new { msg = "Enter the new laptops brand ID" };
            Console.WriteLine(msg1.msg);
            int bid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = "Enter the new laptops name" };
            Console.WriteLine(msg2.msg);
            string name = Console.ReadLine();
            var msg3 = new { msg = "Enter the new release year" };
            Console.WriteLine(msg3.msg);
            int ryear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg4 = new { msg = "Enter the new price" };
            Console.WriteLine(msg4.msg);
            int price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.AddLaptop(bid, name, ryear, price);
        }

        private static void AddSpecs(AdministratorLogic adminlogic)
        {
            var msg1 = new { msg = "Enter the new specifications laptop ID" };
            Console.WriteLine(msg1.msg);
            int lid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = "Enter the new specifications name" };
            Console.WriteLine(msg2.msg);
            string name = Console.ReadLine();
            var msg3 = new { msg = "Enter the CPU name" };
            Console.WriteLine(msg3.msg);
            string cpu = Console.ReadLine();
            var msg4 = new { msg = "Enter the new graphicscard name" };
            Console.WriteLine(msg4.msg);
            string vga = Console.ReadLine();
            var msg5 = new { msg = "Enter the RAM in Gb" };
            Console.WriteLine(msg5.msg);
            int ram = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg6 = new { msg = "Enter the specification price" };
            Console.WriteLine(msg6.msg);
            int price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.AddSpec(lid, name, cpu, vga, ram, price);
        }

        private static void DeleteBrand(AdministratorLogic adminlogic)
        {
            var msg = new { msg = "Enter the brands ID, you want to delete." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.DeleteBrand(id);
        }

        private static void DeleteLaptop(AdministratorLogic adminlogic)
        {
            var msg = new { msg = "Enter the laptop ID, you want to delete." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.DeleteLaptop(id);
        }

        private static void DeleteSpec(AdministratorLogic adminlogic)
        {
            var msg = new { msg = "Enter the specification ID, you want to delete." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.DeleteSpec(id);
        }

        private static void UpdateBrand(AdministratorLogic adminlogic)
        {
            var msg = new { msg = "Enter the brands ID, you want to update" };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg1 = new { msg = "Enter the brands new name" };
            Console.WriteLine(msg1.msg);
            string name = Console.ReadLine();
            var msg2 = new { msg = "Enter the foundation new  year" };
            Console.WriteLine(msg2.msg);
            int fyear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg3 = new { msg = "Enter the new headquarters" };
            Console.WriteLine(msg3.msg);
            string head = Console.ReadLine();
            var msg4 = new { msg = "Enter the new CEO name" };
            Console.WriteLine(msg4.msg);
            string ceo = Console.ReadLine();
            adminlogic.BrandUpdate(id, name, fyear, head, ceo);
        }

        private static void UpdateLaptop(AdministratorLogic adminlogic)
        {
            var msg = new { msg = "Enter the laptops ID, you want to update" };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg1 = new { msg = "Enter the laptops  new  brand ID" };
            Console.WriteLine(msg1.msg);
            int bid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = "Enter the laptops new name" };
            Console.WriteLine(msg2.msg);
            string name = Console.ReadLine();
            var msg3 = new { msg = "Enter the new release year" };
            Console.WriteLine(msg3.msg);
            int ryear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg4 = new { msg = "Enter the new price" };
            Console.WriteLine(msg4.msg);
            int price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.LaptopUpdate(id, name, ryear, price);
        }

        private static void UpdateSpec(AdministratorLogic adminlogic)
        {
            var msg = new { msg = "Enter the specifications ID, you want to update" };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg1 = new { msg = "Enter the specifications new  laptop ID" };
            Console.WriteLine(msg1.msg);
            int lid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = "Enter the specifications new  name" };
            Console.WriteLine(msg2.msg);
            string name = Console.ReadLine();
            var msg3 = new { msg = "Enter the CPU new name" };
            Console.WriteLine(msg3.msg);
            string cpu = Console.ReadLine();
            var msg4 = new { msg = "Enter the new graphicscard name" };
            Console.WriteLine(msg4.msg);
            string vga = Console.ReadLine();
            var msg5 = new { msg = "Enter the RAM in Gb" };
            Console.WriteLine(msg5.msg);
            int ram = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg6 = new { msg = "Enter the specification price" };
            Console.WriteLine(msg6.msg);
            int price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.SpecUpdate(id, name, cpu, vga, ram, price);
        }

        private static void ListBrand(UserLogic userlogic)
        {
            var msg = new { msg = "Enter the ID of a brand, you want to find." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = userlogic.BrandGetOne(id) };
            Console.WriteLine(msg2.msg);
            Console.ReadKey();
        }

        private static void ListLaptop(UserLogic userlogic)
        {
            var msg = new { msg = "Enter the ID of a laptop, you want to find." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = userlogic.LaptopGetOne(id) };
            Console.WriteLine(msg2.msg);
            Console.ReadKey();
        }

        private static void ListSpec(UserLogic userlogic)
        {
            var msg = new { msg = "Enter the ID of a specification, you want to find." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = userlogic.SpecGetOne(id) };
            Console.WriteLine(msg2.msg);
            Console.ReadKey();
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
