using System.Threading.Tasks;
using SVP.API.Entities;

namespace SVP.API.Interfaces;

public partial interface ISVPService
{
    public Task<Patient> GetPatientById(long patientId);
    
    public Task<Patient> AddPatient(Patient patient);

    public Task<Patient> EditPatient(Patient patient);
    
    public Task<Patient> DeletePatient(long patientId);

    public Task<bool> NeedToHospitalization();

    public Task<Doctor> GetRecommendedDoctorByPatientId();
}