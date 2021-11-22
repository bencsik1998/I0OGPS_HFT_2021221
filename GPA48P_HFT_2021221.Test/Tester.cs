﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Logic;
using GPA48P_HFT_2021221.Models;
using GPA48P_HFT_2021221.Repository;
using NUnit.Framework;
using Moq;

namespace GPA48P_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        AnimalShelterLogic animalShelterLogic;
        OwnerLogic ownerLogic;
        PetLogic petLogic;

        IEnumerable<AvarageAgeOfDogsAtAllShelters> AvarageAgeOfDogsAtAllSheltersList;

        [SetUp]
        public void Init()
        {
            var mockAnimalShelterRepository = new Mock<IAnimalShelterRepository>();
            var mockOwnerRepository = new Mock<IOwnerRepository>();
            var mockPetRepsitory = new Mock<IPetRepository>();

            var pets = new List<Pet>()
            {
                new Pet()
                {
                    PetId = 1, Class = "Kutya", Type = "Labrador", Age = 2, ReceptionDate = new DateTime(2019,7,11), ShelterId = 1, OwnerId = 1
                },
                new Pet()
                {
                    PetId = 2, Class = "Kutya", Type = "Border collie", Age = 4, ReceptionDate = new DateTime(2018,6,21), ShelterId = 1, OwnerId = 1
                },
                new Pet()
                {
                    PetId = 3, Class = "Kutya", Type = "Beagle", Age = 6, ReceptionDate = new DateTime(2017,8,31), ShelterId = 1, OwnerId = 1
                },
                new Pet()
                {
                    PetId = 4, Class = "Macska", Type = "Perzsa", Age = 8, ReceptionDate = new DateTime(2015,3,5), ShelterId = 2, OwnerId = 2
                },
                new Pet()
                {
                    PetId = 5, Class = "Macska", Type = "Bengáli", Age = 10, ReceptionDate = new DateTime(2014,5,23), ShelterId = 3, OwnerId = 3
                },
                new Pet()
                {
                    PetId = 6, Class = "Macska", Type = "Szfinx", Age = 12, ReceptionDate = new DateTime(2013,1,17), ShelterId = 2, OwnerId = 2
                }
            }.AsQueryable();

            var animalShelters = new List<AnimalShelter>()
            {
                new AnimalShelter()
                {
                    ShelterId = 1, SheltertName = "Menhely1", Address = "New York", PhoneNumber = "06709871234", TaxNumber = "18942873562",
                    Pets = pets.Where(x => x.ShelterId.Equals(1)).ToList()
                },
                new AnimalShelter()
                {
                    ShelterId = 2, SheltertName = "Menhely2", Address = "Tokió", PhoneNumber = "06209128456", TaxNumber = "19371496731",
                    Pets = pets.Where(x => x.ShelterId.Equals(2)).ToList()
                },
                new AnimalShelter()
                {
                    ShelterId = 3, SheltertName = "Menhely3", Address = "Peking", PhoneNumber = "06306541298", TaxNumber = "19285239871",
                    Pets = pets.Where(x => x.ShelterId.Equals(3)).ToList()
                }
            }.AsQueryable();

            var owners = new List<Owner>()
            {
                new Owner()
                {
                    OwnerId = 1, FirstName = "János", LastName = "Fekete", Address = "London", PhoneNumber = "06201239876", Age = 10,
                    Pets = pets.Where(x => x.ShelterId.Equals(1)).ToList()
                },
                new Owner()
                {
                    OwnerId = 2, FirstName = "Dániel", LastName = "Borzavári", Address = "Los Angeles", PhoneNumber = "06304561298", Age = 20,
                    Pets = pets.Where(x => x.ShelterId.Equals(2)).ToList()
                },
                new Owner()
                {
                    OwnerId = 3, FirstName = "Norbert", LastName = "Tóth", Address = "Párizs", PhoneNumber = "06709871234", Age = 30,
                    Pets = pets.Where(x => x.ShelterId.Equals(3)).ToList()
                }
            }.AsQueryable();

            AvarageAgeOfDogsAtAllSheltersList = new List<AvarageAgeOfDogsAtAllShelters>()
            {
                new AvarageAgeOfDogsAtAllShelters
                {
                    ShelterName = "Menhely1", AvarageAge = 4
                },
                new AvarageAgeOfDogsAtAllShelters
                {
                    ShelterName = "Menhely2", AvarageAge = 0
                },
                new AvarageAgeOfDogsAtAllShelters
                {
                    ShelterName = "Menhely3", AvarageAge = 0
                }
            };

            mockAnimalShelterRepository.Setup((x) => x.ReadAll()).Returns(animalShelters);
            mockOwnerRepository.Setup((x) => x.ReadAll()).Returns(owners);
            mockPetRepsitory.Setup((x) => x.ReadAll()).Returns(pets);

            animalShelterLogic = new AnimalShelterLogic(mockAnimalShelterRepository.Object);
            ownerLogic = new OwnerLogic(mockOwnerRepository.Object);
            petLogic = new PetLogic(mockPetRepsitory.Object);
        }

        [Test]
        public void AvarageAgeTest()
        {
            // ACT
            double result = petLogic.AvarageAge();

            // ASSERT
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void AvarageAgeByPetsAtOneShelterTest()
        {
            // ACT
            double result = animalShelterLogic.AvarageAgeByPetsAtOneShelter(1);

            // ASSERT
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void AvarageAgeOfDogsAtAllShelters()
        {
            // ACT
            var result = animalShelterLogic.AvarageAgeOfDogsAtAllShelters().ToList();

            // ASSERT
            Assert.IsTrue(CompareElement(result, AvarageAgeOfDogsAtAllSheltersList));
        }

        private bool CompareElement(IEnumerable<AvarageAgeOfDogsAtAllShelters> e, IEnumerable<AvarageAgeOfDogsAtAllShelters> l)
        {
            if (e.Count() != l.Count())
            {
                return false;
            }
            else if (e.Count() > 0)
            {
                foreach (var item in e)
                {
                    if (!l.Any(x => x.AvarageAge == item.AvarageAge && x.ShelterName == item.ShelterName))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        [Test]
        public void DogsOfOwnerTest()
        {
            // ACT
            var result = ownerLogic.DogsOfOwner(2);

            // ASSERT
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public void MostCatsAdoptedByTest()
        {
            // ACT
            var result = ownerLogic.MostCatsAdoptedBy();

            // ASSERT
            Assert.That(result.OwnerId, Is.EqualTo(2));
        }

        // Ide még kell egy többtáblás non-crud tesztelés
        [Test]
        public void Test6()
        {
            // ACT

            // ASSERT
        }

        // Create crud metódus tesztelés
        [Test]
        public void Test7()
        {
            // ACT

            // ASSERT
        }

        // Create crud metódus tesztelés
        [Test]
        public void Test8()
        {
            // ACT

            // ASSERT
        }

        // Create crud metódus tesztelés
        [Test]
        public void Test9()
        {
            // ACT

            // ASSERT
        }

        // Create crud metódus tesztelés
        [Test]
        public void Test10()
        {
            // ACT

            // ASSERT
        }
    }
}