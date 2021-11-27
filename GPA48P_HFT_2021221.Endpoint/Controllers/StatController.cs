using GPA48P_HFT_2021221.Models;
using GPA48P_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GPA48P_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IAnimalShelterLogic asl;
        IOwnerLogic ol;
        IPetLogic pl;

        public StatController(IAnimalShelterLogic asl, IOwnerLogic ol, IPetLogic pl)
        {
            this.asl = asl;
            this.ol = ol;
            this.pl = pl;
        }

        // GET: /stat/avarageAgeByPetsAtOneShelter
        [HttpGet("{id}")]
        public double GetAvarageAgeByPetsAtOneShelter(int shelterId)
        {
            return asl.AvarageAgeByPetsAtOneShelter(shelterId);
        }

        // GET: /stat/avarageAgeOfDogsAtAllShelters
        [HttpGet]
        public IEnumerable<AvarageAgeOfDogsAtAllShelters> GetAvarageAgeOfDogsAtAllShelters()
        {
            return asl.AvarageAgeOfDogsAtAllShelters();
        }

        // GET: /stat/dogsOfOwner
        [HttpGet("{id}")]
        public IEnumerable<Pet> GetDogsOfOwner(int ownerId)
        {
            return ol.DogsOfOwner(ownerId);
        }

        // GET: /stat/mostCatsAdoptedBy
        [HttpGet]
        public Owner GetMostCatsAdoptedBy()
        {
            return ol.MostCatsAdoptedBy();
        }

        // GET: /stat/avarageAge
        [HttpGet]
        public double AvarageAge()
        {
            return pl.AvarageAge();
        }

        // GET: /stat/valami
        [HttpGet]
        public void GetValami()
        {

        }
    }
}
