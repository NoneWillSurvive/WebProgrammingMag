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
    
    [HttpPost]
    public async Task<ActionResult<Patient>> AddPatient(Patient patient)
    {
        
    }
}