using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TechLiftCoreProjects.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ProjectsUser class
public class ProjectsUser : IdentityUser
{

   public string UserFirstName { get; set; }    

    public string UserLastName { get; set; }
    [NotMapped]
    public string FullName
    {
        get
        {
            return UserFirstName + " " + UserLastName;  
        }
    }
}

