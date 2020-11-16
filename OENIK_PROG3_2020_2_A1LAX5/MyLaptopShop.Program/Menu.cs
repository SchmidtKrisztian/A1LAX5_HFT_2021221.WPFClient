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
        private AdministratorLogic adminlogic;
        private UserLogic userlogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
        /// <param name="userlogic">UserLogic istance.</param>
        public Menu(AdministratorLogic adminlogic, UserLogic userlogic)
        {
            this.adminlogic = adminlogic;
            this.userlogic = userlogic;
        }

       /// <summary>
       /// The maithod that runs the menu.
       /// </summary>
        public void MainMenu()
        {
            var menu = new ConsoleMenu()
                .Add(" >> List all BRANDs", () => ListAllBrands(this.userlogic))
                .Add(" >> List all LAPTOPs", () => ListAllLaptops(this.userlogic))
                .Add(" >> List all SPECIFICATIONs", () => ListAllSpecs(this.userlogic))
                .Add(" >> Add new BRAND", () => AddBrands(this.adminlogic))
                .Add(" >> Add new LAPTOP", () => AddLaptops(this.adminlogic))
                .Add(" >> Add new SPECIFICATION", () => AddSpecs(this.adminlogic))
                .Add(" >> Delete a BRAND", () => DeleteBrand(this.adminlogic))
                .Add(" >> Delete a LAPTOP", () => DeleteLaptop(this.adminlogic))
                .Add(" >> Delete a SPECIFICATION", () => DeleteSpec(this.adminlogic))
                .Add(" >> Update a BRAND", () => UpdateBrand(this.adminlogic))
                .Add(">> Update a LAPTOP", () => UpdateLaptop(this.adminlogic))
                .Add(">> Update a SPECIFICATION", () => UpdateSpec(this.adminlogic))
                .Add(">> List a BRAND, by ID", () => ListBrand(this.userlogic))
                .Add(">> List a LAPTOP, by ID", () => ListLaptop(this.userlogic))
                .Add(">> List a SPECIFICATION, by ID", () => ListSpec(this.userlogic))
                .Add(">> List countries with their laptop count", () => CountLaptop(this.userlogic))
                .Add(">> List laptops with their average specification cost", () => AvgSpec(this.userlogic))
                .Add(">> List the brands names who has Gamer specifications", () => GamerBrand(this.userlogic));
            menu.Show();
        }

        /// <summary>
        /// Lists all brands.
        /// </summary>
        /// <param name="userlogic">UserLogic instance.</param>
        private static void ListAllBrands(UserLogic userlogic)
        {
            Console.WriteLine("<< ALL BRANDS >>");
            userlogic.GetAllBrand()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadKey();
        }

        /// <summary>
        /// Lists all laptops.
        /// </summary>
        /// <param name="userlogic">UserLogic instance.</param>
        private static void ListAllLaptops(UserLogic userlogic)
        {
            Console.WriteLine("<< ALL LAPTOPS >>");
            userlogic.GetAllLaptop()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadKey();
        }

        /// <summary>
        /// Lists all specifications.
        /// </summary>
        /// <param name="userlogic">UserLogic instance.</param>
        private static void ListAllSpecs(UserLogic userlogic)
        {
            Console.WriteLine("<< ALL SPECIFICATIONS >>");
            userlogic.GetAllSpec()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for the new brands parameters and adds it to the DB.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
        private static void AddBrands(AdministratorLogic adminlogic)
        {
            var msg1 = new { msg = "Enter the new brands name" };
            Console.WriteLine(msg1.msg);
            string name = Console.ReadLine();
            var msg2 = new { msg = "Enter the new foundation year" };
            Console.WriteLine(msg2.msg);
            int fyear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg3 = new { msg = "Enter the new headquarters" };
            Console.WriteLine(msg3.msg);
            string head = Console.ReadLine();
            var msg4 = new { msg = "Enter the new CEO name" };
            Console.WriteLine(msg4.msg);
            string ceo = Console.ReadLine();
            adminlogic.AddBrand(name, fyear, head, ceo);
        }

        /// <summary>
        /// Asks for the new laptops parameters and adds it to the DB.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
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

        /// <summary>
        /// Asks for the new specifications parameters and adds it to the DB.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
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

        /// <summary>
        /// Asks for a brands ID you want to delet from the DB and Delets it.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
        private static void DeleteBrand(AdministratorLogic adminlogic)
        {
            var msg = new { msg = "Enter the brands ID, you want to delete." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.DeleteBrand(id);
        }

        /// <summary>
        /// Asks for a laptops ID you want to delet from the DB and Delets it.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
        private static void DeleteLaptop(AdministratorLogic adminlogic)
        {
            var msg = new { msg = "Enter the laptop ID, you want to delete." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.DeleteLaptop(id);
        }

        /// <summary>
        /// Asks for a specifications ID you want to delet from the DB and Delets it.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
        private static void DeleteSpec(AdministratorLogic adminlogic)
        {
            var msg = new { msg = "Enter the specification ID, you want to delete." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            adminlogic.DeleteSpec(id);
        }

        /// <summary>
        /// Asks for the id of the brand you want to update, than asks for the new parameters, than upedates is.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
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

        /// <summary>
        /// Asks for the id of the laptops you want to update, than asks for the new parameters, than upedates is.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
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

        /// <summary>
        /// Asks for the id of the specifications you want to update, than asks for the new parameters, than upedates is.
        /// </summary>
        /// <param name="adminlogic">AdministratorLogic instance.</param>
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

        /// <summary>
        /// Asks for an ID of the brand you want to see, and lists it.
        /// </summary>
        /// <param name="userlogic">UserLogic instance.</param>
        private static void ListBrand(UserLogic userlogic)
        {
            var msg = new { msg = "Enter the ID of a brand, you want to find." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = userlogic.BrandGetOne(id) };
            Console.WriteLine(msg2.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for an ID of the laptop you want to see, and lists it.
        /// </summary>
        /// <param name="userlogic">UserLogic instance.</param>
        private static void ListLaptop(UserLogic userlogic)
        {
            var msg = new { msg = "Enter the ID of a laptop, you want to find." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = userlogic.LaptopGetOne(id) };
            Console.WriteLine(msg2.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for an ID of the specification you want to see, and lists it.
        /// </summary>
        /// <param name="userlogic">UserLogic instance.</param>
        private static void ListSpec(UserLogic userlogic)
        {
            var msg = new { msg = "Enter the ID of a specification, you want to find." };
            Console.WriteLine(msg.msg);
            int id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            var msg2 = new { msg = userlogic.SpecGetOne(id) };
            Console.WriteLine(msg2.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Lists countries and their laptop counts.
        /// </summary>
        /// <param name="userlogic">Userlogic instance.</param>
        private static void CountLaptop(UserLogic userlogic)
        {
            var msg = new { msg = "<<Countries and their laptop counts>>" };
            Console.WriteLine(msg.msg);
            foreach (var item in userlogic.LaptopCount())
            {
                var msg2 = new { msg = item };
                Console.WriteLine(msg2.msg);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lists laptops and their average specification price.
        /// </summary>
        /// <param name="userlogic">Userlogic instance.</param>
        private static void AvgSpec(UserLogic userlogic)
        {
            var msg = new { msg = "<<Laptops and their average specification price>>" };
            Console.WriteLine(msg.msg);
            IList<string> list = userlogic.AvgSpecPrice();
            foreach (var item in list)
            {
                var msg2 = new { msg = item.ToString() };
                Console.WriteLine(msg2.msg);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Lists the brands names who has Gamer specifications.
        /// </summary>
        /// <param name="userlogic">Userlogic instance.</param>
        private static void GamerBrand(UserLogic userlogic)
        {
            var msg = new { msg = "<<Brands names who has Gamer specifications>>" };
            Console.WriteLine(msg.msg);
            foreach (var item in userlogic.GamerBrand())
            {
                var msg2 = new { msg = item };
                Console.WriteLine(msg2.msg);
            }

            Console.ReadKey();
        }
    }
}
