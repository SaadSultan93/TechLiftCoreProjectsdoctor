using TechLiftCoreProjects.Models;

namespace TechLiftCoreProjects.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailMessage msg);   
    }
}
