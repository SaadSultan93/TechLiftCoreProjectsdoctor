using NuGet.Packaging.Signing;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace TechLiftCoreProjects.Models
{
    [Table("DoctorInfo")]
    public class DoctorInfo:PersonbaseClass

    {
        [Key]
      
        public Guid DoctorId { get; set; }
        //// doctor schedule
        /////scalar properties
        /// <summary>
        /// 
        /// </summary>
        /// 
        public string DoctorDays { get; set; }
        /// <summary>
        /// navigation property 
        /// </summary>
        /// 
        public DateTime DoctorTime { get; set; }
       
        /// <summary>
        /// navigation property 
        /// </summary>
        /// 
        public int DeptId { get; set; }


       
    }
}
