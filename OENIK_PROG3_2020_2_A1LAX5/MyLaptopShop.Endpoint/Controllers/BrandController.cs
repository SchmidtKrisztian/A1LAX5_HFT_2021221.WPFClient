using Microsoft.AspNetCore.Mvc;
using MyLaptopShop.Data.Models;
using MyLaptopShop.Logic.Interfaces;
using System.Collections.Generic;

namespace MyLaptopShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IAdministratorLogic adminlogic;
        IUserLogic userlogic;

        public BrandController(IAdministratorLogic adminlogic, IUserLogic userlogic)
        {
            this.adminlogic = adminlogic;
            this.userlogic = userlogic;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Brand> GetAll()
        {
            return this.userlogic.GetAllBrand();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Brand GetOne(int id)
        {
            return this.userlogic.BrandGetOne(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.adminlogic.AddBrand(value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Update([FromBody] Brand value)
        {
            this.adminlogic.BrandUpdate(value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.adminlogic.DeleteBrand(id);
        }
    }
}
