using HRIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Domain.Entities;
public record Employee : AuditableEntity
{
    public Employee()
    {
        //DirectReports = new HashSet<Employee>();
        //Certifications = new HashSet<EmployeeCertification>();
        //Leaves = new HashSet<EmployeeLeave>();
    }
    [Key]
    public Guid Id { get; private set; }

    [Required]
    public Guid UserId { get; private set; }

    [ForeignKey("UserId")]
    public User User { get; private set; }
    [Required]
    public string EmployeeNo { get; private set; }
    [Required]
    public DateTime HireDate { get; private set; }
    [Required]
    public string Position { get; private set; }
    public decimal? DailyRate { get; private set; }
    public decimal? MonthlyRate { get; private set; }
    public decimal? Allowance { get; private set; }
    public string SSS { get; private set; }
    public string TIN { get; private set; }
    public string PHIC { get; private set; }
    public string HDMF { get; private set; }
    public string BirthCertificate { get; private set; }
    public string BankAccountNumber { get; private set; }
    public bool Insurance { get; private set; }
    public DateTime? NBIClearanceExpiration { get; private set; }
    public DateTime? BrgyClearanceIssueDate { get; private set; }
    public DateTime? PoliceClearanceIssueDate { get; private set; }
    public DateTime? MedCertIssueDate { get; private set; }
    public DateTime? SwabTestResultDate { get; private set; }
    public int NoOfDependents { get; private set; }
    public DateTime? ContractEndDate { get; private set; }
   
    public string Trainings { get; private set; }
    public string Remarks { get; private set; }
    public string Status { get; private set; }
    public bool IsComplete
    {
        get
        {
            return !(String.IsNullOrEmpty(this.SSS)
                  && String.IsNullOrEmpty(this.PHIC)
                  && String.IsNullOrEmpty(this.HDMF));
        }
    }

    // New Site reference
    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public Guid? DepartmentId { get; private set; }
    public Department Department { get; private set; }

    public Guid? ContractEndReasonId { get; private set; }
    public ContractEndReason ContractEndReason { get; set; }

    public Guid EmployeeStatusId { get; private set; }
    public EmployeeStatus EmployeeStatus { get; private set; }

    public Employee(Guid id, Guid userId, string employeeNo, DateTime hireDate, string position, string status, decimal? dailyRate, decimal? monthlyRate, decimal? allowance, string sss, string tin, string phic, string hdmf, string birthCertificate, string bankAccountNumber, bool insurance, DateTime? nBIClearanceExpiration, DateTime? brgyClearanceIssueDate, DateTime? policeClearanceIssueDate, DateTime? medCertIssueDate, DateTime? swabTestResultDate, int noOfDependents, DateTime? contractEndDate, Guid? contractEndReasonId, string trainings, string remarks, Guid siteId, Guid? departmentId, Guid employeeStatusId)
    {
        Id = id;
        UserId = userId;
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
        NBIClearanceExpiration = nBIClearanceExpiration;
        BrgyClearanceIssueDate = brgyClearanceIssueDate;
        PoliceClearanceIssueDate = policeClearanceIssueDate;
        MedCertIssueDate = medCertIssueDate;
        SwabTestResultDate = swabTestResultDate;
        NoOfDependents = noOfDependents;
        ContractEndDate = contractEndDate;
        ContractEndReasonId = contractEndReasonId;
        Trainings = trainings;
        Remarks = remarks;
        SiteId = siteId;
        DepartmentId = departmentId;
        EmployeeStatusId = employeeStatusId;
    }

}
