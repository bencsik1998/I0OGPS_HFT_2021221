using System.Linq;
using I0OGPS_HFT_2021221.Models;

namespace I0OGPS_HFT_2021221.Repository
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
