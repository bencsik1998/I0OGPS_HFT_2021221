using GPA48P_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA48P_HFT_2021221.Data
{
    public class AnimalShelterDbContext : DbContext
    {
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<AnimalShelter> AnimalShelters { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }

        public AnimalShelterDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                // a mindenkori munkakönyvtárban lévő lokális adatbázis fájlhoz kapcsolódik
                string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                    AttachDbFilename=|DataDirectory|\Database1.mdf;
                                    Integrated Security=True";
                builder.UseLazyLoadingProxies().UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(entity =>
            {
                entity
                .HasMany(owner => owner.Pets)
                .WithOne(pet => pet.Owner)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AnimalShelter>(entity =>
            {
                entity
                .HasMany(shelter => shelter.Pets)
                .WithOne(pet => pet.AnimalShelter)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity
                .HasOne(pet => pet.Owner)
                .WithMany(owner => owner.Pets)
                .HasForeignKey(pet => pet.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

                entity
                .HasOne(pet => pet.AnimalShelter)
                .WithMany(shelter => shelter.Pets)
                .HasForeignKey(pet => pet.ShelterId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            //-----------
            //   Owners
            //-----------

            Owner owner1 = new Owner()
            {
                OwnerId = 1,
                FirstName = "János",
                LastName = "Lézer",
                Address = "Székesfehérvár, Fekete u. 1, 8000",
                PhoneNumber = 06202349876
            };

            Owner owner2 = new Owner()
            {
                OwnerId = 2,
                FirstName = "Béla",
                LastName = "Vas",
                Address = "Győr, Fehér u. 15, 9000",
                PhoneNumber = 06305331203
            };

            Owner owner3 = new Owner()
            {
                OwnerId = 2,
                FirstName = "Béla",
                LastName = "Vas",
                Address = "Debrecen, Zöld u. 9, 4000",
                PhoneNumber = 06704339812
            };

            //---------------------
            //   Animal shelters
            //---------------------

            AnimalShelter shelter1 = new AnimalShelter()
            {
                ShelterId = 1,
                SheltertName = "Menhely Alapítvány",
                Address = "Budapest, Vajdahunyad u. 3, 1082",
                PhoneNumber = 06202349876,
                TaxNumber = 19013213142
            };
            
            AnimalShelter shelter2 = new AnimalShelter()
            {
                ShelterId = 2,
                SheltertName = "Állatmentő Sereg",
                Address = "Budapest, Nagymező u. 8, 1065",
                PhoneNumber = 06304564321,
                TaxNumber = 18334461142
            };

            AnimalShelter shelter3 = new AnimalShelter()
            {
                ShelterId = 3,
                SheltertName = "Cicamentő angyalok",
                Address = "Budapest, Lipót u. 12, 1074",
                PhoneNumber = 06709871234,
                TaxNumber = 17816385193
            };

            //----------
            //   Pets
            //----------

            Pet pet1 = new Pet()
            {
                PetId = 1,
                Class = "Kutya",
                Type = "Terrier",
                Age = 4,
                ReceptionDate = new DateTime(2007,1,30),
                OwnerId = owner1.OwnerId,
                ShelterId = shelter1.ShelterId
            };

            Pet pet2 = new Pet()
            {
                PetId = 2,
                Class = "Kutya",
                Type = "Border Collie",
                Age = 7, ReceptionDate = new DateTime(2004,3,27),
                OwnerId = owner2.OwnerId,
                ShelterId = shelter2.ShelterId
            };

            Pet pet3 = new Pet()
            {
                PetId = 3,
                Class = "Macska",
                Type = "Ragdoll",
                Age = 2,
                ReceptionDate = new DateTime(2019,2,12),
                OwnerId = owner1.OwnerId,
                ShelterId = shelter2.ShelterId
            };

            Pet pet4 = new Pet()
            {
                PetId = 4,
                Class = "Macska",
                Type = "Sziámi",
                Age = 11, ReceptionDate = new DateTime(2010,4,19),
                OwnerId = owner2.OwnerId,
                ShelterId = shelter1.ShelterId
            };

            Pet pet5 = new Pet()
            {
                PetId = 5,
                Class = "Kutya",
                Type = "Papagáj",
                Age = 1, ReceptionDate = new DateTime(2020,8,23),
                OwnerId = owner3.OwnerId,
                ShelterId = shelter3.ShelterId
            };

            Pet pet6 = new Pet()
            {
                PetId = 6,
                Class = "Macska",
                Type = "Pinty",
                Age = 3,
                ReceptionDate = new DateTime(2018,7,9),
                OwnerId = owner1.OwnerId,
                ShelterId = shelter3.ShelterId
            };

            Pet pet7 = new Pet()
            {
                PetId = 7,
                Class = "Kutya",
                Type = "Rottweiler",
                Age = 7,
                ReceptionDate = new DateTime(2016, 3, 12),
                OwnerId = owner2.OwnerId,
                ShelterId = shelter1.ShelterId
            };

            Pet pet8 = new Pet()
            {
                PetId = 8,
                Class = "Macska",
                Type = "Abesszin",
                Age = 4,
                ReceptionDate = new DateTime(2021, 8, 1),
                OwnerId = owner1.OwnerId,
                ShelterId = shelter3.ShelterId
            };

            Pet pet9 = new Pet()
            {
                PetId = 9,
                Class = "Kutya",
                Type = "Beagle",
                Age = 9,
                ReceptionDate = new DateTime(2011, 3, 21),
                OwnerId = owner2.OwnerId,
                ShelterId = shelter2.ShelterId
            };

            Pet pet10 = new Pet()
            {
                PetId = 10,
                Class = "Macska",
                Type = "Burma",
                Age = 5,
                ReceptionDate = new DateTime(2016, 12, 22),
                OwnerId = owner3.OwnerId,
                ShelterId = shelter3.ShelterId
            };

            modelBuilder.Entity<Owner>().HasData(owner1, owner2, owner3);
            modelBuilder.Entity<AnimalShelter>().HasData(shelter1, shelter2, shelter3);
            modelBuilder.Entity<Pet>().HasData(pet1, pet2, pet3, pet4, pet5, pet6, pet7, pet8, pet9, pet10);
        }
    }
}
