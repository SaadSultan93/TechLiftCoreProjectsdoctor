using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechLiftCoreProjects.Data;
using TechLiftCoreProjects.Models;
using TechLiftCoreProjects.Models.VMs;
using TechLiftCoreProjects.Repositories;

namespace TechLiftCoreProjects.Controllers
{
    [Authorize]

    public class DocController : Controller
    {
        private readonly ApplicationDBcontext _context;
        private readonly IDoctorRep _rep;

        public DocController(ApplicationDBcontext context,IDoctorRep rep)
        {
            _context = context;
            _rep = rep;
        }
        public IActionResult show(int deptid, string day)

        {


            if (deptid != 0 || day != null)

            {
                var result = _rep.showbydepartorday(deptid, day);
                ///join inner join 
                ///select * from tbl1 inner join tbl2 on tbl1.id= tbl2.id
                ///LInq
                ///
                //var result = (from c in _context.DoctorInfo

                //              join k in _context.Department on c.DeptId equals k.DeptId

                //              where c.DeptId == deptid || c.DoctorDays == day

                //              select new DoctorVM
                //              {
                //                  DepartmentName = k.DeptName,
                //                  DoctorDays = c.DoctorDays,
                //                  DoctorFullName = c.PersonFullName,

                //              }).ToList();

                //return View(_context.DoctorInfo.Where(a=>a.DeptId==deptid).ToList());
                return PartialView("_SearchDoc", result);

            }
            //return View(_context.DoctorInfo.ToList());
            return View(_rep.ShowAll());
        }
     
        public IActionResult AddDoc()
        {
            ViewBag.dept = _context.Department.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddDoc(DoctorInfo inf)
        {
            _rep.CreateDoc(inf);
            //_context.DoctorInfo.Add(inf);
            //_context.SaveChanges();
            ViewBag.dept = _context.Department.ToList();
            return RedirectToAction("show");
        }

        public IActionResult DocCases()
        {
            ViewBag.doctors = _context.DoctorInfo.ToList();
            return View();
        }


        public IActionResult DocDetails(Guid id)
        {
            return View(_rep.GetDoctorById(id));

        }
    }
}
