#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SVP.API.Data;
using SVP.API.Entities;
using SVP.API.Interfaces;

namespace SVP.API.Services;

public partial class SVPService: ISVPService
{
    private readonly SVPContext _context;
    private const string Healthy = "Здоровый";
    private const string Depressive = "Депрессивное расстройство";
    private const string Affective = "Аффективное расстройство";
    private const string Schizophrenic = "Шизофреническое расстройство";
    private const string Autistic = "Аутистическое расстройство";
    private const string Personality = "Расстройство личности";
    private const string Anxiety = "Тревожное расстройство";
    private const string Nervous = "Нервное расстройство";
    
    public SVPService(SVPContext context)
    {
        _context = context;
    }

    public async Task<Patient> GetPatientById(long patientId)
    {
        var patient = await _context.Patients
            .Include(x => x.Illness)
            .Include(x => x.RecommendedDoctor)
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
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
        return patient;
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

    public async Task<bool> NeedToHospitalization(Patient patient)
    {
        if (patient is null) 
            throw new Exception("Пациент не найден");

        return patient.Illness.Type switch
        {
            // 26) Правило направления пациента с шизофреническим заболеванием, депрессией и безнадежностью на госпитализацию 
            Schizophrenic when patient.LevelDepression is >= 20 and <= 63 &&
                               patient.LevelHopelessness is >= 29 and <= 63 => true,
            
            // 27) Правило направления пациента с шизофреническим заболеванием и депрессией на госпитализацию 
            Schizophrenic when patient.LevelDepression is >= 20 and <= 63 => true,
            
            // 28) Правило направления пациента с шизофреническим заболеванием и безнадежностью на госпитализацию 
            Schizophrenic when patient.LevelHopelessness is >= 29 and <= 63 => true,
            
            _ => false
        };
    }
    
    public async Task<Doctor> GetRecommendedDoctorByPatientId(Patient patient)
    {
        if (patient is null) 
            throw new Exception("Пациент не найден");

        var recommendedDoctorByIllnessType = await GetRecommendedDoctorByIllnessType(patient);
        if (recommendedDoctorByIllnessType is not null)
        {
            return recommendedDoctorByIllnessType;
        }

        var recommendedDoctorByHasAddiction = await GetRecommendedDoctorByHasAddiction(patient);
        if (recommendedDoctorByHasAddiction is not null)
        {
            return recommendedDoctorByHasAddiction;
        }

        return null;
    }

    private async Task<Doctor?> GetRecommendedDoctorByIllnessType(Patient patient)
    {
        
        switch (patient.Illness.Type)
        {
            // 1) Правило направления пациента здорового, но с выраженной тревогой 
            case Healthy when patient.LevelAnxiety is >= 36 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Клинический психолог"));
                    
            // 2) Правило направления пациентa здорового, но с тяжелой депрессией 
            case Healthy when patient.LevelDepression is >= 29 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Клинический психолог"));
                    
            // 3) Правило направления пациента здорового, но с выраженной астенией 
            case Healthy when patient.LevelAsthenicSyndrome is >= 101 and <= 120:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Клинический психолог"));
                    
            // 4) Правило направления пациента с нервным расстройством и с выраженной тревогой  
            case Nervous when patient.LevelAnxiety is >= 36 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Клинический психолог"));
            
            // 5) Правило направления пациента с нервным расстройством и с тяжелой депрессией  
            case Nervous when patient.LevelDepression is >= 29 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Клинический психолог"));
            
            // 6) Правило направления пациента с нервным расстройством и с выраженной астенией  
            case Nervous when patient.LevelAsthenicSyndrome is >= 101 and <= 120:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Клинический психолог"));
            
            // 7) Правило направления пациента с аутистическим расстройством и с выраженной тревогой 
            case Autistic when patient.LevelAnxiety is >= 36 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Клинический психолог"));
            
            // 8) Правило направления пациента с аутистическим расстройством и с тяжелой депрессией 
            case Autistic when patient.LevelDepression is >= 29 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Клинический психолог"));
            
            // 9) Правило направления пациента с аутистическим расстройством и с выраженной астенией 
            case Nervous when patient.LevelAsthenicSyndrome is >= 101 and <= 120:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Клинический психолог"));

            // 10) Правило направления пациента с тревожным расстройством и со средней/выраженной тревогой
            case Anxiety when patient.LevelAnxiety is >= 36 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 11 - 12: Если нет психотерапевта то отправить к психиатору
            // 12) Правило направления пациента с депрессивным расстройством и выраженной тревогой
            case Depressive when patient.LevelAnxiety is >= 36 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психотерапевт"));
            
            // 11) Правило направления пациента с депрессивным расстройством и с выраженной тревогой 
            case Depressive when patient.LevelAnxiety is >= 36 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 13) Правило направления пациента без выраженного диагноза, но с тяжелой депрессией и выраженной астенией
            case Healthy when patient.LevelDepression is >= 29 and <= 63 && patient.LevelAsthenicSyndrome is >= 101 and <= 120:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 14) Правило направления пациента с нервным расстройством, с тяжелой депрессией, а также выраженной астенией 
            case Nervous when patient.LevelDepression is >= 29 and <= 63 && patient.LevelAsthenicSyndrome is >= 101 and <= 120:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 15) Правило направления пациента с аутистическим расстройством, с тяжелой депрессией, а также выраженной астенией 
            case Autistic when patient.LevelDepression is >= 29 and <= 63 && patient.LevelAsthenicSyndrome is >= 101 and <= 120:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 16-19 связаны с зависимостью
            
            // 20) Правило направления пациента с нервным расстройством и с тяжелой депрессией 
            case Nervous when patient.LevelDepression is >= 20 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 21) Правило направления пациента с аффективным расстройством и с умеренной/тяжелой депрессией  
            case Affective when patient.LevelDepression is >= 20 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 22) Правило направления пациента с аффективным расстройством и с умеренной/выраженной тревогой  
            case Affective when patient.LevelAnxiety is >= 22 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 23) Правило направления пациента с расстройством личности и с умеренной/тяжелой депрессией 
            case Personality when patient.LevelDepression is >= 20 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 24) Правило направления пациента с расстройством личности и с умеренной/выраженной тревогой
            case Personality when patient.LevelAnxiety is >= 22 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
            
            // 25) Правило направления пациента с депрессией и безнадежностью на госпитализацию 
            case Personality when patient.LevelAnxiety is >= 22 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Психиатр"));
        }

        return null;
    }

    private async Task<Doctor?> GetRecommendedDoctorByHasAddiction(Patient patient)
    {
        switch (patient.HasAddiction)
        {
            // 16) Правило направления пациента с депрессией и зависимостью 
            case true when patient.LevelDepression is >= 20 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Накролог"));
            // 17) Правило направления пациента с тревогой и зависимостью
            case true when patient.LevelAnxiety is >= 36 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Накролог"));
            // 18) Правило направления пациента с астенией и зависимостью 
            case true when patient.LevelAsthenicSyndrome is >= 101 and <= 120:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Накролог"));
            // 19) Правило направления пациента с безнадежностью и зависимостью  
            case true when patient.LevelHopelessness is >= 29 and <= 63:
                return await _context.Doctors
                    .FirstOrDefaultAsync(x => x.Qualification.Contains("Накролог"));
        }

        return null;
    }
    
    // 29) Правило определения экземпляров класса «Психиатр»
    private static bool IsPsychiatrist(Doctor doctor)
    {
        return HasQualification("Психиатр", doctor);
    }
    
    // 30) Правило определения экземпляров класса «Психотерапевт» 
    private static bool IsPsychotherapist(Doctor doctor)
    {
        Console.WriteLine(doctor.Name);
        return HasQualification("Психотерапевт", doctor);
    }
    
    // 31) Правило определения экземпляров класса «Клинический психолог» 
    private static bool IsClinicalPsychologist(Doctor doctor)
    {
        return HasQualification("Клинический психолог", doctor);
    }
    
    // 32) Правило определения экземпляров класса «Нарколог» 
    private static bool IsNarcologyExpert(Doctor doctor)
    {
        return HasQualification("Накролог", doctor);
    }

    private static bool HasQualification(string findQualification, Doctor doctor)
    {
        return doctor.Qualification.Contains(findQualification);
    }

}