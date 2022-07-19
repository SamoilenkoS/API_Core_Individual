using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Core_BL.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(string username, string role);
    }
}
