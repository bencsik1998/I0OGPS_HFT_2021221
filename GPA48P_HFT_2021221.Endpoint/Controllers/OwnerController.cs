using GPA48P_HFT_2021221.Models;
using GPA48P_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        // GET /owner/ownerid
        [HttpGet("{ownerid}")]
        public Owner Get(int ownerId)
        {
            return ol.Read(ownerId);
        }

        // POST /owner
        [HttpPost]
        public void Post([FromBody] Owner value)
        {
            ol.Create(value);
        }

        // PUT /owner
        [HttpPut]
        public void Put([FromBody] Owner value)
        {
            ol.Update(value);
        }

        // DELETE /owner/ownerid
        [HttpDelete("{ownerid}")]
        public void Delete(int ownerId)
        {
            ol.Delete(ownerId);
        }
    }
}
