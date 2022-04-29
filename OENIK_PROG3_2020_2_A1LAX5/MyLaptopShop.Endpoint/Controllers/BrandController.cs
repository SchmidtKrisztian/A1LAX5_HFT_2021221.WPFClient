using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyLaptopShop.Data.Models;
using MyLaptopShop.Endpoint.Services;
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
        IHubContext<SignalRHub> hub;
        public BrandController(IAdministratorLogic adminlogic, IUserLogic userlogic, IHubContext<SignalRHub> hub)
        {
            this.adminlogic = adminlogic;
            this.userlogic = userlogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("BrandCreated",value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Update([FromBody] Brand value)
        {
            this.adminlogic.BrandUpdate(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brandToDelete = this.userlogic.BrandGetOne(id);
            this.adminlogic.DeleteBrand(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", brandToDelete);
        }
    }
}
