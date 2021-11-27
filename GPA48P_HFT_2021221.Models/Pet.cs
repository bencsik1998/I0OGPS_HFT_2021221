using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GPA48P_HFT_2021221.Models
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PetId { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public DateTime ReceptionDate { get; set; }

        [NotMapped]
        public virtual Owner Owner { get; set; }

        [NotMapped]
        public virtual AnimalShelter AnimalShelter { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(AnimalShelter))]
        public int ShelterId { get; set; }
    }
}
