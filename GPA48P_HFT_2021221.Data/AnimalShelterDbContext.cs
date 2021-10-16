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
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                // a mindenkori munkakönyvtárban lévő lokális adatbázis fájlhoz kapcsolódik
                string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
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

            Owner owner1 = new Owner() { OwnerId = 1, FirstName = "János", LastName = "Lézer",
                                         Address = "1234 ", PhoneNumber = 06302349876 };

            Owner owner2 = new Owner() { OwnerId = 2, FirstName = "Béla", LastName = "Vas",
                                         Address = "1234 ", PhoneNumber = 06302349876 };

            AnimalShelter shelter1 = new AnimalShelter() { ShelterId = 1, SheltertName = "Menhely Alapítvány",
                                                           Address = "Budapest, Vajdahunyad u. 3, 1082",
                                                           PhoneNumber = 0613384186, TaxNumber = 19013213142 };
            
            AnimalShelter shelter2 = new AnimalShelter() { ShelterId = 2, SheltertName = "Állatmentő Sereg",
                                                           Address = "Budapest, Nagymező u. 8, 1065",
                                                           PhoneNumber = 0617217612, TaxNumber = 18334461142 };

            Pet pet1 = new Pet() { PetId = 1, Class = "Kutya", Type = "Terrier", Age = 4, ReceptionDate = new DateTime(2007,1,30),
                                   OwnerId = owner1.OwnerId, ShelterId = shelter1.ShelterId };
            Pet pet2 = new Pet() { PetId = 2, Class = "Kutya", Type = "Border Colie", Age = 7, ReceptionDate = new DateTime(2004,3,27),
                                   OwnerId = owner2.OwnerId, ShelterId = shelter2.ShelterId };
            Pet pet3 = new Pet() { PetId = 3, Class = "Cica", Type = "Ragdoll", Age = 2, ReceptionDate = new DateTime(2019,2,12),
                                   OwnerId = owner1.OwnerId, ShelterId = shelter2.ShelterId };
            Pet pet4 = new Pet() { PetId = 4, Class = "Cica", Type = "Sziámi", Age = 11, ReceptionDate = new DateTime(2010,4,19),
                                   OwnerId = owner2.OwnerId, ShelterId = shelter1.ShelterId };
            Pet pet5 = new Pet() { PetId = 5, Class = "Madár", Type = "Papagáj", Age = 1, ReceptionDate = new DateTime(2020,8,23),
                                   OwnerId = owner1.OwnerId, ShelterId = shelter1.ShelterId };
            Pet pet6 = new Pet() { PetId = 6, Class = "Madár", Type = "Pinty", Age = 3, ReceptionDate = new DateTime(2018,7,9),
                                   OwnerId = owner2.OwnerId, ShelterId = shelter2.ShelterId };

            modelBuilder.Entity<Owner>().HasData(owner1, owner2);
            modelBuilder.Entity<AnimalShelter>().HasData(shelter1, shelter2);
            modelBuilder.Entity<Pet>().HasData(pet1, pet2, pet3, pet4, pet5, pet6);
        }
    }
}
