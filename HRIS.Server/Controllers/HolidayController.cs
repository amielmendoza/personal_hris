using DocumentFormat.OpenXml.Office2010.ExcelAc;
using HRIS.Application.Common.Models;
using HRIS.Application.Employees.ViewModels;
using HRIS.Application.Holidays.Commands;
using HRIS.Application.Holidays.Queries;
using HRIS.Application.Holidays.ViewModels;
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
    public class HolidayController : ApiControllerBase
    {
        [HttpGet("references", Name = "GetHolidayFormReferences")]
        public async Task<ActionResult<HolidayFormReferencesViewModel>> GetHolidayFormReferences()
        {
            return await Mediator.Send(new GetHolidayFormReferencesQuery());
        }

        [HttpGet("holidayList", Name = "GetHolidayList")]
        public async Task<ActionResult<PaginatedList<HolidayViewModel>>> GetHolidayList([FromQuery] GetHolidayListQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}", Name = "GetHolidayById")]
        public async Task<ActionResult<HolidayViewModel>> GetHolidayById(Guid id)
        {
            return await Mediator.Send(new GetHolidayByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateHolidayCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateHolidayCommand command)
        {
            if (id != command.Id) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteHolidayCommand { Id = id });

            return NoContent();
        }

        [HttpGet("holidays", Name = "GetAllHolidays")]
        public async Task<ActionResult<List<HolidayViewModel>>> GetAllHolidays(DateTime cutOffDate)
        {
            List<HolidayViewModel> holidayViewModels = await Mediator.Send(new GetAllHolidaysQuery() { Year = cutOffDate.Year });
            List<HolidayViewModel> holidaysWithinCutoff = new List<HolidayViewModel>();
            
            DateTime cutoff1 = DateTime.ParseExact(DateTime.Now.AddMonths(-1).Month.ToString("d2") + "/25/" + DateTime.Now.AddMonths(-1).Year.ToString(), "MM/dd/yyyy", null);
            DateTime cutoff2 = DateTime.ParseExact(DateTime.Now.Month.ToString("d2") + "/10/" + DateTime.Now.Year.ToString(), "MM/dd/yyyy", null);
            DateTime cutoff3 = DateTime.ParseExact(DateTime.Now.Month.ToString("d2") + "/25/" + DateTime.Now.Year.ToString(), "MM/dd/yyyy", null);
            DateTime cutoff4 = DateTime.ParseExact(DateTime.Now.AddMonths(1).Month.ToString("d2") + "/10/" + DateTime.Now.AddMonths(1).Year.ToString(), "MM/dd/yyyy", null);
            foreach (var holiday in holidayViewModels)
            {
                if (cutOffDate == cutoff3)
                {
                    if(holiday.Date > cutoff2 &&  holiday.Date <= cutoff3) 
                        holidaysWithinCutoff.Add(holiday);
                }
                else if(cutOffDate == cutoff2)
                {
                    if (holiday.Date > cutoff1 && holiday.Date <= cutoff2)
                        holidaysWithinCutoff.Add(holiday);
                }
            }

            return holidaysWithinCutoff;
        }
    }
}
