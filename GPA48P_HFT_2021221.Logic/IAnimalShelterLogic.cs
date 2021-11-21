using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Logic
{
    public interface IAnimalShelterLogic
    {
        void Create(AnimalShelter animalShelter);

        void Delete(int shelterId);

        AnimalShelter Read(int shelterId);

        IEnumerable<AnimalShelter> ReadAll();

        void Update(AnimalShelter animalShelter);
    }
}
