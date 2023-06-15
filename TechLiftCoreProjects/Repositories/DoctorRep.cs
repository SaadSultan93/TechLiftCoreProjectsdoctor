using TechLiftCoreProjects.Data;
using TechLiftCoreProjects.Models;
using TechLiftCoreProjects.Models.VMs;

namespace TechLiftCoreProjects.Repositories
{
    public class DoctorRep : IDoctorRep
    {
        private readonly ApplicationDBcontext _context;
        public DoctorRep(ApplicationDBcontext context)
        {
            _context = context;
        }
        public int CreateDoc(DoctorInfo d)
        {
            _context.DoctorInfo.Add(d);
            return _context.SaveChanges();
            
        }

        public int DeleteDoc(Guid DoctorId)
        {
            _context.DoctorInfo.Remove(_context.DoctorInfo.Where(a => a.DoctorId == DoctorId).SingleOrDefault());
            return _context.SaveChanges();  
           
        }

        public DoctorInfo GetDoctorById(Guid Id)
        {
           return _context.DoctorInfo.Where(a=>a.DoctorId == Id).SingleOrDefault();
        }

        public IEnumerable<DoctorInfo> ShowAll()
        {
           return _context.DoctorInfo.ToList();
        }

        public List<DoctorVM> showbydepartorday(int deptid, string day)
        {
            var result = new List<DoctorVM>();
            if (deptid != 0 || day != null)

            {
                ///join inner join 
                ///select * from tbl1 inner join tbl2 on tbl1.id= tbl2.id
                ///LInq
                ///
               result = (from c in _context.DoctorInfo

                              join k in _context.Department on c.DeptId equals k.DeptId

                              where c.DeptId == deptid || c.DoctorDays == day

                              select new DoctorVM
                              {
                                  DepartmentName = k.DeptName,
                                  DoctorDays = c.DoctorDays,
                                  DoctorFullName = c.PersonFullName,

                              }).ToList();
               
            }

            return result;


            }

        public int UpdateDoc(DoctorInfo d)
        {
            _context.DoctorInfo.Update(d);
          return  _context.SaveChanges();
        }
    }
}
