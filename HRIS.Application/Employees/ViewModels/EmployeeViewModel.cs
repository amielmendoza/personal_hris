using HRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Employees.ViewModels
{
    public record EmployeeViewModel
    {
        public Guid Id { get; private set; }
        public User User { get; init; }
        public string EmployeeNo { get; private set; }
        public DateTime HireDate { get; private set; }
        public string Position { get; private set; }
        public decimal? DailyRate { get; private set; }
        public decimal? MonthlyRate { get; private set; }
        public decimal? Allowance { get; private set; }
        public string? SSS { get; private set; }
        public string? TIN { get; private set; }
        public string? PHIC { get; private set; }
        public string? HDMF { get; private set; }
        public string? BirthCertificate { get; private set; }
        public string? BankAccountNumber { get; private set; }
        public bool Insurance { get; private set; }
        public DateTime? NBIClearanceExpiration { get; private set; }
        public DateTime? BrgyClearanceIssueDate { get; private set; }
        public DateTime? PoliceClearanceIssueDate { get; private set; }
        public DateTime? MedCertIssueDate { get; private set; }
        public DateTime? SwabTestResultDate { get; private set; }
        public int NoOfDependents { get; private set; }
        public DateTime? ContractEndDate { get; private set; }
        public ContractEndReason? ContractEndReason { get; private set; }
        public string? Trainings { get; private set; }
        public string? Remarks { get; private set; }
        public string? Status { get; set; }
        public Site Site { get; private set; }
        public Department Department { get; private set; }
        public EmployeeStatus EmployeeStatus { get; private set; }

        public bool IsComplete =>
            !string.IsNullOrEmpty(SSS) &&
            !string.IsNullOrEmpty(PHIC) &&
            !string.IsNullOrEmpty(HDMF);

        public EmployeeViewModel(Guid id, User user, string employeeNo, DateTime hireDate, string position, string status, decimal? dailyRate, decimal? monthlyRate, decimal? allowance, string? sss, string? tin, string? phic, string? hdmf, string? birthCertificate, string? bankAccountNumber, bool insurance, DateTime? nbiClearanceExpiration, DateTime? brgyClearanceIssueDate, DateTime? policeClearanceIssueDate, DateTime? medCertIssueDate, DateTime? swabTestResultDate, int noOfDependents, DateTime? contractEndDate, ContractEndReason contractEndReason, string? trainings, string? remarks, Site site, EmployeeStatus employeeStatus, Department department)
        {
            Id = id;
            User = user;
            EmployeeStatus = employeeStatus;
            Site = site;
            EmployeeNo = employeeNo;
            HireDate = hireDate;
            Position = position;
            Status = status;
            DailyRate = dailyRate;
            MonthlyRate = monthlyRate;
            Allowance = allowance;
            SSS = sss;
            TIN = tin;
            PHIC = phic;
            HDMF = hdmf;
            BirthCertificate = birthCertificate;
            BankAccountNumber = bankAccountNumber;
            Insurance = insurance;
            NBIClearanceExpiration = nbiClearanceExpiration;
            BrgyClearanceIssueDate = brgyClearanceIssueDate;
            PoliceClearanceIssueDate = policeClearanceIssueDate;
            MedCertIssueDate = medCertIssueDate;
            SwabTestResultDate = swabTestResultDate;
            NoOfDependents = noOfDependents;
            ContractEndDate = contractEndDate;
            ContractEndReason = contractEndReason;
            Trainings = trainings;
            Remarks = remarks;
            Department = department;
        }
    }
}
