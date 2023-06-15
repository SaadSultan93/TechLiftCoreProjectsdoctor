using System.ComponentModel.DataAnnotations;

namespace TechLiftCoreProjects.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        public string? DeptName { get; set; }
    }
}