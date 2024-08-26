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
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; init; }

    [ForeignKey("UserId")]
    public required User User { get; init; }
    [Required]
    public string EmployeeNo { get; set; }
    [Required]
    public DateTime HireDate { get; set; }
    [Required]
    public string Position { get; set; }
    public decimal? DailyRate { get; set; }
    public decimal? MonthlyRate { get; set; }
    public decimal? Allowance { get; set; }
    public string SSS { get; set; }
    public string TIN { get; set; }
    public string PHIC { get; set; }
    public string HDMF { get; set; }
    public string BirthCertificate { get; set; }
    public string BankAccountNumber { get; set; }
    public bool Insurance { get; set; }
    public DateTime? NBIClearanceExpiration { get; set; }
    public DateTime? BrgyClearanceIssueDate { get; set; }
    public DateTime? PoliceClearanceIssueDate { get; set; }
    public DateTime? MedCertIssueDate { get; set; }
    public DateTime? SwabTestResultDate { get; set; }
    public int NoOfDependents { get; set; }
    public DateTime? ContractEndDate { get; set; }
    public Guid? ContractEndReasonId { get; set; }
    public string Trainings { get; set; }
    public string Remarks { get; set; }
    public string Status { get; set; }
    public bool IsComplete
    {
        get
        {
            return !(String.IsNullOrEmpty(this.SSS)
                  && String.IsNullOrEmpty(this.PHIC)
                  && String.IsNullOrEmpty(this.HDMF));
        }
    }

    //public bool IsActive
    //{
    //    get
    //    {
    //        return this.EmploymentStatus.Name != "Terminated" &&
    //            this.EmploymentStatus.Name != "Resigned" &&
    //            this.EmploymentStatus.Name != "Retired" &&
    //            this.EmploymentStatus.Name != "Deceased" &&
    //            this.EmploymentStatus.Name != "AWOL";
    //    }
    //}
    //public Person PersonalDetail { get; set; }
    //public Employee Manager { get; set; }
    //public Guid? EmploymentStatusId { get; set; }
    //public EmploymentStatus EmploymentStatus { get; set; }
    //public Guid? SiteId { get; set; }
    //public Site Site { get; set; }
    //public Guid? DepartmentId { get; set; }
    //public Department Department { get; set; }
    //public ICollection<Employee> DirectReports { get; private set; }
    //public ICollection<EmployeeCertification> Certifications { get; private set; }
    //public EmployeeLeaveCredit LeaveCredit { get; private set; }
    //public ICollection<EmployeeLeave> Leaves { get; private set; }
    //public ICollection<Adjustment> Adjustments { get; private set; }
    //public ICollection<PayrollComputation> Computations { get; private set; }
}
