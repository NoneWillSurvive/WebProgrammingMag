using System.ComponentModel.DataAnnotations;

namespace SVP.API.Entities;

public class Doctor
{
    [Key]
    public long Id { get; set; }
    
    public string Name { get; set; }

    public string Quaification { get; set; }
    
}