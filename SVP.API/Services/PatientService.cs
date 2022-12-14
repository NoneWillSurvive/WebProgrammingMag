using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        var patient = await _context.Patients
            .FirstOrDefaultAsync(x => x.Id == patientId
            );
        
        return patient;
    }

    public async Task<Patient> AddPatient(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
        return patient;
    }

    public async Task<Patient> EditPatient(Patient patient)
    {
        var _patient = await _context.Patients
            .FirstOrDefaultAsync(x => x.Id == patient.Id);
        _patient = patient;
        await _context.SaveChangesAsync();
        return _patient;
    }

    public async Task DeletePatient(long patientId)
    {
        var patient = await _context.Patients
            .FirstOrDefaultAsync(x => x.Id == patientId);
        if (patient is not null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
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