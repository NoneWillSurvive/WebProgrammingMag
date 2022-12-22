using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SVP.API.Entities;
using SVP.API.Interfaces;

namespace SVP.API.Controllers;

[Route("api/[controller]/[action]")]

public class SVPController : Controller
{
    private readonly ISVPService _service;
    
    public SVPController(ISVPService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<ActionResult<Patient>> GetPatientById(long patientId)
    {
        return Ok(await _service.GetPatientById(patientId));
    }

    [HttpPost]
    public async Task<ActionResult<Patient>> AddPatient(
        bool Gender,
        byte Age,
        string Name,
        [FromBody] Illness Illness,
        byte LevelAnxiety,
        byte LevelDepression,
        byte LevelHopelessness,
        byte LevelAsthenicSyndrome,
        bool HasAddiction
    )
    {
        var patient = new Patient()
        {
            Gender = Gender,
            Age = Age,
            Name = Name,
            IllnessId = Illness.Id,
            Illness = Illness,
            LevelAnxiety = LevelAnxiety,
            LevelDepression = LevelDepression,
            LevelHopelessness = LevelHopelessness,
            LevelAsthenicSyndrome = LevelAsthenicSyndrome,
            HasAddiction = HasAddiction,
            NeedHospitalization = false,
        };
        var needToHospitalization = await _service.NeedToHospitalization(patient);
        var recommendedDoctor = await _service.GetRecommendedDoctorByPatientId(patient);

        patient.NeedHospitalization = needToHospitalization;
        patient.RecommendedDoctorId = recommendedDoctor?.Id;
        patient.Illness = null;
            
        return Ok(await _service.AddPatient(patient));
    }

    [HttpPut]
    public async Task<ActionResult<Patient>> EditPatient(
        long Id,
        bool Gender,
        byte Age,
        string Name,
        [FromBody] Illness Illness,
        byte LevelAnxiety,
        byte LevelDepression,
        byte LevelHopelessness,
        byte LevelAsthenicSyndrome,
        bool HasAddiction
    )
    {
        
        var patient = new Patient()
        {
            Id = Id,
            Gender = Gender,
            Age = Age,
            Name = Name,
            IllnessId = Illness.Id,
            Illness = Illness,
            LevelAnxiety = LevelAnxiety,
            LevelDepression = LevelDepression,
            LevelHopelessness = LevelHopelessness,
            LevelAsthenicSyndrome = LevelAsthenicSyndrome,
            HasAddiction = HasAddiction,
            NeedHospitalization = false,
            RecommendedDoctorId = null,
        };
        
        var needToHospitalization = await _service.NeedToHospitalization(patient);
        var recommendedDoctor = await _service.GetRecommendedDoctorByPatientId(patient);

        patient.NeedHospitalization = needToHospitalization;
        patient.RecommendedDoctorId = recommendedDoctor?.Id;
        patient.Illness = null;
        
        return Ok(await _service.EditPatient(patient));
    }

    [HttpDelete]
    public async Task<ActionResult> DeletePatient(long patientId)
    {
        await _service.DeletePatient(patientId);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<Patient>> CheckAuthUser(bool isPatient, string login, string password)
    {
        return Ok(await _service.CheckLogInUser(isPatient, login, password));
    }
    
    [HttpPost]
    public async Task<ActionResult<long>> RegistrateUser(
        bool isPatient,
        string login, 
        string password,
        string userName, 
        byte age, 
        bool gender
    ) 
    {
        return Ok(await _service.RegistationUser(
            isPatient, login, password, userName, age, gender
        ));
    }

    [HttpGet]
    public async Task<ActionResult<Doctor>> GetDoctorById(long doctorId)
    {
        return Ok(await _service.GetDoctorById(doctorId));
    }

    [HttpPost]
    public async Task<ActionResult<Doctor>> AddDoctor(
        string Name,
        string Qualification
    )
    {
        var doctor = new Doctor()
        {
            Name = Name,
            Qualification = Qualification
        };
        return Ok(await _service.AddDoctor(doctor));
    }
    
    [HttpPut]
    public async Task<ActionResult<Doctor>> EditDoctor(
        long Id,
        string Name,
        string Qualification
    )
    {
        var doctor = new Doctor()
        {
            Id = Id,
            Name = Name,
            Qualification = Qualification
        };
        return Ok(await _service.EditDoctor(doctor));
    }
    
    [HttpDelete]
    public async Task<ActionResult<Doctor>> DeleteDoctor(long doctorId)
    {
        await _service.DeleteDoctor(doctorId);
        return Ok();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Illness>>> GetIllnesses()
    {
        return Ok(await _service.GetIllnesses());
    }
    
    // [HttpGet]
    // public Task<Doctor> GetRecommendedDoctorByPatientId()
    // {
    //     return Ok();
    // }
}