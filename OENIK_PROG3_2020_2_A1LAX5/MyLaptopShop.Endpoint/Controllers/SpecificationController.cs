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
    public class SpecificationController : ControllerBase
    {
        IAdministratorLogic adminlogic;
        IUserLogic userlogic;
        IHubContext<SignalRHub> hub;

        public SpecificationController(IAdministratorLogic adminlogic, IUserLogic userlogic, IHubContext<SignalRHub> hub)
        {
            this.adminlogic = adminlogic;
            this.userlogic = userlogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("SpecCreated", value);
        }

        // PUT api/<BrandController>/5
        [HttpPut]
        public void Update([FromBody] Specification value)
        {
            this.adminlogic.SpecUpdate(value);
            this.hub.Clients.All.SendAsync("SpecUpdated", value);
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var specToDelete = this.userlogic.SpecGetOne(id);
            this.adminlogic.DeleteSpec(id);
            this.hub.Clients.All.SendAsync("SpecDeleted", specToDelete);
        }
    }
}
