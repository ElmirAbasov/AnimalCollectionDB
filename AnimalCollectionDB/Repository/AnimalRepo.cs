using AnimalCollectionWithDB.Entitie;
using AnimalCollectionWithDB.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnimalCollectionWithDB.Repository
{
    public class AnimalRepo : IAnimalRepo
    {
        private Context _context;

        public AnimalRepo(Context context)
        {
            _context = context;
        }

        public List<Animal> GetAll()
        {
            return _context.Animals.Include(animal => animal.AnimalType).ToList();
        }

        public Animal GetByID(int id)
        {
            Animal animal = _context.Animals.Include(animal => animal.AnimalType).SingleOrDefault(animal => animal.ID == id);
            return animal;
        }

        public Animal CreateAnimal(UpdateAnimalDTO UpdateAnimalDTO)
        {
            Animal animal = new Animal();
            animal.AnimalTypeID = UpdateAnimalDTO.AnimalTypeID;
            animal.Name = UpdateAnimalDTO.Name;

            _context.Animals.Add(animal);
            _context.SaveChanges();

            return animal;
        }

        public Animal UpdateAnimal(UpdateAnimalDTO UpdateAnimalDTO, int id)
        {
            Animal currentAnimal = _context.Animals.FirstOrDefault(item => item.ID == id);
            if (currentAnimal != null)
            {
                currentAnimal.Name = UpdateAnimalDTO.Name;
                currentAnimal.AnimalTypeID = UpdateAnimalDTO.AnimalTypeID;
            }

            _context.SaveChanges();
            return currentAnimal;
        }


        public void DeleteAnimal(int id)
        {
            _context.Animals.Remove(GetByID(id));
            _context.SaveChanges();
        }
    }
}