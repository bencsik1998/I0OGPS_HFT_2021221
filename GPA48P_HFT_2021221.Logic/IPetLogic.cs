using System.Collections.Generic;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Logic
{
    public interface IPetLogic
    {
        void Create(Pet pet);

        void Delete(int petId);

        Pet Read(int petId);

        IEnumerable<Pet> GetAll();

        void Update(Pet pet);

        double AvarageAgeOfPets();

        IEnumerable<string> WhichOwnersAdoptedPetBefore2015();
    }
}
