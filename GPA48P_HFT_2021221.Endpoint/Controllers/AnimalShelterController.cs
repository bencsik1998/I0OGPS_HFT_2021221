using GPA48P_HFT_2021221.Models;
using GPA48P_HFT_2021221.Repository;
using GPA48P_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GPA48P_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalShelterController : ControllerBase
    {
        IAnimalShelterLogic asl;

        public AnimalShelterController(IAnimalShelterLogic asl)
        {
            this.asl = asl;
        }

        // GET: /animalShelter
        [HttpGet]
        public IEnumerable<AnimalShelter> Get()
        {
            return asl.ReadAll();
        }

        // GET api/<AnimalShelterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AnimalShelterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnimalShelterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnimalShelterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
