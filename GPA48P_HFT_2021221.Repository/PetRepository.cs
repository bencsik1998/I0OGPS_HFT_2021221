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
        AnimalShelterDbContext dataBase;

        public PetRepository(AnimalShelterDbContext dataBase)
        {
            this.dataBase = dataBase;
        }

        public void Create(Pet pet)
        {
            dataBase.Pets.Add(pet);
            dataBase.SaveChanges();
        }

        public void Delete(int petId)
        {
            var petToDelete = Read(petId);
            dataBase.Pets.Remove(petToDelete);
            dataBase.SaveChanges();
        }

        public Pet Read(int petId)
        {
            return dataBase.Pets.FirstOrDefault(p => p.PetId == petId);
        }

        public IQueryable<Pet> ReadAll()
        {
            return dataBase.Pets;
        }

        public void Update(Pet pet)
        {
            var oldPet = Read(pet.PetId);
            oldPet.PetId = pet.PetId;
            oldPet.Type = pet.Type;
            oldPet.Age = pet.Age;
            oldPet.ReceptionDate = pet.ReceptionDate;
            dataBase.SaveChanges();
        }
    }
}
