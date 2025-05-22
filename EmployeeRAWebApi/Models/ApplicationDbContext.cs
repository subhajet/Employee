using EmployeeRAWebApi.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRAWebApi.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationEmployee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<LoginLogsEmpModel> LoginLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationEmployee>().ToTable("Employee_RA_Subhajit");
            builder.Entity<IdentityRole>().ToTable("EmpRA_Roles_Subhajit");
            builder.Entity<IdentityUserRole<string>>().ToTable("EmpRA_UserRoles_Subhajit");
            builder.Entity<IdentityUserClaim<string>>().ToTable("EmpRA_UserClaims_Subhajit");
            builder.Entity<IdentityUserLogin<string>>().ToTable("EmpRA_UserLogins_Subhajit");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("EmpRA_RoleClaims_Subhajit");
            builder.Entity<IdentityUserToken<string>>().ToTable("EmpRA_UserTokens_Subhajit");

            builder.Entity<LoginLogsEmpModel>().ToTable("EmpRA_LoginLogs_Subhajit");
        }
    }
}
