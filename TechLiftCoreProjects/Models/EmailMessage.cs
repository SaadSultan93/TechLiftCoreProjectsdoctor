using System.Runtime.CompilerServices;

namespace TechLiftCoreProjects.Models
{
    public class EmailMessage
    {
        public string ToEmail { get; set; } 
        public string ToName { get; set; }
        public string Subject { get; set; } 

        public string Body { get; set; }    
    }
}
