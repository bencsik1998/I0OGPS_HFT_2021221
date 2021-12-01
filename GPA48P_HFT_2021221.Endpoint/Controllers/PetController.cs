using GPA48P_HFT_2021221.Models;
using GPA48P_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GPA48P_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        IPetLogic pl;

        public PetController(IPetLogic pl)
        {
            this.pl = pl;
        }

        // GET: /pet
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return pl.GetAll();
        }

        // GET /pet/petid
        [HttpGet("{petid}")]
        public Pet Get(int petId)
        {
            return pl.Read(petId);
        }

        // POST /pet
        [HttpPost]
        public void Post([FromBody] Pet value)
        {
            pl.Create(value);
        }

        // PUT /pet/petid
        [HttpPut("{petid}")]
        public void Put([FromBody] Pet value)
        {
            pl.Update(value);
        }

        // DELETE /pet/petid
        [HttpDelete("{petid}")]
        public void Delete(int petId)
        {
            pl.Delete(petId);
        }
    }
}
