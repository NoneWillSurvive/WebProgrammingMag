using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SVP.API.Entities;
using SVP.API.Interfaces;

namespace SVP.API.Services;

public partial class SVPService: ISVPService
{
    public async Task<long> CheckLogInUser(bool isPatient, string login, string password)
    {
        var userData = await _context.AuthData
            .Include(x => x.Patient)
            .Include(x => x.Doctor)
            .FirstOrDefaultAsync(x => x.Login == login && x.Password == password);

        return isPatient ? userData.Patient.Id : userData.Doctor.Id;
    }

    public async Task<long> RegistationUser(
        bool isPatient, string login, string password, string userName, byte age, bool gender
    )
    {
        var authData = new AuthData() {
            Login = login,
            Password = password,
            Patient = isPatient ? new Patient()
            {
                Name = userName,
                Age = age,
                Gender = gender
            } : null,
            Doctor = !isPatient ? new Doctor()
            {
                Name = userName
            } : null
        };
        await _context.AuthData.AddAsync(authData);
        await _context.SaveChangesAsync();
        return isPatient ? authData.Patient.Id : authData.Doctor.Id;
    }
}