using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechLiftCoreProjects.Areas.Identity.Data;
using TechLiftCoreProjects.Models;
using TechLiftCoreProjects.Models.VMs;

namespace TechLiftCoreProjects.Data
{
    public class ApplicationDBcontext : IdentityDbContext<ProjectsUser>
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
        {

        }

        //Db Sets Properties me aati he
        public DbSet<DoctorVM> doctorview { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<DoctorInfo> DoctorInfo { get; set; }   
        public DbSet<Department> Department { get; set; }
        public DbSet<TechLiftCoreProjects.Models.DoctorCases> DoctorCases { get; set; } = default!;
    }
}
