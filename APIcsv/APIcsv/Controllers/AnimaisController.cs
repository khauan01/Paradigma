using APIcsv.Database;
using APIcsv.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIcsv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private readonly DBContext _dbContext;

        public AnimaisController(DBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAll()
        {
            return Ok(_dbContext.Animais);

        }


        [HttpGet("{id}")]
        public ActionResult<Animal> GetById(int id)
        {
            try
            {
                Animal animal =
                    _dbContext.Animais.Find(a => a.Id == id);

                if (animal == null)
                    return NotFound(); // 404

                return Ok(animal);  // 200
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message); // 400
            }
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var animal = _dbContext.Animais.Find(a => a.Id == id);

                if (animal == null)
                    return NotFound(); // 404

                _dbContext.Animais.Remove(animal);

                return NoContent(); // 204 - Sucesso sem conteúdo
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message); // 400
            }
        }



        [HttpPatch("AlterarNome")]
        public ActionResult<Animal> AlterarNome([FromBody] Animal body)
        {
            if ((body == null) || (string.IsNullOrEmpty(body.Name)))
                return BadRequest();

            Animal animal = _dbContext.Animais.Find(a => a.Id == body.Id);

            if (animal == null)
                return NotFound();

            animal.Name = body.Name;
            return Ok(animal);
        }



        [HttpPost]
        public ActionResult<Animal> Create([FromBody] Animal newAnimal)
        {
            if (newAnimal == null || string.IsNullOrEmpty(newAnimal.Name))
                return BadRequest("Animal inválido.");


            _dbContext.Animais.Add(newAnimal);


            return CreatedAtAction(nameof(GetById), new { id = newAnimal.Id }, newAnimal);
        }




        [HttpPut("{id}")]
        public ActionResult<Animal> Update(int id, [FromBody] Animal updatedAnimal)
        {
            if (updatedAnimal == null || id != updatedAnimal.Id)
                return BadRequest("Dados inválidos.");

            var existingAnimal = _dbContext.Animais.FirstOrDefault(a => a.Id == id);
            if (existingAnimal == null)
                return NotFound("Animal não encontrado.");

            existingAnimal.Name = updatedAnimal.Name;
            existingAnimal.Classification = updatedAnimal.Classification;
            existingAnimal.Origin = updatedAnimal.Origin;
            existingAnimal.Reproduction = updatedAnimal.Reproduction;
            existingAnimal.Freeding = updatedAnimal.Freeding;


            return NoContent(); // Retorna 204
        }
    }
}


