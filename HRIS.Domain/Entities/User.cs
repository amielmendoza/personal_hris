using HRIS.Domain.Common;
using HRIS.Domain.Types;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Domain.Entities;
public record User : AuditableEntity
{
    public User()
    {
        
    }
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

    public Employee Employee { get; private set; }

    public User(Guid id, string firstName, string middleName, string lastName, string motherMaidenName, string extension, DateTime birthDate,
        string birthPlace,
        string address,
        string contactNo,
        string email,
        Gender gender,
        MaritalStatus maritalStatus,
        string emergencyContact,
        string emergencyContactNo,
        string passwordHash)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        MotherMaidenName = motherMaidenName;
        Extension = extension;
        BirthDate = birthDate;
        BirthPlace = birthPlace;
        Address = address;
        ContactNo = contactNo;
        Email = email;
        Gender = gender;
        MaritalStatus = maritalStatus;
        EmergencyContact = emergencyContact;
        EmergencyContactNo = emergencyContactNo;
        PasswordHash = passwordHash;
    }
}
