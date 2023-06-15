using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLiftCoreProjects.Models
{
    
   
    public class PersonbaseClass
    {
        public string? PersonFirstName { get; set; } 

        public string? PersonLastName { get; set; }
       
        public string PersonFullName
        {
            get
            {
                return PersonFirstName+" "+PersonLastName;
            }  
        }

        public string? PersonEmailAddress { get; set; } 

        public string? PersonContactDetail { get; set; } 
    }
}
