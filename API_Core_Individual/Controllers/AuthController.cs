using API_Core_BL.DTOs;
using API_Core_BL.Services.ClientService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API_Core_Individual.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IClientService _clientService;

        public AuthController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> SignInAsync(LoginDto loginDto)
        {
            return Ok(await _clientService.LoginAsync(loginDto));
        }
    }
}
