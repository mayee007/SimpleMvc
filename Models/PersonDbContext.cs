using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace SimpleMvc.Models
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {}
        public PersonDbContext() 
        {}

        public DbSet<Person> persons { get; set; }

        //public DbSet<Person> Person {get; set; }
    } // end of class PersonDbContext 
}