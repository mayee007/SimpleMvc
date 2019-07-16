using Microsoft.AspNetCore.Mvc;
using Xunit;
using SimpleMvc.Service; 
using SimpleMvc.Controllers; 
using SimpleMvc.Models; 
using Moq; 
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using FluentAssertions;
using System;

namespace SimpleMvc.tests.persons 
{
    public class PersonControllerTest
    {
        PersonController controller; 
        IPersonService service; 

        public PersonControllerTest() 
        {
            Person per1 = new Person(); 
            per1.FirstName = "Tom"; 
            per1.LastName = "Cat"; 
            per1.Age = 6; 

            Person per2 = new Person(); 
            per2.FirstName = "Jerry"; 
            per2.LastName = "Cat"; 
            per2.Age = 8;

            service = new PersonService(); 
            service.Add(per1); 
            service.Add(per2); 

            controller = new PersonController(service);           
        }

        [Theory]
        [InlineData(51, "Tom", "Cat", 6)] 
        [InlineData(52, "Jerry", "Cat", 8)] 
        public void ViewTestData(int id, string firstName, string lastName, int age) 
        {
            IActionResult result = controller.PersonByID(id); 
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            Person person = Assert.IsType<Person>(viewResult.Model);
            Assert.Equal(id, person.Id); 
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
            Assert.Equal(age, person.Age); 
        }
    }
}