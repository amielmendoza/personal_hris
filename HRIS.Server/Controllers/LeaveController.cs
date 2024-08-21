using HRIS.Application.Common.Models;
using HRIS.Application.Employees.Queries;
using HRIS.Application.Employees.ViewModels;
using HRIS.Application.Leaves.Commands;
using HRIS.Application.Leaves.Commands.Delete;
using HRIS.Application.Leaves.Queries;
using HRIS.Application.Leaves.ViewModels;
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
    public class LeaveController : ApiControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        public LeaveController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("references", Name = "GetEmployeeLeaveReferences")]
        public async Task<ActionResult<EmployeeLeaveReferencesViewModel>> GetEmployeeLeaveReferences()
        {
            return await Mediator.Send(new GetEmployeeLeaveReferencesQuery());
        }

        [HttpGet("leaveList", Name = "GetEmployeeLeaveList")]
        public async Task<ActionResult<PaginatedList<EmployeeLeaveViewModel>>> GetEmployeeLeaveList([FromQuery] GetLeaveListQuery query)
        {

            return await Mediator.Send(query);
        }

        [HttpGet("approvalList", Name = "GetEmployeeLeaveApprovalList")]
        public async Task<ActionResult<PaginatedList<EmployeeLeaveViewModel>>> GetEmployeeLeaveApprovalList([FromQuery] GetLeaveApprovalQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}", Name = "GetEmployeeLeaveById")]
        public async Task<ActionResult<EmployeeLeaveViewModel>> GetEmployeeLeaveById(Guid id)
        {
            return await Mediator.Send(new GetEmployeeLeaveByIdQuery { Id = id });
        }

        [DisableRequestSizeLimit]
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CreateLeaveCommand command)
        {
            if (command.File != null)
            {
                command.FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                if (!Directory.Exists(command.FilePath))
                {
                    Directory.CreateDirectory(command.FilePath);
                }
            }
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("DownloadFile")]
        [AllowAnonymous]
        public async Task<FileResult> DownloadFile(Guid fileId)
        {
            var file = await Mediator.Send(new GetEmployeeLeaveAttachmentByLeaveIdQuery() { Id = fileId });

            return File(file.FileContent, file.FileType, file.FileName);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateLeaveCommand command)
        {
            if (id != command.Id) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("updateApproval/{id}", Name = "UpdateApproval")]
        public async Task<ActionResult> UpdateApproval(Guid id, UpdateApprovalCommand command)
        {
            if (id != command.Id) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteLeaveCommand { Id = id });

            return NoContent();
        }

        [HttpPut("cancel/{id}")]
        public async Task<ActionResult> Cancel(Guid id)
        {
            await Mediator.Send(new UpdateApprovalCommand { Id = id });

            return NoContent();
        }

        [Authorize]
        [HttpPut("approve/{id}")]
        public async Task<ActionResult> Approve(Guid id)
        {
            await Mediator.Send(new UpdateApprovalCommand { Id = id });

            return NoContent();
        }

        [Authorize]
        [HttpPut("deny/{id}")]
        public async Task<ActionResult> Deny(Guid id)
        {
            await Mediator.Send(new UpdateApprovalCommand { Id = id });

            return NoContent();
        }

        [HttpGet("GetEmployeeDetailById/{id}", Name = "GetEmployeeDetailById")]
        public async Task<ActionResult<EmployeeDetailViewModel>> GetEmployeeDetailById(Guid id)
        {
            return await Mediator.Send(new GetEmployeeDetailByIdQuery { Id = id });
        }
    }
}
