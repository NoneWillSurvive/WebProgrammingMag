#nullable enable
using System.ComponentModel.DataAnnotations;

namespace SVP.API.Entities;

public class AuthData
{
    [Key]
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public Patient? Patient { get; set; }
    
    public Doctor? Doctor { get; set; }
}