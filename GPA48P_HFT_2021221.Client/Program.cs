using ConsoleTools;
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

            AnimalShelter animalShelter = new AnimalShelter();
            Owner owner = new Owner();
            Pet pet = new Pet();

            var subMenu = new ConsoleMenu(args, level: 1)
                .Add("Sub_One", () => rest.Post(new AnimalShelter(), "animalshelter"))
                .Add("Sub_Two", () => rest.Post(new Owner(), "owner"))
                .Add("Sub_Three", () => rest.Post(new Pet(), "pet"))
                .Add("Sub_Four", () => rest.Get<AnimalShelter>("animalshelter"))
                .Add("Sub_Five", () => rest.Get<Owner>("owner"))
                .Add("Sub_Six", () => rest.Get<Pet>("pet"))
                .Add("Sub_Seven", () => rest.Put(animalShelter,"animalshelter"))
                .Add("Sub_Eight", () => rest.Put(owner, "owner"))
                .Add("Sub_Nine", () => rest.Put(pet, "pet"))
                .Add("Sub_Ten", () => rest.Delete(animalShelter.ShelterId, "animalshelter"))
                .Add("Sub_Eleven", () => rest.Delete(owner.OwnerId, "owner"))
                .Add("Sub_Twelve", () => rest.Delete(pet.PetId, "pet"))
                // var AvarageAgeOfPets = rest.GetSingle<double>("/stat/avarageageofpets");
                .Add("Sub_Thirteen", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Submenu";
                    config.EnableBreadcrumb = true;
                    config.WriteBreadcrumbAction = titles =>
                        Console.WriteLine(string.Join(" / ", titles));
                });

            var menu = new ConsoleMenu(args, level: 0)
                .Add("One", () => rest.Post(new AnimalShelter(), "animalshelter"))
                .Add("Two", () => rest.Post(new Owner(), "owner"))
                .Add("Three", () => rest.Post(new Pet(), "pet"))
                .Add("Four", () => rest.Get<AnimalShelter>("animalshelter"))
                .Add("Five", () => rest.Get<Owner>("owner"))
                .Add("Six", () => rest.Get<Pet>("pet"))
                .Add("Seven", () => rest.Put(animalShelter, "animalshelter"))
                .Add("Eight", () => rest.Put(owner, "owner"))
                .Add("Nine", () => rest.Put(pet, "pet"))
                .Add("Ten", () => rest.Delete(animalShelter.ShelterId, "animalshelter"))
                .Add("Eleven", () => rest.Delete(owner.OwnerId, "owner"))
                .Add("Twelve", () => rest.Delete(pet.PetId, "pet"))
                // var AvarageAgeOfPets = rest.GetSingle<double>("/stat/avarageageofpets");
                .Add("Sub", subMenu.Show)
                .Add("Change me", (thisMenu) => thisMenu.CurrentItem.Name = "I am changed!")
                .Add("Close", ConsoleMenu.Close)
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Main menu";
                    config.EnableWriteTitle = true;
                    config.EnableBreadcrumb = true;
                });

            menu.Show();
        }
    }
}
