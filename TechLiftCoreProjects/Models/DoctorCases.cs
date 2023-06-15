using Microsoft.EntityFrameworkCore;

namespace TechLiftCoreProjects.Models
{
    [Keyless]
    public class DoctorCases
    {
        public Guid DoctorId { get; set; }

        public DateTime casedate { get; set; }  

        public string caseDescription { get; set; } 
    }
}
