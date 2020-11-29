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
    using System.Threading;
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
                .Add(" >> List all BRANDs", () => this.ListAllBrands())
                .Add(" >> List all LAPTOPs", () => this.ListAllLaptops())
                .Add(" >> List all SPECIFICATIONs", () => this.ListAllSpecs())
                .Add(" >> Add new BRAND", () => this.AddBrands())
                .Add(" >> Add new LAPTOP", () => this.AddLaptops())
                .Add(" >> Add new SPECIFICATION", () => this.AddSpecs())
                .Add(" >> Delete a BRAND", () => this.DeleteBrand())
                .Add(" >> Delete a LAPTOP", () => this.DeleteLaptop())
                .Add(" >> Delete a SPECIFICATION", () => this.DeleteSpec())
                .Add(" >> Update a BRAND", () => this.UpdateBrand())
                .Add(">> Update a LAPTOP", () => this.UpdateLaptop())
                .Add(">> Update a SPECIFICATION", () => this.UpdateSpec())
                .Add(">> List a BRAND, by ID", () => this.ListBrand())
                .Add(">> List a LAPTOP, by ID", () => this.ListLaptop())
                .Add(">> List a SPECIFICATION, by ID", () => this.ListSpec())
                .Add(">> List countries with their laptop count", () => this.CountLaptop())
                .Add(">> List laptops with their average specification cost", () => this.AvgSpec())
                .Add(">> List the brands names who has Gamer specifications", () => this.GamerBrand())
                .Add(">> List countries with their laptop count (ASYNC)", () => this.LaptopCountASYNC())
                .Add(">> List laptops with their average specification cost (ASYNC)", () => this.AvgSpecASYNC())
                .Add(">> List the brands names who has Gamer specifications (ASYNC)", () => this.GamerBrandASYNC())
                .Add(">> EXIT", ConsoleMenu.Close);
            menu.Show();
        }

        /// <summary>
        /// Lists all brands.
        /// </summary>
        private void ListAllBrands()
        {
            Console.WriteLine("<< ALL BRANDS >> \n");
            this.userlogic.GetAllBrand()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            var msg88 = new { msg = "\n Press [ENTER] to continue...." };
            Console.WriteLine(msg88.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Lists all laptops.
        /// </summary>
        private void ListAllLaptops()
        {
            Console.WriteLine("<< ALL LAPTOPS >> \n");
            this.userlogic.GetAllLaptop()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            var msg88 = new { msg = "\n Press [ENTER] to continue...." };
            Console.WriteLine(msg88.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Lists all specifications.
        /// </summary>
        private void ListAllSpecs()
        {
            Console.WriteLine("<< ALL SPECIFICATIONS >> \n");
            this.userlogic.GetAllSpec()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            var msg88 = new { msg = "\n Press [ENTER] to continue...." };
            Console.WriteLine(msg88.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for the new brands parameters and adds it to the DB.
        /// </summary>
        private void AddBrands()
        {
            var msg1 = new { msg = "Enter the new brands name" };
            Console.WriteLine(msg1.msg);
            string name = Console.ReadLine();
            var msg2 = new { msg = "Enter the new foundation year" };
            Console.WriteLine(msg2.msg);
            int fyear = 0;
            try
            {
                fyear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                fyear = -1;
            }

            while (fyear < 0 || fyear > 2021)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    fyear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    fyear = -1;
                }
            }

            var msg3 = new { msg = "Enter the new headquarters" };
            Console.WriteLine(msg3.msg);
            string head = Console.ReadLine();
            var msg4 = new { msg = "Enter the new CEO name" };
            Console.WriteLine(msg4.msg);
            string ceo = Console.ReadLine();
            this.adminlogic.AddBrand(name, fyear, head, ceo);
            Console.ForegroundColor = ConsoleColor.Green;
            var msg5 = new { msg = "Adding a BRAND was successfull! ^^" };
            Console.WriteLine(msg5.msg);
            Console.ResetColor();
            var msg6 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg6.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for the new laptops parameters and adds it to the DB.
        /// </summary>
        private void AddLaptops()
        {
            var msg1 = new { msg = "Enter the new laptops brand ID" };
            Console.WriteLine(msg1.msg);
            int bid = 0;
            try
            {
                bid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                bid = -1;
            }

            List<int> count = this.BCount();
            while (!count.Contains(bid))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [BRAND] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    bid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            var msg2 = new { msg = "Enter the new laptops name" };
            Console.WriteLine(msg2.msg);
            string name = Console.ReadLine();
            var msg3 = new { msg = "Enter the new release year" };
            Console.WriteLine(msg3.msg);
            int ryear = 0;
            try
            {
                ryear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                ryear = -1;
            }

            while (ryear < 0 || ryear > 2021)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    ryear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    ryear = -1;
                }
            }

            var msg4 = new { msg = "Enter the new price" };
            Console.WriteLine(msg4.msg);
            int price = 0;
            try
            {
                price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                price = -1;
            }

            while (price < 0)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    price = -1;
                }
            }

            this.adminlogic.AddLaptop(bid, name, ryear, price);
            Console.ForegroundColor = ConsoleColor.Green;
            var msg5 = new { msg = "Adding a LAPTOP was successfull! ^^" };
            Console.WriteLine(msg5.msg);
            Console.ResetColor();
            var msg6 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg6.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for the new specifications parameters and adds it to the DB.
        /// </summary>
        private void AddSpecs()
        {
            var msg1 = new { msg = "Enter the new specifications laptop ID" };
            Console.WriteLine(msg1.msg);
            int lid = 0;
            try
            {
                lid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                lid = -1;
            }

            List<int> count = this.LCount();
            while (!count.Contains(lid))
            {
                var msg9 = new { msg = "The is no instance with the given ID in the  [LAPTOP] table. \nTry again..." };
                Console.WriteLine(msg9.msg);
                try
                {
                    lid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

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
            int ram = 0;
            try
            {
                ram = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                ram = -1;
            }

            while (ram < 0)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    ram = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    ram = -1;
                }
            }

            var msg6 = new { msg = "Enter the specification price" };
            Console.WriteLine(msg6.msg);
            int price = 0;
            try
            {
                price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                price = -1;
            }

            while (price < 0)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    price = -1;
                }
            }

            this.adminlogic.AddSpec(lid, name, cpu, vga, ram, price);
            Console.ForegroundColor = ConsoleColor.Green;
            var msg7 = new { msg = "Adding a SPECIFICATION was successfull! ^^" };
            Console.WriteLine(msg7.msg);
            Console.ResetColor();
            var msg8 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg8.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for a brands ID you want to delet from the DB and Delets it.
        /// </summary>
        private void DeleteBrand()
        {
            var msg = new { msg = "Enter the brands ID, you want to delete." };
            Console.WriteLine(msg.msg);
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                id = -1;
            }

            List<int> count = this.BCount();
            while (!count.Contains(id))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [BRAND] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            this.adminlogic.DeleteBrand(id);
            Console.ForegroundColor = ConsoleColor.Green;
            var msg5 = new { msg = "Deleting a BRAND was successfull! ^^" };
            Console.WriteLine(msg5.msg);
            Console.ResetColor();
            var msg6 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg6.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for a laptops ID you want to delet from the DB and Delets it.
        /// </summary>
        private void DeleteLaptop()
        {
            var msg = new { msg = "Enter the laptop ID, you want to delete." };
            Console.WriteLine(msg.msg);
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                id = -1;
            }

            List<int> count = this.LCount();
            while (!count.Contains(id))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [LAPTOP] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            this.adminlogic.DeleteLaptop(id);
            Console.ForegroundColor = ConsoleColor.Green;
            var msg5 = new { msg = "Deleting a lAPTOP was successfull! ^^" };
            Console.WriteLine(msg5.msg);
            Console.ResetColor();
            var msg6 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg6.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for a specifications ID you want to delet from the DB and Delets it.
        /// </summary>
        private void DeleteSpec()
        {
            var msg = new { msg = "Enter the specification ID, you want to delete." };
            Console.WriteLine(msg.msg);
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                id = -1;
            }

            List<int> count = this.SCount();
            while (!count.Contains(id))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [SPECIFICATION] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            this.adminlogic.DeleteSpec(id);
            Console.ForegroundColor = ConsoleColor.Green;
            var msg5 = new { msg = "Deleting a SPECIFICATION was successfull! ^^" };
            Console.WriteLine(msg5.msg);
            Console.ResetColor();
            var msg6 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg6.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for the id of the brand you want to update, than asks for the new parameters, than upedates is.
        /// </summary>
        private void UpdateBrand()
        {
            var msg = new { msg = "Enter the brands ID, you want to update" };
            Console.WriteLine(msg.msg);
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                id = -1;
            }

            List<int> count = this.BCount();
            while (!count.Contains(id))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [BRAND] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            var msg1 = new { msg = "Enter the brands new name" };
            Console.WriteLine(msg1.msg);
            string name = Console.ReadLine();
            var msg2 = new { msg = "Enter the foundation new  year" };
            Console.WriteLine(msg2.msg);
            int fyear = 0;
            try
            {
                fyear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                fyear = -1;
            }

            while (fyear < 0 || fyear > 2021)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    fyear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    fyear = -1;
                }
            }

            var msg3 = new { msg = "Enter the new headquarters" };
            Console.WriteLine(msg3.msg);
            string head = Console.ReadLine();
            var msg4 = new { msg = "Enter the new CEO name" };
            Console.WriteLine(msg4.msg);
            string ceo = Console.ReadLine();
            this.adminlogic.BrandUpdate(id, name, fyear, head, ceo);
            Console.ForegroundColor = ConsoleColor.Green;
            var msg5 = new { msg = "Updating a BRAND was successfull! ^^" };
            Console.WriteLine(msg5.msg);
            Console.ResetColor();
            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for the id of the laptops you want to update, than asks for the new parameters, than upedates is.
        /// </summary>
        private void UpdateLaptop()
        {
            var msg = new { msg = "Enter the laptops ID, you want to update" };
            Console.WriteLine(msg.msg);
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                id = -1;
            }

            List<int> count = this.LCount();
            while (!count.Contains(id))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [LAPTOP] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            var msg1 = new { msg = "Enter the laptops  new  brand ID" };
            Console.WriteLine(msg1.msg);
            int bid = 0;
            try
            {
                bid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                bid = -1;
            }

            List<int> count2 = this.BCount();
            while (!count2.Contains(bid))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [BRAND] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    bid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            var msg2 = new { msg = "Enter the laptops new name" };
            Console.WriteLine(msg2.msg);
            string name = Console.ReadLine();
            var msg3 = new { msg = "Enter the new release year" };
            Console.WriteLine(msg3.msg);
            int ryear = 0;
            try
            {
                ryear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                ryear = -1;
            }

            while (ryear < 0 || ryear > 2021)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    ryear = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    ryear = -1;
                }
            }

            var msg4 = new { msg = "Enter the new price" };
            Console.WriteLine(msg4.msg);
            int price = 0;
            try
            {
                price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                price = -1;
            }

            while (price < 0)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    price = -1;
                }
            }

            this.adminlogic.LaptopUpdate(id, name, ryear, price);
            Console.ForegroundColor = ConsoleColor.Green;
            var msg5 = new { msg = "Updating a LAPTOP was successfull! ^^" };
            Console.WriteLine(msg5.msg);
            Console.ResetColor();
            var msg6 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg6.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for the id of the specifications you want to update, than asks for the new parameters, than upedates is.
        /// </summary>
        private void UpdateSpec()
        {
            var msg = new { msg = "Enter the specifications ID, you want to update" };
            Console.WriteLine(msg.msg);
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                id = -1;
            }

            List<int> count = this.SCount();
            while (!count.Contains(id))
            {
                var msg10 = new { msg = "The is no instance with the given ID in the [SPECIFICATION] table. \nTry again..." };
                Console.WriteLine(msg10.msg);
                try
                {
                    id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            var msg1 = new { msg = "Enter the specifications new  laptop ID" };
            Console.WriteLine(msg1.msg);
            int lid = 0;
            try
            {
                lid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
            }

            List<int> count2 = this.LCount();
            while (!count2.Contains(lid))
            {
                var msg10 = new { msg = "The is no instance with the given ID in the [LAPTOP] table. \nTry again..." };
                Console.WriteLine(msg10.msg);
                try
                {
                    lid = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    lid = -1;
                }
            }

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
            int ram = 0;
            try
            {
                ram = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                ram = -1;
            }

            while (ram < 0)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    ram = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    ram = -1;
                }
            }

            var msg6 = new { msg = "Enter the specification price" };
            Console.WriteLine(msg6.msg);
            int price = 0;
            try
            {
                price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                price = -1;
            }

            while (price < 0)
            {
                var msg26 = new { msg = "Try again..." };
                Console.WriteLine(msg26.msg);
                try
                {
                    price = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                    price = -1;
                }
            }

            this.adminlogic.SpecUpdate(id, name, cpu, vga, ram, price);
            Console.ForegroundColor = ConsoleColor.Green;
            var msg7 = new { msg = "Updating a LAPTOP was successfull! ^^" };
            Console.WriteLine(msg7.msg);
            Console.ResetColor();
            var msg8 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg8.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for an ID of the brand you want to see, and lists it.
        /// </summary>
        private void ListBrand()
        {
            var msg = new { msg = "Enter the ID of a brand, you want to find." };
            Console.WriteLine(msg.msg);
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                id = -1;
            }

            List<int> count = this.BCount();
            while (!count.Contains(id))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [BRAND] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            var msg2 = new { msg = this.userlogic.BrandGetOne(id) };
            Console.WriteLine(msg2.msg);
            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for an ID of the laptop you want to see, and lists it.
        /// </summary>
        private void ListLaptop()
        {
            var msg = new { msg = "Enter the ID of a laptop, you want to find." };
            Console.WriteLine(msg.msg);
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                id = -1;
            }

            List<int> count = this.LCount();
            while (!count.Contains(id))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [LAPTOP] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            var msg2 = new { msg = this.userlogic.LaptopGetOne(id) };
            Console.WriteLine(msg2.msg);
            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Asks for an ID of the specification you want to see, and lists it.
        /// </summary>
        private void ListSpec()
        {
            var msg = new { msg = "Enter the ID of a specification, you want to find." };
            Console.WriteLine(msg.msg);
            int id = 0;
            try
            {
                id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
            }
            catch (System.FormatException)
            {
                var msg95 = new { msg = "It must be and integer!" };
                Console.WriteLine(msg95.msg);
                id = -1;
            }

            List<int> count = this.SCount();
            while (!count.Contains(id))
            {
                var msg8 = new { msg = "The is no instance with the given ID in the [SPECIFICATION] table. \nTry again..." };
                Console.WriteLine(msg8.msg);
                try
                {
                    id = int.Parse(Console.ReadLine(), new CultureInfo("en-US"));
                }
                catch (System.FormatException)
                {
                    var msg95 = new { msg = "It must be and integer!" };
                    Console.WriteLine(msg95.msg);
                }
            }

            var msg2 = new { msg = this.userlogic.SpecGetOne(id) };
            Console.WriteLine(msg2.msg);
            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Lists countries and their laptop counts.
        /// </summary>
        private void CountLaptop()
        {
            var msg = new { msg = "<<Countries and their laptop counts>> \n" };
            Console.WriteLine(msg.msg);
            foreach (var item in this.userlogic.LaptopCount())
            {
                var msg2 = new { msg = item };
                Console.WriteLine(msg2.msg);
            }

            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Lists laptops and their average specification price.
        /// </summary>
        private void AvgSpec()
        {
            var msg = new { msg = "<<Laptops and their average specification price>> \n" };
            Console.WriteLine(msg.msg);
            IList<string> list = this.userlogic.AvgSpecPrice();
            foreach (var item in list)
            {
                var msg2 = new { msg = item.ToString() };
                Console.WriteLine(msg2.msg);
            }

            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Lists the brands names who has Gamer specifications.
        /// </summary>
        private void GamerBrand()
        {
            var msg = new { msg = "<<Brands names who has Gamer specifications>> \n" };
            Console.WriteLine(msg.msg);
            foreach (var item in this.userlogic.GamerBrand())
            {
                var msg2 = new { msg = item };
                Console.WriteLine(msg2.msg);
            }

            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// LaptopCount() but with task.
        /// </summary>
        private void LaptopCountASYNC()
        {
            var tmp = this.userlogic.LaptopCountAsync();
            Thread.Sleep(500);
            var msg = new { msg = "\n Processing started...." };
            Console.WriteLine(msg.msg);
            Thread.Sleep(1000);
            tmp.Wait();
            var result = tmp.Result;
            var msg1 = new { msg = "\n Process end! ^^" };
            Console.WriteLine(msg1.msg);

            var msg2 = new { msg = "\n <<Countries and their laptop counts>> \n" };
            Console.WriteLine(msg2.msg);
            for (int i = 0; i < result.Count; i++)
            {
                string item = result[i];
                var msg3 = new { msg = item };
                Console.WriteLine(msg3.msg);
            }

            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// AvgSpec() but with task.
        /// </summary>
        private void AvgSpecASYNC()
        {
            var tmp = this.userlogic.AvgSpecPriceAsync();
            Thread.Sleep(500);
            var msg = new { msg = "\n Processing started...." };
            Console.WriteLine(msg.msg);
            Thread.Sleep(1000);
            tmp.Wait();
            var result = tmp.Result;
            var msg1 = new { msg = "\n Process end! ^^" };
            Console.WriteLine(msg1.msg);

            var msg2 = new { msg = "\n <<Laptops and their average specification price>> \n" };
            Console.WriteLine(msg2.msg);
            for (int i = 0; i < result.Count; i++)
            {
                string item = result[i];
                var msg3 = new { msg = item };
                Console.WriteLine(msg3.msg);
            }

            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// GamerBrand() but with task.
        /// </summary>
        private void GamerBrandASYNC()
        {
            var tmp = this.userlogic.GamerBrandAsync();
            Thread.Sleep(500);
            var msg = new { msg = "Processing started...." };
            Console.WriteLine(msg.msg);
            Thread.Sleep(1000);
            tmp.Wait();
            var result = tmp.Result;
            var msg1 = new { msg = "Process end! ^^" };
            Console.WriteLine(msg1.msg);

            var msg2 = new { msg = "<<Brands names who has Gamer specifications>> \n" };
            Console.WriteLine(msg2.msg);
            for (int i = 0; i < result.Count; i++)
            {
                string item = result[i];
                var msg3 = new { msg = item };
                Console.WriteLine(msg3.msg);
            }

            var msg86 = new { msg = "Press any key to continue..." };
            Console.WriteLine(msg86.msg);
            Console.ReadKey();
        }

        /// <summary>
        /// Function to get the IDs of the Laptop table.
        /// </summary>
        /// <returns>List of IDs in Laptop Table.</returns>
        private List<int> LCount()
        {
            List<int> tmp = new List<int>();
            var tmp2 = this.userlogic.GetAllLaptop();
            foreach (var item in tmp2)
            {
                tmp.Add(item.Id);
            }

            return tmp;
        }

        /// <summary>
        /// Function to get the IDs of the Brand table.
        /// </summary>
        /// <returns>List of IDs in Brand Table.</returns>
        private List<int> BCount()
        {
            List<int> tmp = new List<int>();
            var tmp2 = this.userlogic.GetAllBrand();
            foreach (var item in tmp2)
            {
                tmp.Add(item.Id);
            }

            return tmp;
        }

        /// <summary>
        /// Function to get the IDs of the Specification table.
        /// </summary>
        /// <returns>List of IDs in Specification Table.</returns>
        private List<int> SCount()
        {
            List<int> tmp = new List<int>();
            var tmp2 = this.userlogic.GetAllSpec();
            foreach (var item in tmp2)
            {
                tmp.Add(item.Id);
            }

            return tmp;
        }
    }
}
