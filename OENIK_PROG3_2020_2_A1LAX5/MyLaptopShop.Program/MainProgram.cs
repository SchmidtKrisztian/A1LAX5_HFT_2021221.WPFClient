// <copyright file="MainProgram.cs" company="PlaceholderCompany">
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
    using MyLaptopShop.Repository;
    using MyLaptopShop.Repository.Classes;
    using MyLaptopShop.Repository.Database;

    /// <summary>
    /// This is the main class.
    /// </summary>
    public static class MainProgram
    {
        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main()
        {
            Factory factory = new Factory();
            factory.ConsoleMenu.MainMenu();
        }
    }
}
