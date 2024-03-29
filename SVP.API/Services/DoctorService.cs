﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SVP.API.Entities;
using SVP.API.Interfaces;

namespace SVP.API.Services;

public partial class SVPService: ISVPService
{
    public async Task<List<Doctor>> GetDoctors()
    {
        var doctors = await _context.Doctors.ToListAsync();
        
        return doctors;
    }
    public async Task<Doctor> GetDoctorById(long doctorId)
    {
        var doctor = await _context.Doctors
            .FirstOrDefaultAsync(x => x.Id == doctorId);
            
        return doctor;
    }

    public async Task<Doctor> AddDoctor(Doctor doctor)
    {
        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor> EditDoctor(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public async Task DeleteDoctor(long doctorId)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctorId);
        if (doctor is not null)
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
    }
}