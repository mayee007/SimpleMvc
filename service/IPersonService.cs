using SimpleMvc.Models; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System; 
using System.Collections.Generic; 

namespace SimpleMvc.Service
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        Person Add(Person person);
        void Update(int id, Person person);
        void Delete(int id);
    }
}