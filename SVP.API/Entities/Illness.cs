using System.ComponentModel.DataAnnotations;

namespace SVP.API.Entities;

public class Illness
{
    [Key]
    public long Id { get; set; }
    
    public string Name { get; set; }

    public string CodeMKB { get; set; }
    
}