using System;
using System.Collections.Generic;
using System.Linq;
using GPA48P_HFT_2021221.Models;
using GPA48P_HFT_2021221.Repository;

namespace GPA48P_HFT_2021221.Logic
{
    public class PetLogic : IPetLogic
    {
        IPetRepository petRepository;
        IOwnerRepository ownerRepository;

        public PetLogic(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            this.petRepository = petRepository;
            this.ownerRepository = ownerRepository;
        }

        public void Create(Pet pet)
        {
            if (pet.Age < 1)
            {
                throw new Exception("A kisállat kora nem lehet kisebb egynél!");
            }
            else if (pet.Class is null || pet.Class == "")
            {
                throw new Exception("A kisállat osztály és típus besorolása nem lehet üres!");
            }
            else if (pet.Type is null || pet.Type == "")
            {
                throw new Exception("A kisállat típusa nem lehet üres!");
            }
            petRepository.Create(pet);
        }

        public void Delete(int petId)
        {
            petRepository.Delete(petId);
        }

        public Pet Read(int petId)
        {
            return petRepository.Read(petId);
        }

        public IEnumerable<Pet> GetAll()
        {
            return petRepository.GetAll();
        }

        public void Update(Pet pet)
        {
            petRepository.Update(pet);
        }

        // Nézzük meg, hogy mennyi az állatok átlagéletkora!
        public double AvarageAgeOfPets()
        {
            return petRepository.GetAll()
                                .Average(p => p.Age);
        }

        // Nézzük meg mely gazdik fogadtak örökbe 2015 előtt kisállatot!
        public IEnumerable<string> WhichOwnersAdoptedPetBefore2015()
        {
            var result = petRepository.GetAll()
                                      .Where(x => x.AdoptionYear < 2015)
                                      .Select(x => x.OwnerId)
                                      .Distinct();

            List<string> owners = new List<string>();
            result.ToList()
                  .ForEach(x => owners
                    .Add(ownerRepository
                        .Read(x).LastName + " " + ownerRepository
                        .Read(x).FirstName));

            return owners;
        }
    }
}
