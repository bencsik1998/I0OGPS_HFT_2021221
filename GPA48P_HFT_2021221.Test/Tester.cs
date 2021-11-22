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

            var pets = new List<Pet>()
            {
                new Pet()
                {
                    PetId = 1, Class = "Kutya", Type = "Labrador", Age =2, ReceptionDate = new DateTime(2019,7,11)
                },
                new Pet()
                {
                    PetId = 2, Class = "Macska", Type = "Sziámi", Age = 4, ReceptionDate = new DateTime(2018,6,21)
                },
                new Pet()
                {
                    PetId = 3, Class = "Kutya", Type = "Beagle", Age = 6, ReceptionDate = new DateTime(2017,8,31)
                },
                new Pet()
                {
                    PetId = 4, Class = "Macska", Type = "Perzsa", Age = 8, ReceptionDate = new DateTime(2016,9,1)
                }
            }.AsQueryable();

            mockPetRepsitory.Setup((x) => x.ReadAll()).Returns(pets);

            petLogic = new PetLogic(mockPetRepsitory.Object);
        }

        [Test]
        public void AvarageAgeTest()
        {
            // ACT
            double avgResult = petLogic.AvarageAge();

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

        [Test]
        public void Test6()
        {
            // ACT

            // ASSERT
        }

        [Test]
        public void Test7()
        {
            // ACT

            // ASSERT
        }

        [Test]
        public void Test8()
        {
            // ACT

            // ASSERT
        }

        [Test]
        public void Test9()
        {
            // ACT

            // ASSERT
        }

        [Test]
        public void Test10()
        {
            // ACT

            // ASSERT
        }
    }
}
