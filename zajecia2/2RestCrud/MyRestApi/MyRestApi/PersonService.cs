using Microsoft.EntityFrameworkCore;
using MyRestApi.Models;
using System;

namespace MyRestApi
{
    public class PersonService : IPersonService
    {

        private readonly AppDbContext db;

        public PersonService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<PersonModel> AddPerson(PersonModel person)
        {
            try
            {
                await db.Persons.AddAsync(person);
                await db.SaveChangesAsync();
                return person;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }


        }

        public async Task<(bool, string)> DeletePerson(PersonModel person)
        {
            try
            {
                var record = await db.Persons.FindAsync(person.PersonId);
                db.Persons.Remove(person);
                await db.SaveChangesAsync();
                return (true, "person record was deleted");

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<PersonModel> GetPersonById(Guid id)
        {
            try
            {
                var result = await db.Persons.FindAsync(id);

                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }




        public async Task<List<PersonModel>> GetPersonsAsync()
        {
            try
            {
                return await db.Persons.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task<PersonModel> UpdatePerson(PersonModel person)
        {
            try
            {
                db.Entry(person).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return person;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
