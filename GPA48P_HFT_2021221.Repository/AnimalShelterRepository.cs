using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Data;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Repository
{
    public class AnimalShelterRepository : IAnimalShelterRepository
    {
        AnimalShelterDbContext DataBase;

        public AnimalShelterRepository(AnimalShelterDbContext dataBase)
        {
            DataBase = dataBase;
        }

        public void Create(AnimalShelter animalShelter)
        {
            DataBase.AnimalShelters.Add(animalShelter);
            DataBase.SaveChanges();
        }

        public void Delete(int shelterId)
        {
            var animalShelterToDelete = Read(shelterId);
            DataBase.AnimalShelters.Remove(animalShelterToDelete);
            DataBase.SaveChanges();
        }

        public AnimalShelter Read(int shelterId)
        {
            return DataBase.AnimalShelters.FirstOrDefault(t => t.ShelterId == shelterId);
        }

        public IQueryable<AnimalShelter> ReadAll()
        {
            return DataBase.AnimalShelters;
        }

        public void Update(AnimalShelter animalShelter)
        {
            var oldAnimalShelter = Read(animalShelter.ShelterId);
            oldAnimalShelter.SheltertName = animalShelter.SheltertName;
            oldAnimalShelter.Address = animalShelter.Address;
            oldAnimalShelter.PhoneNumber = animalShelter.PhoneNumber;
            oldAnimalShelter.TaxNumber = animalShelter.TaxNumber;
            DataBase.SaveChanges();
        }
    }
}
