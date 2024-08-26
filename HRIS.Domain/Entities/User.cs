using HRIS.Domain.Common;
using HRIS.Domain.Types;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Domain.Entities;
public record User : AuditableEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string FirstName { get; set; }

    public string MiddleName { get; set; }
    [Required]
    public string LastName { get; set; }

    public string MotherMaidenName { get; set; }

    public string Extension { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    public string BirthPlace { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string ContactNo { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public GenderType Gender { get; set; }
    [Required]
    public MaritalStatusType MaritalStatus { get; set; }
    [Required]
    public string EmergencyContact { get; set; }
    [Required]
    public string EmergencyContactNo { get; set; }
    [Required]
    public string PasswordHash { get; set; }

    public Employee Employee { get; init; }
}
