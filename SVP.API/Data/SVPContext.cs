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
    
}