using System.Collections.Generic;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Logic
{
    public interface IOwnerLogic
    {
        void Create(Owner owner);

        void Delete(int ownerId);

        Owner Read(int ownerId);

        IEnumerable<Owner> GetAll();

        void Update(Owner owner);

        IEnumerable<Pet> DogsOfOwner(int ownerId);

        Owner MostCatsAdoptedBy();
    }
}
