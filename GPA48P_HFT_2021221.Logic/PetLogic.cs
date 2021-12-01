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

        public PetLogic(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
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
            return petRepository.GetAll().Average(p => p.Age);
        }
    }
}
