using System.Linq;
using GPA48P_HFT_2021221.Data;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        AnimalShelterDbContext dataBase;

        public OwnerRepository(AnimalShelterDbContext dataBase)
        {
            this.dataBase = dataBase;
        }

        public void Create(Owner owner)
        {
            dataBase.Owners.Add(owner);
            dataBase.SaveChanges();
        }

        public void Delete(int ownerId)
        {
            var ownerToDelete = Read(ownerId);
            dataBase.Owners.Remove(ownerToDelete);
            dataBase.SaveChanges();
        }

        public Owner Read(int ownerId)
        {
            return dataBase.Owners.FirstOrDefault(o => o.OwnerId == ownerId);
        }

        public IQueryable<Owner> GetAll()
        {
            return dataBase.Owners;
        }

        public void Update(Owner owner)
        {
            var oldOwner = Read(owner.OwnerId);
            oldOwner.OwnerId = owner.OwnerId;
            oldOwner.FirstName = owner.FirstName;
            oldOwner.LastName = owner.LastName;
            oldOwner.Address = owner.Address;
            oldOwner.PhoneNumber = owner.PhoneNumber;
            oldOwner.Age = owner.Age;
            dataBase.SaveChanges();
        }
    }
}
