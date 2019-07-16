using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SimpleMvc.Models; 
using SimpleMvc.Service; 

namespace SimpleMvc.Controllers
{
    public class PersonController : Controller
    {
        // 
        // GET: /Person/
        IPersonService ser; 

        public PersonController(IPersonService service) 
        {
            ser = service; 
        }

        public IActionResult Index()
        {
            // since the view name is specified as "Person", expected file name in the method name "Person.cshtml"
            //return View(); 
            return View();
        }

        // 
        // GET: /Person/Welcome/ 

        public IActionResult PersonByID(int? id)
        {
            return View(ser.Get((int)id)); 
        }

        public IActionResult PersonByIDOtherWay(int? id)
        {            
            ViewData["Person"] = ser.Get((int)id);
            return View(); 
        }
    }
}