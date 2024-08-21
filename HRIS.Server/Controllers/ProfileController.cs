using HRIS.Application.Common.Helpers;
using HRIS.Application.Common.Interfaces;
using HRIS.Application.Common.Models;
using HRIS.Application.Employees.Commands;
using HRIS.Application.Employees.Queries;
using HRIS.Application.Employees.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HRIS.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProfileController : ApiControllerBase
    {
        private IIdentityService _identityService;
        public ProfileController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        
        [HttpGet("{id}", Name = "GetEmployeeDetailByUserId")]
        public async Task<ActionResult<ProfileDetailViewModel>> GetEmployeeDetailByUserId(Guid id)
        {
            return await Mediator.Send(new GetEmployeeDetailByUserIdQuery { Id = id });
        }
    }
}
