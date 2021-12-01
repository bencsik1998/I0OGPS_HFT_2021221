using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPA48P_HFT_2021221.Models;

namespace GPA48P_HFT_2021221.Client
{
    public class ConsoleMenu
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("|---------------------------------------------------|");
            Console.WriteLine("| Choose an option:                                 |");
            Console.WriteLine("| 1) Create a new animal shelter                    |");
            Console.WriteLine("| 2) Create a new owner                             |");
            Console.WriteLine("| 3) Create a new pet                               |");
            Console.WriteLine("| 4) Read an existing animal shelter                |");
            Console.WriteLine("| 5) Read an existing owner                         |");
            Console.WriteLine("| 6) Read an existing pet                           |");
            Console.WriteLine("| 7) Update an existing animal shelter              |");
            Console.WriteLine("| 8) Update an existing owner                       |");
            Console.WriteLine("| 9) Update an existing pet                         |");
            Console.WriteLine("| 10) Delete an existing animal shelter             |");
            Console.WriteLine("| 11) Delete an existing owner                      |");
            Console.WriteLine("| 12) Delete an existing pet                        |");
            Console.WriteLine("| 13) View the pets avarage age in a shelter by ID  |");
            Console.WriteLine("| 14) View the dogs avarage age at all shelters     |");
            Console.WriteLine("| 15) View how much dogs have an owner by ID        |");
            Console.WriteLine("| 16) View which owner adopted the most cats        |");
            Console.WriteLine("| 17) View how much the avarage age of all pets     |");
            Console.WriteLine("| 17) IDE MÉG KELL MAJD VALMILYEN NON CRUD          |");
            Console.WriteLine("| x) Exit                                           |");
            Console.WriteLine("|---------------------------------------------------|");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateAnimalShelter();
                    break;
                case "2":
                    CreateOwner();
                    break;
                case "3":
                    CreatePet();
                    break;
                case "x":
                    Exit();
                    break;
                default:
                    break;
            }
        }

        public static void CreateAnimalShelter()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:62480");
            Console.Write("New animal shelter name: ");
            string shelterName = Console.ReadLine();
            Console.Write("New animal shelter address: ");
            string address = Console.ReadLine();
            Console.Write("New animal shelter phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("New animal shelter tax number: ");
            string taxNumber = Console.ReadLine();

            rest.Post(new AnimalShelter
            {
                SheltertName = shelterName,
                Address = address,
                PhoneNumber = phoneNumber,
                TaxNumber = taxNumber
            }, "animalshelter");

            Console.WriteLine("Animal shelter created successfully");
            Console.WriteLine("Press enter to jump back to main menu");
            Console.ReadLine();

            MainMenu();
        }

        public static void CreateOwner()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:62480");
            Console.Write("New owner first name: ");
            string firstName = Console.ReadLine();
            Console.Write("New owner last name: ");
            string lastName = Console.ReadLine();
            Console.Write("New owner address: ");
            string address = Console.ReadLine();
            Console.Write("New owner phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("New owner age: ");
            int age = int.Parse(Console.ReadLine());

            rest.Post(new Owner
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                PhoneNumber = phoneNumber,
                Age = age
            }, "owner");

            Console.WriteLine("Owner created successfully");
            Console.WriteLine("Press enter to jump back to main menu");
            Console.ReadLine();

            MainMenu();
        }

        public static void CreatePet()
        {
            Console.Clear();
            RestService rest = new RestService("http://localhost:62480");
            Console.Write("New pet class: ");
            string cLass = Console.ReadLine();
            Console.Write("New pet type: ");
            string type = Console.ReadLine();
            Console.Write("New pet age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("New pet reception date: ");
            DateTime receptionDate = DateTime.Parse(Console.ReadLine());
            Console.Write("New pet's owner ID: ");
            int ownerId = int.Parse(Console.ReadLine());
            Console.Write("New pet's animal shelter ID: ");
            int shelterId = int.Parse(Console.ReadLine());

            rest.Post(new Pet
            {
                Class = cLass,
                Type = type,
                Age = age,
                ReceptionDate = receptionDate,
                OwnerId = ownerId,
                ShelterId = shelterId
            }, "pet");

            Console.WriteLine("Pet created successfully");
            Console.WriteLine("Press enter to jump back to main menu");
            Console.ReadLine();

            MainMenu();
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
