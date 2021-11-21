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
        IAnimalShelterRepository animalShelterRepository;

        public AnimalShelterLogic(IAnimalShelterRepository animalShelterRepository)
        {
            this.animalShelterRepository = animalShelterRepository;
        }

        public void Create(AnimalShelter animalShelter)
        {
            if (animalShelter.SheltertName == "")
            {
                throw new Exception("A menhely neve nem lehet üres!");
            }
            else if (animalShelter.SheltertName.Length < 5)
            {
                throw new Exception("A menhely neve legalább 5 karakter hosszúságú legyen!");
            }
            else if (animalShelter.Address == "")
            {
                throw new Exception("A menhely címe nem lehet üres!");
            }
            else if (animalShelter.PhoneNumber == 0)
            {
                throw new Exception("A menhely telefonszáma nem lehet nulla!");
            }
            else if (animalShelter.PhoneNumber == 0)
            {
                throw new Exception("A menhely telefonszáma nem lehet nulla!");
            }
            animalShelterRepository.Create(animalShelter);
        }

        public void Delete(int shelterId)
        {
            animalShelterRepository.Delete(shelterId);
        }

        public AnimalShelter Read(int shelterId)
        {
            return animalShelterRepository.Read(shelterId);
        }

        public IEnumerable<AnimalShelter> ReadAll()
        {
            return animalShelterRepository.ReadAll();
        }

        public void Update(AnimalShelter animalShelter)
        {
            animalShelterRepository.Update(animalShelter);
        }
    }
}
