using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA48P_HFT_2021221.Models
{
    public class AnimalShelter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ShelterId { get; set; }

        public string SheltertName { get; set; }

        public string Address { get; set; }

        public int PhoneNumber { get; set; }

        public long TaxNumber { get; set; }

        [NotMapped]
        public virtual ICollection<Pet> Pets { get; set; }

        public AnimalShelter()
        {
            Pets = new HashSet<Pet>();
        }
    }
}
