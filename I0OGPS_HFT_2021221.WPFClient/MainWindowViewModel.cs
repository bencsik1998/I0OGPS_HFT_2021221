using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using I0OGPS_HFT_2021221.Models;
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

        public RestService StatService { get; set; }

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

        public ICommand GetAvgAgeOfAllPets { get; set; }
        public ICommand GetAvgAgeOfDogsInAllShelters { get; set; }
        public ICommand GetMostCatsAdoptedBy { get; set; }
        public ICommand GetWhichOwnersAdoptedPetBefore2015 { get; set; }
        public ICommand GetDogsOfOwner { get; set; }
        public ICommand GetAvarageAgeByPetsAtOneShelter { get; set; }

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
                AnimalShelters = new RestCollection<AnimalShelter>("http://localhost:62480/", "animalshelter");
                Owners = new RestCollection<Owner>("http://localhost:62480/", "owner");
                Pets = new RestCollection<Pet>("http://localhost:62480/", "pet");
                StatService = new RestService("http://localhost:62480/");

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

                // non crud queries

                // for animal shelter
                GetAvgAgeOfDogsInAllShelters = new RelayCommand(() =>
                {
                    List<AvarageAgeOfDogsAtAllShelters> results = StatService.Get<AvarageAgeOfDogsAtAllShelters>("stat/avarageageofdogsatallshelters");
                    string resultShelters = String.Empty;
                    foreach (AvarageAgeOfDogsAtAllShelters shelter in results)
                    {
                        resultShelters += shelter.ShelterName + "\t" + shelter.AvarageAge + "\n";
                    }
                    MessageBox.Show($"Avarage age of dogs at all shelters: \n {resultShelters}");
                });

                // for owners
                GetWhichOwnersAdoptedPetBefore2015 = new RelayCommand(() =>
                {
                    List<string> results = StatService.Get<string>("stat/whichownersadoptedpetbefore2015");

                    string resultOwners = String.Empty;
                    foreach (string owner in results)
                    {
                        resultOwners += owner + "\n";
                    }

                    MessageBox.Show($"Owners who adopted pets before 2015: \n{resultOwners}");
                });

                GetMostCatsAdoptedBy = new RelayCommand(() =>
                {
                    Owner ownerResult = StatService.GetSingle<Owner>("stat/mostcatsadoptedby");
                    MessageBox.Show($"The owner who adopted the most cats: {ownerResult.LastName} {ownerResult.FirstName}");
                });

                GetDogsOfOwner = new RelayCommand(() =>
                {
                    int selectedOwnerId = OwnerSel.OwnerId;

                    List<Pet> result = StatService.Get<Pet>($"stat/dogsofowner/{selectedOwnerId}");

                    string resultPets = String.Empty;

                    foreach (Pet pet in result)
                    {
                        resultPets += "-> " + pet.Type + "\n";
                    }

                    MessageBox.Show($"List of the dogs type:\n {resultPets}");
                });


                GetAvarageAgeByPetsAtOneShelter = new RelayCommand(() =>
                {
                    int selectedShelterId = AnimalShelterSel.ShelterId;

                    double result = StatService.GetSingle<double>($"stat/avarageagebypetsatoneshelter/{selectedShelterId}");

                    MessageBox.Show($"The pets avarage age in selected shelter: {result}");
                });
            }
        }
    }
}
