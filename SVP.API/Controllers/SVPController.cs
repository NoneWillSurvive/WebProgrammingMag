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
    public async Task<ActionResult<Patient>> AddPatient(Patient patient)
    {
        return Ok(await _service.AddPatient(patient));
    }

    [HttpPut]
    public async Task<ActionResult<Patient>> EditPatient(Patient patient)
    {
        return Ok(await _service.EditPatient(patient));
    }

    [HttpDelete]
    public async Task<ActionResult> DeletePatient(long patientId)
    {
        await _service.DeletePatient(patientId);
        return Ok();
    }

    // [HttpGet]
    // public Task<bool> NeedToHospitalization()
    // {
    //     return Ok();
    // }

    // [HttpGet]
    // public Task<Doctor> GetRecommendedDoctorByPatientId()
    // {
    //     return Ok();
    // }
}