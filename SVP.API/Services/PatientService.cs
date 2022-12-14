using System.Threading.Tasks;
using SVP.API.Data;
using SVP.API.Entities;
using SVP.API.Interfaces;

namespace SVP.API.Services;

public partial class SVPService: ISVPService
{
    private readonly SVPContext _context;

    public SVPService(SVPContext context)
    {
        _context = context;
    }


    public async Task<Patient> GetPatientById(long patientId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Patient> AddPatient(Patient patient)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Patient> EditPatient(Patient patient)
    {
        throw new System.NotImplementedException();
    }

    public async Task<Patient> DeletePatient(long patientId)
    {
        throw new System.NotImplementedException();
    }

    public async Task<bool> NeedToHospitalization()
    {
        throw new System.NotImplementedException();
    }

    public async Task<Doctor> GetRecommendedDoctorByPatientId()
    {
        throw new System.NotImplementedException();
    }
}