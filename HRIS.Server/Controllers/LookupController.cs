using HRIS.Application.Employees.Queries;
using HRIS.Application.Lookups.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRIS.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class LookupController : ApiControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<LookupController> _logger;
        private readonly IConfiguration _configuration;

        public LookupController(ILogger<LookupController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeLookupsViewModel>> GetLookups() {
            var employees = await Mediator.Send(new GetLookupsQuery());
            return employees;
        }
    }

    
}
