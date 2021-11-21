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
            if (owner.FirstName.Length < 3 && owner.LastName.Length < 3)
            {
                throw new Exception("A kereszt- és vezetéknév nem lehet 3 karakternél rövidebb!");
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
