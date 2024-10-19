
using HRIS.Application.Employees.ViewModels;
using HRIS.Application.Lookups.ViewModels;
using HRIS.Domain.Common;
using HRIS.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRIS.Application.Employees.Queries
{
    public record GetLookupsQuery : IRequest<EmployeeLookupsViewModel>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetLookupsQueryHandler : IRequestHandler<GetLookupsQuery, EmployeeLookupsViewModel>
    {
        private readonly IContractEndReasonRepository _contractEndReasonRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeLeaveStatusRepository _employeeLeaveStatusRepository;
        private readonly IEmployeeLeaveTypeRepository _employeeLeaveTypeRepository;
        private readonly IEmployeeLoanStatusRepository _employeeLoanStatusRepository;
        private readonly IEmployeeLoanTypeRepository _employeeLoanTypeRepository;
        private readonly IEmployeeStatusRepository _employeeStatusRepository;
        private readonly ISiteRepository _siteRepository;
        private readonly ILogger<GetLookupsQueryHandler> _logger;

        public GetLookupsQueryHandler(IContractEndReasonRepository contractEndReasonRepository, ILogger<GetLookupsQueryHandler> logger, IDepartmentRepository departmentRepository, IEmployeeLeaveStatusRepository employeeLeaveStatusRepository, IEmployeeLeaveTypeRepository employeeLeaveTypeRepository, IEmployeeLoanStatusRepository employeeLoanStatusRepository, IEmployeeLoanTypeRepository employeeLoanTypeRepository, IEmployeeStatusRepository employeeStatusRepository, ISiteRepository siteRepository)
        {
            _logger = logger;
            _contractEndReasonRepository = contractEndReasonRepository;
            _departmentRepository = departmentRepository;
            _employeeLeaveStatusRepository = employeeLeaveStatusRepository;
            _employeeLeaveTypeRepository = employeeLeaveTypeRepository;
            _employeeLoanStatusRepository = employeeLoanStatusRepository;
            _employeeLoanTypeRepository = employeeLoanTypeRepository;
            _employeeStatusRepository = employeeStatusRepository;
            _siteRepository = siteRepository;
        }

        public async Task<EmployeeLookupsViewModel> Handle(GetLookupsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contractEndReasons = await _contractEndReasonRepository.GetAllAsync().ConfigureAwait(true);
                var departments = await _departmentRepository.GetAllAsync().ConfigureAwait(true);
                var employeeLeaveStatuses = await _employeeLeaveStatusRepository.GetAllAsync().ConfigureAwait(true);
                var employeeLeaveTypes = await _employeeLeaveTypeRepository.GetAllAsync().ConfigureAwait(true);
                var employeeLoanStatuses = await _employeeLoanStatusRepository.GetAllAsync().ConfigureAwait(true);
                var employeeLoanTypes = await _employeeLoanTypeRepository.GetAllAsync().ConfigureAwait(true);
                var employeeStatuses = await _employeeStatusRepository.GetAllAsync().ConfigureAwait(true);
                var sites = await _siteRepository.GetAllAsync().ConfigureAwait(true);

                var result = new EmployeeLookupsViewModel()
                {
                    ContractEndReasons = contractEndReasons.Select(x => new ReferenceEntity(x.Id, x.Name, x.Code, x.Description)).ToList(),
                    Departments = departments.Select(x => new ReferenceEntity(x.Id, x.Name, x.Code, x.Description)).ToList(),
                    EmployeeLeaveStatuses = employeeLeaveStatuses.Select(x => new ReferenceEntity(x.Id, x.Name, x.Code, x.Description)).ToList(),
                    EmployeeLeaveTypes = employeeLeaveTypes.Select(x => new ReferenceEntity(x.Id, x.Name, x.Code, x.Description)).ToList(),
                    EmployeeLoanStatuses = employeeLoanStatuses.Select(x => new ReferenceEntity(x.Id, x.Name, x.Code, x.Description)).ToList(),
                    EmployeeLoanTypes = employeeLoanTypes.Select(x => new ReferenceEntity(x.Id, x.Name, x.Code, x.Description)).ToList(),
                    EmployeeStatuses = employeeStatuses.Select(x => new ReferenceEntity(x.Id, x.Name, x.Code, x.Description)).ToList(),
                    Sites = sites.Select(x => new ReferenceEntity(x.Id, x.Name, x.Code, x.Description)).ToList(),
                };

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetEmployeeListQueryHandler");
                throw;
            }
        }
    }
}
