using System.Linq;
using I0OGPS_HFT_2021221.Models;

namespace I0OGPS_HFT_2021221.Repository
{
    public interface IPetRepository
    {
        void Create(Pet pet);

        void Delete(int petId);

        Pet Read(int petId);

        IQueryable<Pet> GetAll();

        void Update(Pet pet);
    }
}
