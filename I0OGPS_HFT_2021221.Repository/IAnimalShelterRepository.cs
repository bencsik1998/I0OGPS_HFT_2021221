using System.Linq;
using I0OGPS_HFT_2021221.Models;

namespace I0OGPS_HFT_2021221.Repository
{
    public interface IAnimalShelterRepository
    {
        void Create(AnimalShelter animalShelter);

        void Delete(int shelterId);

        AnimalShelter Read(int shelterId);

        IQueryable<AnimalShelter> GetAll();

        void Update(AnimalShelter animalShelter);
    }
}
