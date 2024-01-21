using Microsoft.EntityFrameworkCore;
using MyRestApi.Models;

namespace MyRestApi.DbServices
{
    public class DbInitializer
    {

        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }
        public void Seed()
        {

            _builder.Entity<PersonModel>(a =>
            {
                a.HasData(new PersonModel
                {
                    PersonId = Guid.NewGuid(),
                    Name = "Kevin",
                    Email="kevin@gmail.com",
                    Age=25,
                    PhotoUrl= "https://images.pexels.com/photos/2380794/pexels-photo-2380794.jpeg?auto=compress&cs=tinysrgb&w=600"

                });
                a.HasData(new PersonModel
                {
                    PersonId = Guid.NewGuid(),
                    Name = "Marta",
                    Email = "marta@gmail.com",
                    Age = 26,
                    PhotoUrl = "https://images.pexels.com/photos/3586798/pexels-photo-3586798.jpeg?auto=compress&cs=tinysrgb&w=600"

                });

                a.HasData(new PersonModel
                {
                    PersonId = Guid.NewGuid(),
                    Name = "Nicole",
                    Email = "nicole@gmail.com",
                    Age = 22,
                    PhotoUrl = "https://images.pexels.com/photos/1994818/pexels-photo-1994818.jpeg?auto=compress&cs=tinysrgb&w=600"

                });
            });


        }
    }
}
