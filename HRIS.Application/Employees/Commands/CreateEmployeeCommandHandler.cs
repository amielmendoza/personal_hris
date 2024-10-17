using HRIS.Domain.Entities;
using HRIS.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRIS.Application.Employees.Commands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateEmployeeHandler> _logger;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, ILogger<CreateEmployeeHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var user = new User(Guid.NewGuid(), request.FirstName, request.MiddleName, request.LastName, 
                        request.MotherMaidenName, 
                        request.Extension, 
                        request.BirthDate, 
                        request.BirthPlace, 
                        request.Address, 
                        request.ContactNo, 
                        request.Email,
                        request.Gender,
                        request.MaritalStatus,
                        request.EmergencyContact,
                        request.EmergencyContactNo,
                        request.PasswordHash);

                    await _userRepository.AddAsync(user);

                    if (user == null)
                    {
                        throw new Exception("User not found");
                    }

                    var employee = new Employee(
                        Guid.NewGuid(),
                        user.Id,
                        request.EmployeeNo,
                        request.HireDate,
                        request.Position,
                        request.Status,
                        request.DailyRate,
                        request.MonthlyRate,
                        request.Allowance,
                        request.SSS,
                        request.TIN,
                        request.PHIC,
                        request.HDMF,
                        request.BirthCertificate,
                        request.BankAccountNumber,
                        request.Insurance,
                        request.NBIClearanceExpiration,
                        request.BrgyClearanceIssueDate,
                        request.PoliceClearanceIssueDate,
                        request.MedCertIssueDate,
                        request.SwabTestResultDate,
                        request.NoOfDependents,
                        request.ContractEndDate,
                        request.ContractEndReasonId,
                        request.Trainings,
                        request.Remarks,
                        request.SiteId,
                        request.EmployeeStatusId,
                        request.DepartmentId
                    );

                    await _employeeRepository.AddAsync(employee);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    await _unitOfWork.CommitTransactionAsync();

                    return employee.Id;
                }
                catch (Exception)
                {
                    await _unitOfWork.RollbackTransactionAsync();
                    throw;
                }
            }
        }
    }
}