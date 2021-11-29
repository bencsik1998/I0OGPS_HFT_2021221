using GPA48P_HFT_2021221.Models;
using GPA48P_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        // GET: /animalshelter
        [HttpGet]
        public IEnumerable<AnimalShelter> Get()
        {
            return asl.GetAll();
        }

        // GET /animalshelter/id
        [HttpGet("{id}")]
        public AnimalShelter Get(int id)
        {
            return asl.Read(id);
        }

        // POST /animalshelter
        [HttpPost]
        public void Post([FromBody] AnimalShelter value)
        {
            asl.Create(value);
        }

        // PUT /animalshelter/id
        [HttpPut("{id}")]
        public void Put([FromBody] AnimalShelter value)
        {
            asl.Update(value);
        }

        // DELETE /animalshelter/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            asl.Delete(id);
        }
    }
}
