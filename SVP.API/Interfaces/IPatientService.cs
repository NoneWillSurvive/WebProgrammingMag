using System.Collections.Generic;
using System.Threading.Tasks;
using SVP.API.Entities;

namespace SVP.API.Interfaces;

public partial interface ISVPService
{
    public Task<Patient> GetPatientById(long patientId);
    
    public Task<Patient> AddPatient(Patient patient);

    public Task<Patient> EditPatient(Patient patient);
    
    public Task DeletePatient(long patientId);

    public Task<bool> NeedToHospitalization(Patient patient);

    public Task<Doctor> GetRecommendedDoctorByPatientId(Patient patient);
}