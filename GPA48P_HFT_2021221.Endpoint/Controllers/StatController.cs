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

        // GET: /stat/avarageagebypetsatoneshelter/shelterid
        [HttpGet("{shelterid}")]
        public double AvarageAgeByPetsAtOneShelter(int shelterId)
        {
            return asl.AvarageAgeByPetsAtOneShelter(shelterId);
        }

        // GET: /stat/avarageageofdogsatallshelters
        [HttpGet]
        public IEnumerable<AvarageAgeOfDogsAtAllShelters> AvarageAgeOfDogsAtAllShelters()
        {
            return asl.AvarageAgeOfDogsAtAllShelters();
        }

        // GET: /stat/dogsofowner/ownerid
        [HttpGet("{ownerid}")]
        public IEnumerable<Pet> DogsOfOwner(int ownerId)
        {
            return ol.DogsOfOwner(ownerId);
        }

        // GET: /stat/mostcatsadoptedby
        [HttpGet]
        public Owner MostCatsAdoptedBy()
        {
            return ol.MostCatsAdoptedBy();
        }

        [HttpGet]
        public double AvarageAgeOfPets()
        {
            return pl.AvarageAgeOfPets();
        }
    }
}
