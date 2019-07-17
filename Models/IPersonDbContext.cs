using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace SimpleMvc.Models
{
    public interface IPersonDbContext 
    {
        IDbSet<Person> persons { get; }
    } // end of class PersonDbContext 
}