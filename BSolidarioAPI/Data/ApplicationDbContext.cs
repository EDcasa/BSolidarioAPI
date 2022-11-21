using BSolidarioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BSolidarioAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientPlanType> ClientPlanTypes { get; set; }
        public DbSet<PlanType> PlanType { get; set; }
    }
}
