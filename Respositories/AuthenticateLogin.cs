using AppOwnsData.DB;
using AppOwnsData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppOwnsData.Respositories
{
    public class AuthenticateLogin : ILogin
    {
        private readonly AppDbcontext _context;

        public AuthenticateLogin(AppDbcontext context)
        {
            _context = context;
        }
        public async Task<UserLogin> AuthenticateUser(string email, string passcode)
        {
            var succeeded = await _context.UserLogin.FirstOrDefaultAsync(authUser => authUser.email == email && authUser.password == passcode);
            return succeeded;
        }

        public async Task<IEnumerable<UserLogin>> getuser()
        {
            return await _context.UserLogin.ToListAsync();
        }
    }
}
