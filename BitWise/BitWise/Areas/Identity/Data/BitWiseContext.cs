using BitWise.Areas.Identity.Data;
using BitWise.Models.Entities;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BitWise.Data;

public class BitWiseContext : IdentityDbContext<BitWiseUser>, IDataProtectionKeyContext
{
    public BitWiseContext(DbContextOptions<BitWiseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Trophy> Trophies { get; set; }
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; } = null!;
    public DbSet<BitWise.Models.Entities.Course> Course { get; set; }
    public DbSet<BitWise.Models.Entities.CourseViewModel> CourseViewModel { get; set; }
}
