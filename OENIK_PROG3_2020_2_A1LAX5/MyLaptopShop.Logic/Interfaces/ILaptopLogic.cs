using MyLaptopShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLaptopShop.Logic.Interfaces
{
    interface ILaptopLogic<T>
        where T : class
    {
        Laptop GetLaptopById(int id);

        void Update(T istance, string property, string newname);

        IList<T> GetAllLaptops();

        void DeleteLaptop(int id);
    }
}
