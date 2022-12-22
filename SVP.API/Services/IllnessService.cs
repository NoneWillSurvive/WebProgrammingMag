using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SVP.API.Data;
using SVP.API.Entities;
using SVP.API.Interfaces;

namespace SVP.API.Services;

public partial class SVPService: ISVPService
{
    public async Task<List<Illness>> GetIllnesses()
    {
        var illnesses = await _context.Illnesses.ToListAsync();
        
        return illnesses;
    }

    public async Task<Illness> GetIllnessById(long illnessId)
    {
        var illness = await _context.Illnesses
            .FirstOrDefaultAsync(x => x.Id == illnessId);
            
        return illness;
    }

    public async Task<Illness> AddIllness(Illness illness)
    {
        await _context.Illnesses.AddAsync(illness);
        await _context.SaveChangesAsync();
        return illness;
    }

    public async Task<Illness> EditIllness(Illness illness)
    {
        _context.Illnesses.Update(illness);
        await _context.SaveChangesAsync();
        return illness;
    }

    public async Task DeleteIllness(long illnessId)
    {
        var illness = await _context.Illnesses.FirstOrDefaultAsync(x => x.Id == illnessId);
        if (illness is not null)
        {
            _context.Illnesses.Remove(illness);
            await _context.SaveChangesAsync();
        }
    }

}