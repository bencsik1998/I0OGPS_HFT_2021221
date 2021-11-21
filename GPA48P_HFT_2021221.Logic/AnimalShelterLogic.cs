using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Models;
using GPA48P_HFT_2021221.Repository;

namespace GPA48P_HFT_2021221.Logic
{
    public class AnimalShelterLogic : IAnimalShelterLogic
    {
        IAnimalShelterRepository AnimalShelterRepository;

        public AnimalShelterLogic(IAnimalShelterRepository animalShelterRepository)
        {
            AnimalShelterRepository = animalShelterRepository;
        }

        public void Create(AnimalShelter animalShelter)
        {
            if (animalShelter.SheltertName.Length < 5)
            {
                throw new Exception("A menhely neve legalább 5 karakter hosszúságú legyen!");
            }
            AnimalShelterRepository.Create(animalShelter);
        }

        public void Delete(int shelterId)
        {
            AnimalShelterRepository.Delete(shelterId);
        }

        public AnimalShelter Read(int shelterId)
        {
            return AnimalShelterRepository.Read(shelterId);
        }

        public IEnumerable<AnimalShelter> ReadAll()
        {
            return AnimalShelterRepository.ReadAll();
        }

        public void Update(AnimalShelter animalShelter)
        {
            AnimalShelterRepository.Update(animalShelter);
        }
    }
}
