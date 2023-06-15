using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechLiftCoreProjects.Data;
using TechLiftCoreProjects.Models;
using TechLiftCoreProjects.Services;

namespace TechLiftCoreProjects.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _service;
        private readonly ApplicationDBcontext _context;

        public HomeController(ILogger<HomeController> logger,IEmailService service,ApplicationDBcontext context)
        {
            _logger = logger;
            _service = service;
            _context = context;
        }
       public IActionResult SendAll()
        {
          
            foreach(var item in _context.DoctorInfo.ToList() )
            {
               
                _service.SendEmail(new EmailMessage
                {
                    ToEmail = item.PersonEmailAddress,
                    ToName = item.PersonFullName,
                    Body = "We have raised your salary",
                    Subject = "Salary Increament"
                }); 
            }
            return RedirectToAction("show","doc"); 
        }

        public IActionResult EmailUser(string email,string name)
        {
            ////send same email to every doctor

            //////
            ///

            EmailMessage msg = new EmailMessage();
            msg.Subject = "Saturday Off Notice";
            msg.Body = $"Dear {name} " +
                "Saturday is off";
            msg.ToEmail = email;
            msg.ToName = name;
            _service.SendEmail(msg);
            string na = "fahad";
            /// passing values to same controller
            /// 
            return RedirectToAction("show", "doc");
           // return RedirectToAction("show",msg);
            // passsing value to a different controller
           // return RedirectToAction("show","doc", msg);
        }

        public IActionResult SendEmail()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailMessage msg)
        {
            _service.SendEmail(msg);
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Mainpage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}