using Microsoft.EntityFrameworkCore;

namespace TechLiftCoreProjects.Models.VMs
{
    [Keyless]
    public class DoctorVM
    {
        public string DoctorFullName { get; set; }

        public string DepartmentName { get; set; }

        public string DoctorDays { get; set; }
    }
}
