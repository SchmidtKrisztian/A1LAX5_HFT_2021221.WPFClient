// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ConsoleTools;
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

        public void Menu(LaptopLogic laptoplogic)
        {
            var menu = new ConsoleMenu()
                .Add(">> List all BRANDs", () => ListAllBrand(laptoplogic))
                .Add(">> List all LAPTOPs", () => ListAllLaptops(laptoplogic))
                .Add(">> List all SPECIFICATIONs", () => ListAllSpecs(laptoplogic))
                .Add(">> Add new BRAND", () => AddBrand(laptoplogic))
                .Add(">> Add new LAPTOP", () => AddLaptop(laptoplogic))
                .Add(">> Add new SPECIFICATION", () => AddSpec(laptoplogic))
                .Add(">> Delete a BRAND", () => DeleteBrand(laptoplogic))
                .Add(">> Delete a LAPTOP", () => DeleteLaptop(laptoplogic))
                .Add(">> Delete a SPECIFICATION", () => DeleteSpec(laptoplogic))
                .Add(">> Update a BRAND", () => UpdateBrands(laptoplogic))
                .Add(">> Update a LAPTOP", () => UpdateLaptop(laptoplogic))
                .Add(">> Update a SPECIFICATION", () => UpdateSpec(laptoplogic))
                .Add(">> List a BRAND, by ID", () => ListBrand(laptoplogic))
                .Add(">> List a LAPTOP, by ID", () => ListLaptop(laptoplogic))
                .Add(">> List a SPECIFICATION, by ID", () => ListSpec(laptoplogic))
                .Add(">> List countries with their laptop count", () => CountLaptop(laptoplogic))
                .Add(">> List laptops with their average specification cost", () => AvgSpec(laptoplogic))
                .Add(">> List Brand name, laptop name and average highest specification cost", () => HghLaptop(laptoplogic));
        }
    }
}
