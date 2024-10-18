using HRIS.Application.Employees.Commands;
using HRIS.Application.Employees.Queries;
using HRIS.Application.Employees.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            var employees = await Mediator.Send(query);
            return employees;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var employee = await Mediator.Send(command);
            return employee;
        }
    }
}
