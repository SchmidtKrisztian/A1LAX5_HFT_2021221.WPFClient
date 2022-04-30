using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyLaptopShop.Data.Models;
using MyLaptopShop.Endpoint.Services;
using MyLaptopShop.Logic.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLaptopShop.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        IAdministratorLogic adminlogic;
        IUserLogic userlogic;
        IHubContext<SignalRHub> hub;

        public LaptopController(IAdministratorLogic adminlogic, IUserLogic userlogic, IHubContext<SignalRHub> hub)
        {
            this.adminlogic = adminlogic;
            this.userlogic = userlogic;
            this.hub = hub;
        }

        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<Laptop> GetAll()
        {
            return this.userlogic.GetAllLaptop();
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public Laptop GetOne(int id)
        {
            return this.userlogic.LaptopGetOne(id);
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Create([FromBody] Laptop value)
        {
            this.adminlogic.AddLaptop(value);
            this.hub.Clients.All.SendAsync("LaptopCreated", value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Update([FromBody] Laptop value)
        {
            this.adminlogic.LaptopUpdate(value);
            this.hub.Clients.All.SendAsync("LaptopUpdated", value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var laptopToDelete = this.userlogic.LaptopGetOne(id);
            this.adminlogic.DeleteLaptop(id);
            this.hub.Clients.All.SendAsync("LaptopDeleted", laptopToDelete);
        }
    }
}
