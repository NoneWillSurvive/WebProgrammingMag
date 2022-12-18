using System.Threading.Tasks;
using SVP.API.Entities;

namespace SVP.API.Interfaces;

public partial interface ISVPService
{
    public Task<long> CheckLogInUser(bool isPatient, string login, string password);

    public Task<long> RegistationUser(
        bool isPatient,
        string login, 
        string password,
        string userName, 
        byte age,
        bool gender
    );
}