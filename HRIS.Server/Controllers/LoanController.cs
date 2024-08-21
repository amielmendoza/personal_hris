using HRIS.Application.Common.Models;
using HRIS.Application.Employees.Queries;
using HRIS.Application.Employees.ViewModels;
using HRIS.Application.Loans.Commands;
using HRIS.Application.Loans.Commands.Delete;
using HRIS.Application.Loans.Queries;
using HRIS.Application.Loans.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HRIS.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class LoanController : ApiControllerBase
    {
        [HttpGet("references", Name = "GetEmployeeLoanReferences")]
        public async Task<ActionResult<EmployeeLoanReferencesViewModel>> GetEmployeeLoanReferences()
        {
            return await Mediator.Send(new GetEmployeeLoanReferencesQuery());
        }

        [HttpGet("loanList", Name = "GetEmployeeLoanList")]
        public async Task<ActionResult<PaginatedList<EmployeeLoanViewModel>>> GetEmployeeLoanList([FromQuery] GetLoanListQuery query)
        {

            return await Mediator.Send(query);
        }

        [HttpGet("{id}", Name = "GetEmployeeLoanById")]
        public async Task<ActionResult<EmployeeLoanViewModel>> GetEmployeeLoanById(Guid id)
        {
            return await Mediator.Send(new GetEmployeeLoanByIdQuery { Id = id });
        }

        [HttpGet("summary", Name = "GetEmployeeLoanSummaryById")]
        public async Task<ActionResult<EmployeeLoanSummaryViewModel>> GetEmployeeLoanSummaryById(Guid id)
        {
            return await Mediator.Send(new GetEmployeeLoanSummaryQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateLoanCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateLoanCommand command)
        {
            if (id != command.Id) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteLoanCommand { Id = id });

            return NoContent();
        }
    }
}
