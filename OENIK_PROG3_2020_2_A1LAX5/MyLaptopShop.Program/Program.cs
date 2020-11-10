// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLaptopShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    /// <summary>
    /// This is the main class.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            Menu menu = new Menu();
            MainMenu();
        }
    }
}
