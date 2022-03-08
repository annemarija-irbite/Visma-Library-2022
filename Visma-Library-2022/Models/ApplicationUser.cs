using Microsoft.AspNetCore.Identity;

namespace Visma_Library_2022.Models
{
    public class ApplicationUser: IdentityUser
    {
        public virtual Reservation Reservation { get; set; }
    }
}