using Microsoft.AspNetCore.Mvc;
using MyLaptopShop.Data.Models;
using MyLaptopShop.Logic.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLaptopShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        IAdministratorLogic adminlogic;
        IUserLogic userlogic;

        public SpecificationController(IAdministratorLogic adminlogic, IUserLogic userlogic)
        {
            this.adminlogic = adminlogic;
            this.userlogic = userlogic;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Specification> GetAll()
        {
            return this.userlogic.GetAllSpec();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Specification GetOne(int id)
        {
            return this.userlogic.SpecGetOne(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Create([FromBody] Specification value)
        {
            this.adminlogic.AddSpec(value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Update([FromBody] Specification value)
        {
            this.adminlogic.SpecUpdate(value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.adminlogic.DeleteSpec(id);
        }
    }
}
