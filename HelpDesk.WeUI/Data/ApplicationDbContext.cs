using HelpDesk.WebUI.Configurations.Entities;
using HelpDesk.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.WebUI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HelpDiskDB;Trusted_Connection=True;MultipleActiveResultSets=true;trustservercertificate=True;");

        // public DbSet<AppUser> users { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleSeedConfiguration());
            modelBuilder.ApplyConfiguration(new UserSeedConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleSeedConfiguration());

            /*modelBuilder.Entity<Request>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(p => p.UserId); */
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<GeneralModel>().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.ModifiedDate = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<ClientRequest> clientRequests { get; set; }
    }
}