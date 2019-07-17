using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SimpleMvc.Models; 
using SimpleMvc.Service; 
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SimpleMvc.Controllers
{
    public class Person2Controller : Controller
    {
        // 
        // GET: /Person2/
        public PersonDbContext context; 

        // This controller needs Database context to create the object 
        public Person2Controller(PersonDbContext context) 
        {
            this.context = context; 
        }

        public IActionResult Index()
        {
            // since the view name is specified as "Person", expected file name in the method name "Person.cshtml"
            // get all Person information from database  
            var persons = from p in context.persons
            orderby p.Id
            select p; 
            return View(persons);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await context.persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
    }
}