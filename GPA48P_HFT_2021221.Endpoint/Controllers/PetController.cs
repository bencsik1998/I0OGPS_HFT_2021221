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

        // GET /pet/id
        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return pl.Read(id);
        }

        // POST /pet
        [HttpPost]
        public void Post([FromBody] Pet value)
        {
            pl.Create(value);
        }

        // PUT /pet
        [HttpPut("{id}")]
        public void Put([FromBody] Pet value)
        {
            pl.Update(value);
        }

        // DELETE /pet/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
