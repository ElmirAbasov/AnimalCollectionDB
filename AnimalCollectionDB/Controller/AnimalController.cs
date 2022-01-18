using AnimalCollectionWithDB.DTOs;
using AnimalCollectionWithDB.Entitie;
using AnimalCollectionWithDB.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AnimalCollectionWithDB.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepo _animalRepository;
        public AnimalController(IAnimalRepo animalRepo)
        {
            _animalRepository = animalRepo;
        }

        [HttpGet("")]
        public IActionResult GetAnimals()
        {
            var animals = _animalRepository.GetAll().ToList().MapToAnimalDTOs();

            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimalByID(int id)
        {
            Animal animal = _animalRepository.GetByID(id);
            if (animal == null)
            {
                return NotFound("Can't find animal with ID: " + id);
            }
            AnimalDTO animalDTO = animal.MapToAnimalDTO();

            return Ok(animalDTO);

        }

        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] UpdateAnimalDTO UpdateAnimalDTO)
        {
            Animal newAnimal = _animalRepository.CreateAnimal(UpdateAnimalDTO);
            AnimalDTO animalDTO = _animalRepository.GetByID(newAnimal.ID).MapToAnimalDTO();

            return CreatedAtAction(
                nameof(GetAnimalByID),
                new { id = animalDTO.ID },
                animalDTO);
        }

        public IActionResult UpdateAnimal([FromBody] UpdateAnimalDTO UpdateAnimalDTO, int id)
        {
            Animal updatedAnimal = _animalRepository.UpdateAnimal(UpdateAnimalDTO, id);
            AnimalDTO animalDTO = _animalRepository.GetByID(id).MapToAnimalDTO();

            return Ok(animalDTO);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _animalRepository.DeleteAnimal(id);
            return NoContent();
        }

    }

}