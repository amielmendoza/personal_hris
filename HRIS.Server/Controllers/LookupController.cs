using HRIS.Application.Common.Helpers;
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
    public class LookupController : ApiControllerBase
    {
        [HttpGet("references", Name = "GetEmployeeFormReferences")]
        public async Task<ActionResult<EmployeeFormReferencesViewModel>> GetEmployeeFormReferences()
        {
            return await Mediator.Send(new GetEmployeeFormReferencesQuery());
        }

        [HttpGet("getSites", Name = "GetSites")]
        public async Task<ActionResult<EmployeeFormReferencesViewModel>> GetSites()
        {
            return await Mediator.Send(new GetEmployeeFormReferencesQuery());
        }

        [HttpGet("getDepartments", Name = "GetDepartments")]
        public async Task<ActionResult<EmployeeFormReferencesViewModel>> GetDepartments()
        {
            return await Mediator.Send(new GetEmployeeFormReferencesQuery());
        }
    }
}
