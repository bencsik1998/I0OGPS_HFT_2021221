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
        AnimalShelterLogic animalShelterLogic;
        Owner ownerLogic;
        Pet petLogic;

        public void Init()
        {
            var mockAnimalShelterRepository = new Mock<IAnimalShelterRepository>();
        }
    }
}
