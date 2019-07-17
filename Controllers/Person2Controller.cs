using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SimpleMvc.Models; 
using SimpleMvc.Service; 
using System.Linq;


namespace SimpleMvc.Controllers
{
    public class Person2Controller : Controller
    {
        // 
        // GET: /Person/
        public PersonDbContext context; 

        // This controller needs PersonService to create the object 
        public Person2Controller(PersonDbContext context) 
        {
            this.context = context; 
        }

        public IActionResult Index()
        {
            // since the view name is specified as "Person", expected file name in the method name "Person.cshtml"
            //return View(); 
            var persons = from p in context.persons
            orderby p.Id
            select p; 
            return View(persons);
        }
    }
}