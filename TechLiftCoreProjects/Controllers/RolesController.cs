using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TechLiftCoreProjects.Controllers
{
    public class RolesController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
       // private readonly UserManager<IdentityUser> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager= roleManager;
            
        }
        
        public IActionResult ShowRoles()
        {
            return View(_roleManager.Roles.ToList());
        }

                                                                                                           


        [HttpPost]
        public   IActionResult CreateRole(string txtRole)
        {
           
       _roleManager.CreateAsync(new IdentityRole { Name = txtRole }).Wait();
           
            return RedirectToAction("ShowRoles");

        }
    }
}
