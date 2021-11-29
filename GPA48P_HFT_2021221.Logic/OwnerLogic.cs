using System;
using System.Collections.Generic;
using System.Linq;
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
            if (owner.FirstName is null || owner.FirstName == "")
            {
                throw new Exception("A keresztnév nem lehet üres!");
            }
            else if (owner.LastName is null || owner.LastName == "")
            {
                throw new Exception("A vezetéknév nem lehet üres!");
            }
            else if (owner.FirstName.Length < 3)
            {
                throw new Exception("A keresztnév nem lehet 3 karakternél rövidebb!");
            }
            else if (owner.LastName.Length < 3)
            {
                throw new Exception("A vezetéknév nem lehet 3 karakternél rövidebb!");
            }
            else if (owner.Address is null || owner.Address == "")
            {
                throw new Exception("A cím nem lehet üres!");
            }
            else if (owner.PhoneNumber is null || owner.PhoneNumber == "")
            {
                throw new Exception("A telefonszám nem lehet üres!");
            }
            else if (owner.Age == 0)
            {
                throw new Exception("Az életkor nem lehet nulla!");
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

        public IEnumerable<Owner> GetAll()
        {
            return ownerRepository.GetAll();
        }

        public void Update(Owner owner)
        {
            ownerRepository.Update(owner);
        }

        // Megadott gazdi ID alapján nézzük meg, hogy hány kutyája van!
        public IEnumerable<Pet> DogsOfOwner(int ownerId)
        {
            var result = ownerRepository.GetAll()
                                            .SingleOrDefault(x => x.OwnerId
                                                .Equals(ownerId))
                                            .Pets.Where(x => x.Class
                                                .Equals("Kutya"));
            return result;
        }

        // Nézzük meg melyik gazdi fogadta örökbe a legtöbb macskát!
        public Owner MostCatsAdoptedBy()
        {
            var result = ownerRepository.GetAll()
                                        .OrderBy(x => x.Pets
                                            .Where(y => y.Class
                                                .Equals("Macska"))
                                            .Count())
                                        .Last();
            return result;
        }
    }
}
