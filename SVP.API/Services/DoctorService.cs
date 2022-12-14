using System.Threading.Tasks;
using SVP.API.Data;
using SVP.API.Entities;
using SVP.API.Interfaces;

namespace SVP.API.Services;

public partial class SVPService: ISVPService
{
    public async Task<Doctor> GetDoctorById(long doctorId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Doctor> AddDoctor(Doctor doctor)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Doctor> EditDoctor(Doctor doctor)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Doctor> DeleteDoctor(long doctorId)
    {
        throw new System.NotImplementedException();
    }
}