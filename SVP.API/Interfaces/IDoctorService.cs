using System.Collections.Generic;
using System.Threading.Tasks;
using SVP.API.Entities;

namespace SVP.API.Interfaces;

public partial interface ISVPService
{
    public Task<List<Doctor>> GetDoctors();
    public Task<Doctor> GetDoctorById(long doctorId);
    
    public Task<Doctor> AddDoctor(Doctor doctor);

    public Task<Doctor> EditDoctor(Doctor doctor);
    
    public Task DeleteDoctor(long doctorId);
}