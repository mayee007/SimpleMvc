using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimpleMvc.Models
{
    public class PersonDbContext : DbContext 
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {}

        public DbSet<Person> persons { get; set; }
    } // end of class PersonDbContext 
}