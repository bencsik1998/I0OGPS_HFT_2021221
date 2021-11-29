using GPA48P_HFT_2021221.Models;
using System;

namespace GPA48P_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);

            RestService rest = new RestService("http://localhost:62480");

            rest.Post<Pet>(new Pet()
            {
                Class = "Madár"
            }, "pet");

            rest.Post<Owner>(new Owner()
            {
                FirstName = "Jancsika"
            }, "owner");

            var pets = rest.Get<Pet>("pet");
            var animalShelters = rest.Get<AnimalShelter>("animalShelter");
            var owners = rest.Get<Owner>("owner");

            var AvarageAgeOfPets = rest.GetSingle<double>("/stat/avarageageofpets");

            ;
        }
    }
}
