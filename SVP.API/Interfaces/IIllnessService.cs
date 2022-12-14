using System.Collections.Generic;
using System.Threading.Tasks;
using SVP.API.Entities;

namespace SVP.API.Interfaces;

public partial interface ISVPService
{
    public Task<List<Illness>> GetIllnesses();
    public Task<Illness> GetIllnessById(long illnessId);
    
    public Task<Illness> AddIllness(Illness illness);

    public Task<Illness> EditIllness(Illness illness);
    
    public Task DeleteIllness(long illnessId);
}