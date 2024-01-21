using MyRestApi.Models;

namespace MyRestApi
{
    public interface IPersonService
    {
        Task<List<PersonModel>> GetPersonsAsync();

        Task<PersonModel> AddPerson(PersonModel person);

        Task<PersonModel> UpdatePerson(PersonModel person);

        Task<(bool,string)> DeletePerson(PersonModel person);

        Task<PersonModel> GetPersonById(Guid id);

    }
}
