using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SVP.API.Entities;

public class Doctor
{
    [Key]
    public long Id { get; set; }
    
    public string Name { get; set; }

    [Comment("Список квалификаций, описаны через запятую с пробелом")]
    public string Qualification { get; set; }
    
}