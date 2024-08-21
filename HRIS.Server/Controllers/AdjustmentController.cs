using HRIS.Application.Adjustments.Queries;
using HRIS.Application.Adjustments.ViewModels;
using HRIS.Application.Common.Models;
using HRIS.Application.Holidays.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HRIS.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AdjustmentController : ApiControllerBase
    {
        [HttpGet("references", Name = "GetAdjustmentFormReferences")]
        public async Task<ActionResult<AdjustmentFormReferencesViewModel>> GetAdjustmentFormReferences()
        {
            return await Mediator.Send(new GetAdjustmentFormReferencesQuery());
        }

        [HttpGet("adjustmentList", Name = "GetAdjustmentList")]
        public async Task<ActionResult<PaginatedList<AdjustmentViewModel>>> GetAdjustmentList([FromQuery] GetAdjustmentListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}", Name = "GetAdjustmentById")]
        public async Task<ActionResult<AdjustmentViewModel>> GetAdjustmentById(Guid id)
        {
            return await Mediator.Send(new GetAdjustmentByIdQuery { Id = id });
        }

        [HttpGet("CheckIfUsedForPayroll/{id}", Name = "CheckIfUsedForPayroll")]
        public async Task<ActionResult<bool>> CheckIfUsedForPayroll(Guid id)
        {
            return await Mediator.Send(new CheckIfUsedByPayrollQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateAdjustmentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateAdjustmentCommand command)
        {
            if (id != command.Id) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteAdjustmentCommand { Id = id });

            return NoContent();
        }
    }
}
