using HRIS.Domain.Types;
using MediatR;

namespace HRIS.Application.Employees.Commands
{
    public record CreateEmployeeCommand : IRequest<Guid>
    {
        public string EmployeeNo { get; set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string MotherMaidenName { get; private set; }
        public string Extension { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string BirthPlace { get; private set; }
        public string Address { get; private set; }
        public string ContactNo { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public MaritalStatus MaritalStatus { get; private set; }
        public string EmergencyContact { get; private set; }
        public string EmergencyContactNo { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public Guid EmployeeStatusId { get; set; }
        public Guid SiteId { get; set; }

        public Guid DepartmentId { get; set; }
        public decimal? DailyRate { get; set; }
        public decimal? MonthlyRate { get; set; }
        public decimal? Allowance { get; set; }
        public string? SSS { get; set; }
        public string? TIN { get; set; }
        public string? PHIC { get; set; }
        public string? HDMF { get; set; }
        public string? BirthCertificate { get; set; }
        public string? BankAccountNumber { get; set; }
        public bool Insurance { get; set; }
        public DateTime? NBIClearanceExpiration { get; set; }
        public DateTime? BrgyClearanceIssueDate { get; set; }
        public DateTime? PoliceClearanceIssueDate { get; set; }
        public DateTime? MedCertIssueDate { get; set; }
        public DateTime? SwabTestResultDate { get; set; }
        public int NoOfDependents { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public Guid? ContractEndReasonId { get; set; }
        public string? Trainings { get; set; }
        public string? Remarks { get; set; }
    }
}