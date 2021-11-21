using System;
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
        PetLogic petLogic;

        [SetUp]
        public void Init()
        {
            var mockPetRepsitory = new Mock<IPetRepository>();

            AnimalShelter fakeShelter = new AnimalShelter();
            fakeShelter.ShelterId = 1;
            fakeShelter.SheltertName = "asd";
            fakeShelter.Address = "1082, Budapest, Anya u. 2";
            fakeShelter.PhoneNumber = "06209871234";
            fakeShelter.TaxNumber = "18543221";

            var pets = new List<Pet>()
            {
                new Pet()
                {
                    PetId = 1,
                    Class = "Kutya",
                    Type = "Labrador",
                    Age =2,
                    ReceptionDate = new DateTime(2019,7,13)
                },
                new Pet()
                {
                    PetId = 2,
                    Class = "Macska",
                    Type = "Sziámi",
                    Age = 8,
                    ReceptionDate = new DateTime(2018,3,3)
                }
            }.AsQueryable();

            mockPetRepsitory.Setup((x) => x.ReadAll()).Returns(pets);

            petLogic = new PetLogic(mockPetRepsitory.Object);
        }

        [Test]
        public void AvarageAgeTest()
        {
            // ACT
            var avgResult = petLogic.AvarageAge();

            // ASSERT
            Assert.That(avgResult, Is.EqualTo(5));
        }

        [Test]
        public void Test2()
        {
            // ACT

            // ASSERT
        }

        [Test]
        public void Test3()
        {
            // ACT

            // ASSERT
        }

        [Test]
        public void Test4()
        {
            // ACT

            // ASSERT
        }

        [Test]
        public void Test5()
        {
            // ACT

            // ASSERT
        }
    }
}
