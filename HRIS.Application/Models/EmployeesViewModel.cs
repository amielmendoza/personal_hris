using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Application.Models;
public record EmployeesViewModel
{
    public Guid Id { get; set; }
    public required string EmployeeNo { get; set; }
    public required string Name { get; set; }
    public required string BirthDate { get; set; }
    public required string HireDate { get; set; }
    public required string EmploymentStatus { get; set; }
    public decimal Rate { get; set; }
    public required string Site { get; set; }
    public required string Position { get; set; }
    public required string Status { get; set; }
    public decimal LeaveBalance { get; set; }
}
