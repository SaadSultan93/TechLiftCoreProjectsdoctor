using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLiftCoreProjects.Models
{
    [Table("tblApp")]
    public class Appointment
    {
        [Key]
        [Column("Appointment_ID")]
        public int AppId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? appointmentdate { get; set; }
        [Required(ErrorMessage ="Plz enter day")]
        public string? appointmentDay { get; set; }
        [Required(ErrorMessage ="DoctorName id required")]  
        public string? DoctorName { get; set; }
        [StringLength(10,ErrorMessage ="Length cannot be more than 10")] 
        public string? PatientName { get; set; }


        [Required(ErrorMessage ="time is required")]
        public string? AppointmentTime { get; set; }
    }
}
