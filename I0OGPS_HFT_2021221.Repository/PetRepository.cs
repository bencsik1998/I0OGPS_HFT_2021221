using System.Linq;
using I0OGPS_HFT_2021221.Data;
using I0OGPS_HFT_2021221.Models;

namespace I0OGPS_HFT_2021221.Repository
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

        public IQueryable<Pet> GetAll()
        {
            return dataBase.Pets;
        }

        public void Update(Pet pet)
        {
            var oldPet = Read(pet.PetId);
            oldPet.Class = pet.Class;
            oldPet.Type = pet.Type;
            oldPet.Age = pet.Age;
            oldPet.AdoptionYear = pet.AdoptionYear;
            oldPet.ShelterId = pet.ShelterId;
            oldPet.OwnerId = pet.OwnerId;
            dataBase.SaveChanges();
        }
    }
}
