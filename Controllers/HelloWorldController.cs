using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace SimpleMvc.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            // since the view name is not specified, expected file name in the method name "Index.cshtml"
            //return View(); 
            ViewData["Message"] = "message from aliens, earth is under attack"; 
            return View("Index");
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome()
        {
            //return "This is the Welcome action method...";
            ViewData["Message"] = "Hello Aliens, Welcome to Earth!"; 
            return View("Welcome"); 
        }
    }
}