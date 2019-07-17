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
using System.Data.Entity;

namespace SimpleMvc.tests.person2
{
    public class Person2ControllerTest
    {
        Person2Controller controller; 
        
        Mock<PersonDbContext> mockRepo; 
        public Person2ControllerTest() 
        {
            
            Person per1 = new Person()
            {
                Id = 1,
                FirstName = "John", 
                LastName = "Henry", 
                Age = 45
            }; 

            Person per2 = new Person()
            {
                Id = 2,
                FirstName = "Tom", 
                LastName = "Simpson", 
                Age = 45
            }; 
            var Persons = new List<Person>()
            {
               per1, per2
            }.AsQueryable();  
            

            // now PersonController is created with service object 
            mockRepo = new Mock<PersonDbContext>();
            //mockRepo.Setup(repo => repo.persons.AddRange(GetTestSessions()));
            //mockRepo.Setup(repo => repo.persons.Add(per3));

            var mockSet = new Mock<DbSet<Person>>();
            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(Persons.Provider);
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(Persons.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(Persons.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(Persons.GetEnumerator()); 
            //mockRepo.Setup(x => x.persons)
              //  .Returns(mockSet.Object);

            //mockRepo.Object.persons.AddRange(GetTestSessions());
            mockRepo.Object.persons.Add(per2);
            //mockRepo.Setup(m => m.persons).Returns(new Person[] { 
              //  new Person { Id = 1, FirstName = "mah" }
            //}.AsQueryable()); 
            controller = new Person2Controller(mockRepo.Object);  

            //// 
            //var mockDbContext = EntityFrameworkMockHelper.GetMockContext<PersonDbContext>();       
        }

        [Theory]
        [InlineData(2, "John", "Henry")]
        public async void testDetails(int? id, string firstName, string lastName)  
        {            
            var result  = await controller.Details(id) as OkObjectResult;

            Person per = result.Value as Person; 

            var viewresult = Assert.IsType<ViewResult>(result); 
            //Assert.NotNull(result.ViewData.Model);

            /* ViewResult viewResult = Assert.IsType<ViewResult>(result);
            Person person = Assert.IsType<Person>(viewResult.Model);
            Assert.Equal(id, person.Id); 
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
            Assert.Equal(1,1); */
        }
        
        private List<Person> GetTestSessions()
        {
            var sessions = new List<Person>();
            sessions.Add(new Person()
            {
                Id = 1,
                FirstName = "John", 
                LastName = "Henry", 
                Age = 45
            });
            sessions.Add(new Person()
            {
                Id = 2,
                FirstName = "Tom", 
                LastName = "Simpson", 
                Age = 23
            });
            return sessions;
        }
    }
}