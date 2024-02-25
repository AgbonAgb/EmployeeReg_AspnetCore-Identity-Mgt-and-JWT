using Infrastructure.Accounts;
using Infrastructure.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext:IdentityDbContext<UserReg, UserRoles, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeBasicInfo> EmployeeBasicInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EmployeeBasicInfo>(b =>
            {
                b.HasIndex(x => new { x.Id, x.Phone, x.StaffId, x.Email }).IsUnique(true);

            });
            builder.Entity<Department>(b =>
            {
                b.HasIndex(x => new { x.Id, x.DepartmenName }).IsUnique(true);

            });

        }

    }
}
