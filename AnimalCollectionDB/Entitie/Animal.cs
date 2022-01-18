using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalCollectionWithDB.Entitie
{
    public class Animal
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("AnimalType")]
        public int AnimalTypeID { get; set; }

        public AnimalType AnimalType { get; set; }

        [Required]
        public string Name { get; set; }
    }
}