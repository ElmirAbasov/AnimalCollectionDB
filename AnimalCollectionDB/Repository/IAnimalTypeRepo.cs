using AnimalCollectionWithDB.Entitie;
using System.Collections.Generic;

namespace AnimalCollectionWithDB.Repository
{
    public interface IAnimalTypeRepo
    {
        List<AnimalType> GetAll();
        AnimalType GetByID(int id);
        AnimalType CreateAnimalType(AnimalType animalType);
        AnimalType UpdateAnimalType(AnimalType animalType, int id);
        void DeleteAnimalType(int id);
    }
}