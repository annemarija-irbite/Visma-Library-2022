using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Visma_Library_2022.Models;

namespace Visma_Library_2022.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Visma_Library_2022.Models.Book> Book { get; set; }
        public DbSet<Visma_Library_2022.Models.BookReservation> BookReservation { get; set; }
        public DbSet<Visma_Library_2022.Models.ProjectRole> ProjectRole { get; set; }
    }
}