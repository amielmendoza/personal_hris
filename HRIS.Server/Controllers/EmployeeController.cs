using HRIS.Application.Common.Helpers;
using HRIS.Application.Common.Interfaces;
using HRIS.Application.Common.Models;
using HRIS.Application.Employees.Commands;
using HRIS.Application.Employees.Queries;
using HRIS.Application.Employees.ViewModels;
using HRIS.Application.Payroll.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRIS.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmployeeController : ApiControllerBase
    {
        private IIdentityService _identityService;
        public EmployeeController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpGet("exportemployeelist", Name = "ExportEmployeeList")]
        public async Task<FileResult> ExportEmployeeList()
        {
            var result = await Mediator.Send(new ExportEmployeeListQuery());

            return File(result.Content, result.ContentType, result.FileName);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<EmployeeViewModel>>> GetEmployeesWithPagination([FromQuery] GetEmployeeListQuery query)
        {
            return await Mediator.Send(query);
        }

        //[HttpGet("search", Name = "SearchEmployee")]
        //public async Task<ActionResult<PaginatedList<EmployeeViewModel>>> SearchEmployee([FromQuery] SearchEmployeeByFilterQuery query)
        //{
        //    return await Mediator.Send(query);
        //}

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDetailViewModel>> GetEmployeeById(Guid id)
        {
            return await Mediator.Send(new GetEmployeeDetailByIdQuery { Id = id });
        }

        [HttpGet("GetEmployeeDetailByEmpNo/{empNo}", Name = "GetEmployeeDetailByEmpNo")]
        public async Task<ActionResult<EmployeeDetailViewModel>> GetEmployeeDetailByEmpNo(string empNo)
        {
            return await Mediator.Send(new GetEmployeeDetailByEmpNoQuery { EmpNo = empNo });
        }

        [HttpGet("GetEmployeeDetailByRateFrequency/{frequency}", Name = "GetEmployeeDetailByRateFrequency")]
        public async Task<ActionResult<List<EmployeeDetailViewModel>>> GetEmployeeDetailByRateFrequency(string frequency)
        {
            return await Mediator.Send(new GetEmployeeDetailByRateFrequencyQuery { Frequency = frequency });
        }

        [HttpGet("GetAllActiveEmployees", Name = "GetAllActiveEmployees")]
        public async Task<ActionResult<List<EmployeeDetailViewModel>>> GetAllActiveEmployees()
        {
            return await Mediator.Send(new GetAllActiveEmployeesQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateEmployeeCommand command)
        {
            if (id != command.Id) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteEmployeeCommand { Id = id });

            return NoContent();
        }


        [HttpGet("GetResignedEmployeesBySiteAndDepartment", Name = "GetResignedEmployeesBySiteAndDepartment")]
        public async Task<ActionResult<List<EmployeeDetailViewModel>>> GetResignedEmployeesBySiteAndDepartment(string SiteId, string DepartmentId)
        {
            Guid siteIdGuid = Guid.Parse(SiteId);
            Guid departmentIdGuid = Guid.Parse(DepartmentId);
            return await Mediator.Send(new GetResignedEmployeesBySiteAndDepartmentQuery{ SiteId = siteIdGuid, DepartmentId = departmentIdGuid });
        }

        [HttpGet("GetResignedEmployeesBySite", Name = "GetResignedEmployeesBySite")]
        public async Task<ActionResult<List<EmployeeDetailViewModel>>> GetResignedEmployeesBySite(string SiteId)
        {
            Guid siteIdGuid = Guid.Parse(SiteId);
            return await Mediator.Send(new GetResignedEmployeesBySiteQuery { SiteId = siteIdGuid });
        }


    }
}
