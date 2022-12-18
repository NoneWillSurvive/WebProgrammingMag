using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SVP.API.Entities;

public class Patient
{
    [Key]
    public long Id { get; set; }
    
    [Comment("true - М, false - Ж")]
    public bool Gender { get; set; }
    
    public byte Age { get; set; }
    
    public string Name { get; set; }
    
    public Illness Illness { get; set; }
    
    [Comment("Уровень тревоги")]
    public byte LevelAnxiety { get; set; }
    
    [Comment("Уровень депрессии")]
    public byte LevelDepression { get; set; }
    
    [Comment("Уровень безнадежности")]
    public byte LevelHopelessness { get; set; }
    
    [Comment("Уровень астенического синдрома")]
    public byte LevelAsthenicSyndrome { get; set; }

    [Comment("Есть ли зависимость")]
    public bool HasAddiction { get; set; }
    
    [Comment("Нужна ли госпитализация")]
    public bool NeedHospitalization { get; set; }
    
    [Comment("Рекомендуемый врач")]
    public Doctor RecommendedDoctor { get; set; }
    
}