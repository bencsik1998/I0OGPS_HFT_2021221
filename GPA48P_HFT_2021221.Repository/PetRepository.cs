using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Data;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Repository
{
    public class PetRepository : IPetRepository
    {
        AnimalShelterDbContext DataBase;

        public PetRepository(AnimalShelterDbContext dataBase)
        {
            DataBase = dataBase;
        }

        public void Create(Pet pet)
        {
            DataBase.Pets.Add(pet);
            DataBase.SaveChanges();
        }

        public void Delete(int petId)
        {
            var petToDelete = Read(petId);
            DataBase.Pets.Remove(petToDelete);
            DataBase.SaveChanges();
        }

        public Pet Read(int petId)
        {
            return DataBase.Pets.FirstOrDefault(p => p.PetId == petId);
        }

        public IQueryable<Pet> ReadAll()
        {
            return DataBase.Pets;
        }

        public void Update(Pet pet)
        {
            var oldPet = Read(pet.PetId);
            oldPet.PetId = pet.PetId;
            oldPet.Type = pet.Type;
            oldPet.Age = pet.Age;
            oldPet.ReceptionDate = pet.ReceptionDate;
            DataBase.SaveChanges();
        }
    }
}
