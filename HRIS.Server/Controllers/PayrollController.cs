using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using HRIS.Application.Common.Models;
using HRIS.Application.Employees.Queries;
using HRIS.Application.Employees.ViewModels;
using HRIS.Application.Holidays.Queries;
using HRIS.Application.Holidays.ViewModels;
using HRIS.Application.Leaves.Commands;
using HRIS.Application.Leaves.Queries;
using HRIS.Application.Leaves.ViewModels;
using HRIS.Application.Loans.Commands;
using HRIS.Application.Loans.Commands.Delete;
using HRIS.Application.Loans.Queries;
using HRIS.Application.Loans.ViewModels;
using HRIS.Application.Payroll.Commands.Create;
using HRIS.Application.Payroll.Commands.Delete;
using HRIS.Application.Payroll.Queries;
using HRIS.Application.Payroll.ViewModels;
using HRIS.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HRIS.WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PayrollController : ApiControllerBase
    {
        [HttpGet("GetPendingPayrollComputationEmployees", Name = "GetPendingPayrollComputationEmployees")]
        public async Task<ActionResult<List<EmployeeDetailViewModel>>> GetPendingPayrollComputationEmployees(DateTime cutOffDate)
        {
            List<EmployeeDetailViewModel> employeeDetailViewModels = await Mediator.Send(new GetPendingPayrollComputationEmployeesQuery() { CutOffDate = cutOffDate });
            foreach (var employeeDetail in employeeDetailViewModels)
            {
                employeeDetail.LeaveAmount = 0;
                employeeDetail.UnpaidLeaveAmount = 0;
                DateTime cutoff1 = DateTime.ParseExact(DateTime.Now.AddMonths(-1).Month.ToString("d2") + "/25/" + DateTime.Now.AddMonths(-1).Year.ToString(), "MM/dd/yyyy", null);
                DateTime cutoff2 = DateTime.ParseExact(DateTime.Now.Month.ToString("d2") + "/10/" + DateTime.Now.Year.ToString(), "MM/dd/yyyy", null);
                DateTime cutoff3 = DateTime.ParseExact(DateTime.Now.Month.ToString("d2") + "/25/" + DateTime.Now.Year.ToString(), "MM/dd/yyyy", null);
                DateTime cutoff4 = DateTime.ParseExact(DateTime.Now.AddMonths(1).Month.ToString("d2") + "/10/" + DateTime.Now.AddMonths(1).Year.ToString(), "MM/dd/yyyy", null);
                if (cutOffDate == cutoff2)
                {
                    var cutoffApprovedLeaves = employeeDetail.Leaves.Where(u => u.StartDate > cutoff1 && u.StartDate < cutoff2 ||
                    u.EndDate > cutoff1 && u.EndDate < cutoff2 || (u.StartDate <= cutoff1 && cutoff1 < u.EndDate)).ToList();

                    foreach (EmployeeLeave leave in cutoffApprovedLeaves)
                    {
                        EmployeeLeaveViewModel objLeave = await Mediator.Send(new GetEmployeeLeaveByIdQuery { Id = leave.Id });
                        var fgLeaveStatus = objLeave.Status;
                        var fgLeaveWithPay = objLeave.WithPay;

                        if (fgLeaveStatus == "Approved")
                        {
                            var dtLeaveStartDate = leave.StartDate;
                            var dtLeaveEndDate = leave.EndDate;
                            int leaveDays = 0;

                            // Count days within cutoff
                            if (dtLeaveStartDate <= cutoff1)
                                dtLeaveStartDate = cutoff1.AddDays(1);
                            if (dtLeaveEndDate >= cutoff2)
                                dtLeaveEndDate = cutoff2.AddDays(1);

                            leaveDays = (dtLeaveEndDate - dtLeaveStartDate).Days + 1;

                            if (fgLeaveWithPay)
                                employeeDetail.LeaveAmount += leaveDays;
                            else
                                employeeDetail.UnpaidLeaveAmount += leaveDays;
                        }
                    }
                }
                else if (cutOffDate == cutoff3)
                {

                    List<EmployeeLeave> cutoffApprovedLeaves = employeeDetail.Leaves.Where(u => u.StartDate > cutoff2
                    || u.EndDate > cutoff2 || (u.StartDate <= cutoff2 && cutoff2 < u.EndDate)).ToList();

                    foreach (EmployeeLeave leave in cutoffApprovedLeaves)
                    {
                        EmployeeLeaveViewModel objLeave = await Mediator.Send(new GetEmployeeLeaveByIdQuery { Id = leave.Id });
                        var fgLeaveStatus = objLeave.Status;
                        var fgLeaveWithPay = objLeave.WithPay;

                        if (fgLeaveStatus == "Approved")
                        {
                            var dtLeaveStartDate = leave.StartDate;
                            var dtLeaveEndDate = leave.EndDate;

                            // Count days within cutoff
                            if (dtLeaveStartDate <= cutoff2)
                                dtLeaveStartDate = cutoff2.AddDays(1);
                            if (dtLeaveEndDate >= cutoff3)
                                dtLeaveEndDate = cutoff3.AddDays(1);

                            int leaveDays = (dtLeaveEndDate - dtLeaveStartDate).Days + 1;

                            if (fgLeaveWithPay)
                                employeeDetail.LeaveAmount += leaveDays;
                            else
                                employeeDetail.UnpaidLeaveAmount += leaveDays;
                        }
                    }
                }
            }

            return employeeDetailViewModels;
        }

        [HttpGet("GetPendingPayrollComputations", Name = "GetPendingPayrollComputations")]
        public async Task<ActionResult<ProcessPayrollComputationViewModel>> GetPendingPayrollComputations([FromQuery] GetPendingPayrollComputationsQuery query)
        {
            var result = await Mediator.Send(query);
            return result;
        }

        [HttpPost("CreatePayrollComputationEmployee", Name = "CreatePayrollComputationEmployee")]
        public async Task<ActionResult> CreatePayrollComputationEmployee(CreatePayrollComputationCommand command)
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
            await Mediator.Send(new DeletePayrollComputationCommand { Id = id });

            return NoContent();
        }

        [HttpPost("GetPayrollComputationByEmployeeId", Name = "GetPayrollComputationByEmployeeId")]
        public async Task<ActionResult<PayrollEmployeeInformationViewModel>> GetPayrollComputationByEmployeeId(GetPayrollComputationByIdQuery user)
        {
            PayrollEmployeeInformationViewModel employeePayslips = await Mediator.Send(user);

            return employeePayslips;
        }

        [HttpPost("AddUpdatePayrollRemarksByPayrollId", Name = "AddUpdatePayrollRemarksByPayrollId")]
        public async Task<ActionResult<PayrollEmployeeInformationViewModel>> AddUpdatePayrollRemarksByPayrollId(UpdatePayrollRemarksCommand user)
        {
            await Mediator.Send(user);

            return NoContent();
        }

        [HttpGet("GetEmployeesWithPayslips", Name = "GetEmployeesWithPayslips")]
        public async Task<ActionResult<List<EmployeeDetailViewModel>>> GetEmployeesWithPayslips(string SiteId)
        {
            Guid siteIdGuid = Guid.Parse(SiteId);
            return await Mediator.Send(new GetEmployeesWithPayslipBySiteQuery { SiteId = siteIdGuid });
        }


        [HttpGet("GetEmployeesWithPayslipsWithDepartment", Name = "GetEmployeesWithPayslipsWithDepartment")]
        public async Task<ActionResult<List<EmployeeDetailViewModel>>> GetEmployeesWithPayslipsWithDepartment(string SiteId, string DepartmentId)
        {
            Guid siteIdGuid = Guid.Parse(SiteId);
            Guid departmentIdGuid = Guid.Parse(DepartmentId);
            return await Mediator.Send(new GetEmployeesWithPayslipBySiteAndDepartmentQuery { SiteId = siteIdGuid, DepartmentId = departmentIdGuid});
        }

    }
}
