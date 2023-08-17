using AppOwnsData.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppOwnsData.Respositories
{
    public interface ILogin
    {
        Task<IEnumerable<UserLogin>> getuser();
        Task<UserLogin> AuthenticateUser(string username, string passcode);

    }
}
