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
        IOwnerRepository OwnerRepository;

        public OwnerLogic(IOwnerRepository ownerRepository)
        {
            OwnerRepository = ownerRepository;   
        }

        public void Create(Owner owner)
        {
            if (owner.FirstName.Length < 3 && owner.LastName.Length < 3)
            {
                throw new Exception("A kereszt- és vezetéknév nem lehet 3 karakternél rövidebb!");
            }
            OwnerRepository.Create(owner);
        }

        public void Delete(int ownerId)
        {
            OwnerRepository.Delete(ownerId);
        }

        public Owner Read(int ownerId)
        {
            return OwnerRepository.Read(ownerId);
        }

        public IEnumerable<Owner> ReadAll()
        {
            return OwnerRepository.ReadAll();
        }

        public void Update(Owner owner)
        {
            OwnerRepository.Update(owner);
        }
    }
}
