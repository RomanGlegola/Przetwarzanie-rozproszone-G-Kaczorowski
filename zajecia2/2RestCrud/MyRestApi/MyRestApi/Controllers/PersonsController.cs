using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetPersons()
        {
            var persons = await personService.GetPersonsAsync();
            if (persons == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No persons in database");
            }

            return StatusCode(StatusCodes.Status200OK, persons);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            var person = await personService.GetPersonById(id);
            if (person == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No person in database");
            }

            return StatusCode(StatusCodes.Status200OK, person);
        }


        [HttpPost]
        public async Task<ActionResult<PersonModel>> AddPerson(PersonModel person)
        {
            var dvPerson = await personService.AddPerson(person);

            return CreatedAtAction("get person", person);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdatePersons(Guid id, PersonModel person)
        {
            var result = await personService.UpdatePerson(person);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "update is not possible");
            }

            return NoContent();
        }


        [HttpDelete("id")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var person = await personService.GetPersonById(id);
            
            (bool status, string message) = await personService.DeletePerson(person);

            if (status==false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return NoContent();
        }



    }
}
