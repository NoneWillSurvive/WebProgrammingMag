using System.Threading.Tasks;
using SVP.API.Data;
using SVP.API.Entities;
using SVP.API.Interfaces;

namespace SVP.API.Services;

public partial class SVPService: ISVPService
{
    public async Task<Illness> GetIllnessById(long illnessId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Illness> AddIllness(Illness illness)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Illness> EditIllness(Illness illness)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Illness> DeleteIllness(long illnessId)
    {
        throw new System.NotImplementedException();
    }
}