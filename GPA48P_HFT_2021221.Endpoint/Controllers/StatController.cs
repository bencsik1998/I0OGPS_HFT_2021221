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

        // GET: /stat/getavarageagebypetsatoneshelter/id
        [HttpGet("{id}")]
        public double GetAvarageAgeByPetsAtOneShelter(int shelterId)
        {
            return asl.AvarageAgeByPetsAtOneShelter(shelterId);
        }

        // GET: /stat/getavarageageofdogsatallshelters
        [HttpGet]
        public IEnumerable<AvarageAgeOfDogsAtAllShelters> GetAvarageAgeOfDogsAtAllShelters()
        {
            return asl.AvarageAgeOfDogsAtAllShelters();
        }

        // GET: /stat/getdogsofowner/id
        [HttpGet("{id}")]
        public IEnumerable<Pet> GetDogsOfOwner(int ownerId)
        {
            return ol.DogsOfOwner(ownerId);
        }

        // GET: /stat/getmostcatsadoptedby
        [HttpGet]
        public Owner GetMostCatsAdoptedBy()
        {
            return ol.MostCatsAdoptedBy();
        }

        // GET: /stat/getavarageageofpets
        [HttpGet]
        public double GetAvarageAgeOfPets()
        {
            return pl.AvarageAgeOfPets();
        }

        // GET: /stat/getvalami
        [HttpGet]
        public void GetValami()
        {

        }
    }
}
