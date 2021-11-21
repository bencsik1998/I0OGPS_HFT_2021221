using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public IEnumerable<Pet> ReadAll()
        {
            return petRepository.ReadAll();
        }

        public void Update(Pet pet)
        {
            petRepository.Update(pet);
        }
    }
}
