
using HRIS.Application.Employees.ViewModels;
using HRIS.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRIS.Application.Employees.Queries
{
    public record GetLookupsQuery : IRequest<List<EmployeeViewModel>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetLookupsQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeViewModel>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<GetLookupsQueryHandler> _logger;

        public GetLookupsQueryHandler(IEmployeeRepository employeeRepository, ILogger<GetLookupsQueryHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<List<EmployeeViewModel>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employees = await _employeeRepository.GetAllPaginatedAsync(request.PageNumber, request.PageSize);

                var employeeViewModels = employees.Select(x => new EmployeeViewModel(x.Id, x.User, x.EmployeeNo, x.HireDate, x.Position, x.Status,
                    x.DailyRate, x.MonthlyRate, x.Allowance,
                    x.SSS, x.TIN, x.PHIC, x.HDMF,
                    x.BirthCertificate, x.BankAccountNumber,
                    x.Insurance, x.NBIClearanceExpiration,
                    x.BrgyClearanceIssueDate, x.PoliceClearanceIssueDate, x.MedCertIssueDate, x.SwabTestResultDate, x.NoOfDependents, x.ContractEndDate, x.ContractEndReason,
                    x.Trainings, x.Remarks, x.Site, x.EmployeeStatus, x.Department)).ToList();

                return employeeViewModels;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetEmployeeListQueryHandler");
                throw;
            }
        }
    }
}
