using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GPA48P_HFT_2021221.Models;
using I0OGPS_HFT_2021221.WPFClient;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace I0OGPS_HFT_2021221.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<AnimalShelter> AnimalShelters { get; set; }

        public RestCollection<Owner> Owners { get; set; }

        public RestCollection<Pet> Pets { get; set; }

        public AnimalShelter AnimalShelterSel
        {
            get { return animalShelterSel; }
            set
            {
                if (value != null)
                {
                    animalShelterSel = new AnimalShelter() { ShelterId = value.ShelterId, ShelterName = value.ShelterName, TaxNumber = value.TaxNumber, Address = value.Address, PhoneNumber = value.PhoneNumber };
                    OnPropertyChanged();
                    ((RelayCommand)DelAnimalShelterCommand).NotifyCanExecuteChanged();
                } 
            } 
        }

        public Owner OwnerSel
        {
            get { return ownerSel; }
            set
            {
                if (value != null)
                {
                    ownerSel = new Owner() { FirstName = value.FirstName, LastName = value.LastName, Age = value.Age, Address = value.Address, PhoneNumber = value.PhoneNumber, OwnerId = value.OwnerId };
                    OnPropertyChanged();
                    ((RelayCommand)DelOwnerCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public Pet PetSel
        {
            get { return petSel; }
            set
            {
                if (value != null)
                {
                    petSel = new Pet() { Class = value.Class, Type = value.Type, Age = value.Age, AdoptionYear = value.AdoptionYear, ShelterId = value.ShelterId, OwnerId = value.OwnerId, PetId = value.PetId };
                    OnPropertyChanged();
                    ((RelayCommand)DelPetCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private AnimalShelter animalShelterSel;
        private Owner ownerSel;
        private Pet petSel;

        public ICommand CreateAnimalShelterCommand { get; set; }
        public ICommand UpdateAnimalShelterCommand { get; set; }
        public ICommand DelAnimalShelterCommand { get; set; }

        public ICommand CreateOwnerCommand { get; set; }
        public ICommand UpdateOwnerCommand { get; set; }
        public ICommand DelOwnerCommand { get; set; }

        public ICommand CreatePetCommand { get; set; }
        public ICommand UpdatePetCommand { get; set; }
        public ICommand DelPetCommand { get; set; }

        public static bool DesignModeTrue
        {
            get
            {
                var property = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(property, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!DesignModeTrue)
            {
                AnimalShelters = new RestCollection<AnimalShelter>("http://localhost:57343/", "animalshelter");
                Owners = new RestCollection<Owner>("http://localhost:57343/", "owner");
                Pets = new RestCollection<Pet>("http://localhost:57343/", "pet");

                CreateAnimalShelterCommand = new RelayCommand(() =>
                {
                    AnimalShelters.Add(new AnimalShelter()
                    {
                        ShelterName = AnimalShelterSel.ShelterName,
                        Address = AnimalShelterSel.Address,
                        PhoneNumber = AnimalShelterSel.PhoneNumber,
                        TaxNumber = AnimalShelterSel.TaxNumber
                    });
                });

                UpdateAnimalShelterCommand = new RelayCommand(() =>
                {
                    AnimalShelters.Update(AnimalShelterSel);
                });

                DelAnimalShelterCommand = new RelayCommand(() =>
                {
                    AnimalShelters.Delete(AnimalShelterSel.ShelterId);
                },
                () =>
                {
                    return AnimalShelterSel != null;
                });

                AnimalShelterSel = new AnimalShelter();

                // Owner Relay

                CreateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Add(new Owner()
                    {
                        FirstName = OwnerSel.FirstName,
                        LastName = OwnerSel.LastName,
                        Address = OwnerSel.Address,
                        PhoneNumber = OwnerSel.PhoneNumber,
                        Age = OwnerSel.Age
                    });
                });

                UpdateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Update(OwnerSel);
                });

                DelOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Delete(OwnerSel.OwnerId);
                },
                () =>
                {
                    return OwnerSel != null;
                });

                OwnerSel = new Owner();

                //--------------------
                // Pet Relay Commands
                //--------------------

                CreatePetCommand = new RelayCommand(() =>
                {
                    Pets.Add(new Pet()
                    {
                        Class = PetSel.Class,
                        Type = PetSel.Type,
                        Age = PetSel.Age,
                        AdoptionYear = PetSel.AdoptionYear,
                        ShelterId = PetSel.ShelterId,
                        OwnerId = PetSel.OwnerId
                    });
                });

                UpdatePetCommand = new RelayCommand(() =>
                {
                    Pets.Update(PetSel);
                });

                DelPetCommand = new RelayCommand(() =>
                {
                    Pets.Delete(PetSel.PetId);
                },
                () =>
                {
                    return PetSel != null;
                });

                PetSel = new Pet();
            }
        }
    }
}
