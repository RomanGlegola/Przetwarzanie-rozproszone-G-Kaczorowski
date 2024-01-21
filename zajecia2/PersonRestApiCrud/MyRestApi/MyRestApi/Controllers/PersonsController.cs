using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRestApi.DbServices;
using MyRestApi.Models;

namespace MyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonsController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchools()
        {
            var persons = await personService.GetPersonssAsync();

            if (persons == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No persons in database");
            }

            return StatusCode(StatusCodes.Status200OK, persons);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            PersonModel person = await personService.GetPerson(id);

            if (person == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Person found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, person);
        }

        [HttpPost]
        public async Task<ActionResult<PersonModel>> AddPerson(PersonModel person)
        {
            var dbPerson = await personService.AddPerson(person);

            if (dbPerson == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{person.PersonId} could not be added.");
            }

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }


        [HttpPut("id")]
        public async Task<IActionResult> UpdatePerson(Guid id, PersonModel person)
        {
            if (id != person.PersonId)
            {
                return BadRequest();
            }

           var dbPersons = await personService.UpdatePerson(person);

            if (dbPersons == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{person.PersonId} could not be updated");
            }

            return NoContent();
        }


        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSchool(Guid id)
        {
            var person = await personService.GetPerson(id);

            (bool status, string message) = await personService.DeletePerson(person);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, person);
        }



    }
}
