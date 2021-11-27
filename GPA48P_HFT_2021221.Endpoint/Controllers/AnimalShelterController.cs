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

        // GET /animalShelter/id
        [HttpGet("{id}")]
        public AnimalShelter Get(int id)
        {
            return asl.Read(id);
        }

        // POST /animalShelter
        [HttpPost]
        public void Post([FromBody] AnimalShelter value)
        {
            asl.Create(value);
        }

        // PUT /animalShelter
        [HttpPut("{id}")]
        public void Put([FromBody] AnimalShelter value)
        {
            asl.Update(value);
        }

        // DELETE /animalShelter/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            asl.Delete(id);
        }
    }
}
