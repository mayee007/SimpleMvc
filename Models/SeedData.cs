using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SimpleMvc.Models
{
    public class SeedData 
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PersonDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PersonDbContext>>()))
            {
                // Look for any movies.
                if (context.persons.Any())
                {
                    return;   // DB has been seeded
                }

                context.persons.AddRange(
                    new Person
                    {
                        Title = "When Harry Met Sally",
                        FirstName = "John",
                        LastName = "Henry",
                        Age = 43
                    });
            }
        }
    }
}