using HRIS.Application.Employees.Queries;
using HRIS.Application.Employees.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class EmployeeController : ApiControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EmployeeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public EmployeeController(ILogger<EmployeeController> logger, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeViewModel>>> GetEmployeeList([FromQuery] GetEmployeeListQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
