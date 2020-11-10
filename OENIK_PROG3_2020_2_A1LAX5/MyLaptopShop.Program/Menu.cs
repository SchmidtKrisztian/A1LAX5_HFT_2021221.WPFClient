// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Program
{
    using MyLaptopShop.Logic.Classes;
    using MyLaptopShop.Logic.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is the Menu class.
    /// </summary>
    public class Menu
    {
        private LaptopLogic laptopLogic;

        public Menu()
        {
            this.laptopLogic = new LaptopLogic();
        }

    }
}
