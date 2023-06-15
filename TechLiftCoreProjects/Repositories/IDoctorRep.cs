using TechLiftCoreProjects.Models;
using TechLiftCoreProjects.Models.VMs;

namespace TechLiftCoreProjects.Repositories
{
    public interface IDoctorRep
    {
        int CreateDoc(DoctorInfo d);

        int UpdateDoc(DoctorInfo d);    

        int DeleteDoc(Guid DoctorId);

        IEnumerable<DoctorInfo> ShowAll();

          DoctorInfo GetDoctorById(Guid Id);

        List<DoctorVM> showbydepartorday(int deptid,string day);
    }
}
