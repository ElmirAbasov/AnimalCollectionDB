using AnimalCollectionWithDB.Entitie;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCollectionWithDB.DTOs
{
    public class AnimalTypeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public static class AnimalTypeDTOExtensions
    {
        public static AnimalTypeDTO MapToAnimalTypeDTO(this AnimalType animalType)
        {
            return new AnimalTypeDTO
            {
                ID = animalType.ID,
                Name = animalType.Name
            };

        }

        public static List<AnimalTypeDTO> MapToAnimalTypeDTOs(this List<AnimalType> animalTypes)
        {
            return animalTypes.Select(animalType => animalType.MapToAnimalTypeDTO()).OrderBy(animalType => animalType.ID).ToList();
        }

    }

}