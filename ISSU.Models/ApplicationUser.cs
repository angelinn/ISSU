using Microsoft.AspNet.Identity.EntityFramework;

namespace ISSU.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
