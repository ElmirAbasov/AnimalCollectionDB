using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AnimalCollectionWithDB.Entitie

{
    public class AnimalType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Animal> Animals { get; set; }
    }
}
