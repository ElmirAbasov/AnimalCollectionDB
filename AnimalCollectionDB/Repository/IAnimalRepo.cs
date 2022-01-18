using AnimalCollectionWithDB.Entitie;
using AnimalCollectionWithDB.DTOs;
using System.Collections.Generic;

namespace AnimalCollectionWithDB.Repository
{
    public interface IAnimalRepo
    {
        List<Animal> GetAll();
        Animal GetByID(int id);
        Animal CreateAnimal(UpdateAnimalDTO UpdateAnimalDTO);
        Animal UpdateAnimal(UpdateAnimalDTO UpdateAnimalDTO, int id);
        void DeleteAnimal(int id);
    }
}
