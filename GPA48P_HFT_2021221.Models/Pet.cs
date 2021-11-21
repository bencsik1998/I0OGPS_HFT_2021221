using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DateTime ReceptionDate { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual AnimalShelter AnimalShelter { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        [ForeignKey(nameof(AnimalShelter))]
        public int ShelterId { get; set; }
    }
}
