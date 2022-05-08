using System.Collections.Generic;
using I0OGPS_HFT_2021221.Models;

namespace I0OGPS_HFT_2021221.Logic
{
    public interface IAnimalShelterLogic
    {
        void Create(AnimalShelter animalShelter);

        void Delete(int shelterId);

        AnimalShelter Read(int shelterId);

        IEnumerable<AnimalShelter> GetAll();

        void Update(AnimalShelter animalShelter);

        double AvarageAgeByPetsAtOneShelter(int shelterId);

        IEnumerable<AvarageAgeOfDogsAtAllShelters> AvarageAgeOfDogsAtAllShelters();
    }
}
