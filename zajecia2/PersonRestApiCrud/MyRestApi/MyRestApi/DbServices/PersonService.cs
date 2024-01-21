using Microsoft.EntityFrameworkCore;
using MyRestApi.Models;
using System;

namespace MyRestApi.DbServices
{
    public class PersonService : IPersonService
    {

        private readonly AppDbContext db;

        public PersonService(AppDbContext db)
        {
            this.db = db;
        }



        public async Task<List<PersonModel>> GetPersonssAsync()
        {
            try
            {
                return await db.Persons.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public async Task<PersonModel> GetPerson(Guid id)
        {
            try
            {
                var result = await db.Persons.FindAsync(id);
                return result;
               // var result = db.Persons.Where(p => p.PersonId== id).FirstAsync();

               // return await result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<PersonModel> AddPerson(PersonModel person)
        {
            try
            {
                await db.Persons.AddAsync(person);
                await db.SaveChangesAsync();
                return await db.Persons.FindAsync(person.PersonId); // Auto ID from DB
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null; // An error occured
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
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<(bool, string)> DeletePerson(PersonModel person)
        {
            try
            {
                var record = await db.Persons.FindAsync(person.PersonId);

                if (record == null)
                {
                    return (false, "Person could not be found");
                }

                db.Persons.Remove(person);
                await db.SaveChangesAsync();

                return (true, "Person record got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }
    }
}
