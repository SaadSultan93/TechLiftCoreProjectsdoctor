using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLiftCoreProjects.Data;
using TechLiftCoreProjects.Models.VMs;

namespace TechLiftCoreProjects.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDBcontext _context;
        public DepartmentController(ApplicationDBcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<DoctorVM> doctor = _context.doctorview.FromSqlRaw("selectdatafromtables");
            return PartialView("_search", doctor);
        }
    }
}
