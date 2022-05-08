using I0OGPS_HFT_2021221.Models;
using I0OGPS_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace I0OGPS_HFT_2021221.Endpoint.Controllers
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

        // GET /animalshelter/shelterid
        [HttpGet("{shelterid}")]
        public AnimalShelter Get(int shelterId)
        {
            return asl.Read(shelterId);
        }

        // POST /animalshelter
        [HttpPost]
        public void Post([FromBody] AnimalShelter value)
        {
            asl.Create(value);
        }

        // PUT /animalshelter
        [HttpPut]
        public void Put([FromBody] AnimalShelter value)
        {
            asl.Update(value);
        }

        // DELETE /animalshelter/shelterid
        [HttpDelete("{shelterid}")]
        public void Delete(int shelterId)
        {
            asl.Delete(shelterId);
        }
    }
}
