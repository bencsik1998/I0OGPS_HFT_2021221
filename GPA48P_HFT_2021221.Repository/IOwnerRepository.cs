using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Repository
{
    public interface IOwnerRepository
    {
        void Create(Owner owner);

        void Delete(int ownerId);

        Owner Read(int ownerId);

        IQueryable<Owner> GetAll();

        void Update(Owner owner);
    }
}
