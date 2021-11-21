using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Models;
using GPA48P_HFT_2021221.Repository;

namespace GPA48P_HFT_2021221.Logic
{
    public class OwnerLogic : IOwnerLogic
    {
        IOwnerRepository ownerRepository;

        public OwnerLogic(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;   
        }

        public void Create(Owner owner)
        {
            if (owner.FirstName == "" && owner.LastName == "")
            {
                throw new Exception("A kereszt- és vezetéknév nem lehet üres!");
            }
            else if (owner.FirstName.Length < 3 && owner.LastName.Length < 3)
            {
                throw new Exception("A kereszt- és vezetéknév nem lehet 3 karakternél rövidebb!");
            }
            else if (owner.Address == "")
            {
                throw new Exception("A cím nem lehet üres!");
            }
            else if (owner.PhoneNumber == 0)
            {
                throw new Exception("A telefonszám nem lehet nulla!");
            }
            ownerRepository.Create(owner);
        }

        public void Delete(int ownerId)
        {
            ownerRepository.Delete(ownerId);
        }

        public Owner Read(int ownerId)
        {
            return ownerRepository.Read(ownerId);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return ownerRepository.ReadAll();
        }

        public void Update(Owner owner)
        {
            ownerRepository.Update(owner);
        }
    }
}
