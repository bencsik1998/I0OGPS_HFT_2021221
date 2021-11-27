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
    public class OwnerController : ControllerBase
    {
        IOwnerLogic ol;

        public OwnerController(IOwnerLogic ol)
        {
            this.ol = ol;
        }

        // GET: /owner
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return ol.GetAll();
        }

        // GET /owner/id
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return ol.Read(id);
        }

        // POST /owner
        [HttpPost]
        public void Post([FromBody] Owner value)
        {
            ol.Create(value);
        }

        // PUT /owner
        [HttpPut("{id}")]
        public void Put([FromBody] Owner value)
        {
            ol.Update(value);
        }

        // DELETE /owner/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ol.Delete(id);
        }
    }
}
