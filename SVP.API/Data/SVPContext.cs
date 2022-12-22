using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SVP.API.Entities;

namespace SVP.API.Data;

public class SVPContext: DbContext
{
    public virtual DbSet<Patient> Patients { get; set; }
    
    public virtual DbSet<Doctor> Doctors { get; set; }
    
    public virtual DbSet<Illness> Illnesses { get; set; }
    
    public virtual DbSet<AuthData> AuthData { get; set; }

    public SVPContext(DbContextOptions<SVPContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>().HasOne(x => x.Illness).WithMany().HasForeignKey(x => x.IllnessId);
        modelBuilder.Entity<Patient>().HasOne(x => x.RecommendedDoctor).WithMany().HasForeignKey(x => x.RecommendedDoctorId);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
}