using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Data;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        AnimalShelterDbContext DataBase;

        public OwnerRepository(AnimalShelterDbContext dataBase)
        {
            DataBase = dataBase;
        }

        public void Create(Owner owner)
        {
            DataBase.Owners.Add(owner);
            DataBase.SaveChanges();
        }

        public void Delete(int ownerId)
        {
            var ownerToDelete = Read(ownerId);
            DataBase.Owners.Remove(ownerToDelete);
            DataBase.SaveChanges();
        }

        public Owner Read(int ownerId)
        {
            return DataBase.Owners.FirstOrDefault(o => o.OwnerId == ownerId);
        }

        public IQueryable<Owner> ReadAll()
        {
            return DataBase.Owners;
        }

        public void Update(Owner owner)
        {
            var oldOwner = Read(owner.OwnerId);
            oldOwner.FirstName = owner.FirstName;
            oldOwner.LastName = owner.LastName;
            oldOwner.Address = owner.Address;
            oldOwner.PhoneNumber = owner.PhoneNumber;
            DataBase.SaveChanges();
        }
    }
}
