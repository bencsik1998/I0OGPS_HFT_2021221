using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Repository
{
    public interface IAnimalShelterRepository
    {
        void Create(AnimalShelter animalShelter);

        void Delete(int shelterId);

        AnimalShelter Read(int shelterId);

        IQueryable<AnimalShelter> GetAll();

        void Update(AnimalShelter animalShelter);
    }
}
