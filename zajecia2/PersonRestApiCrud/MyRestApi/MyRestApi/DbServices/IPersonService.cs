using MyRestApi.Models;

namespace MyRestApi.DbServices
{
    public interface IPersonService
    {
            Task<List<PersonModel>> GetPersonssAsync(); // GET All Persons

            Task<PersonModel> GetPerson(Guid id); //Get single Person by ID

            Task<PersonModel> AddPerson(PersonModel person); // POST New Person

            Task<PersonModel> UpdatePerson(PersonModel person); // PUT Person

            Task<(bool, string)> DeletePerson(PersonModel person); // DELETE Person

    }
}
