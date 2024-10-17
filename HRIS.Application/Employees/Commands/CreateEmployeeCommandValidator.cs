using FluentValidation;

namespace HRIS.Application.Employees.Commands
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.EmployeeNo)
                .NotEmpty().WithMessage("EmployeeNo is required.")
                .MaximumLength(50).WithMessage("EmployeeNo must not exceed 50 characters.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MaximumLength(100).WithMessage("FirstName must not exceed 100 characters.");

            RuleFor(x => x.MiddleName)
                .MaximumLength(100).WithMessage("MiddleName must not exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.MiddleName));

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.")
                .MaximumLength(100).WithMessage("LastName must not exceed 100 characters.");

            RuleFor(x => x.MotherMaidenName)
                .MaximumLength(100).WithMessage("MotherMaidenName must not exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.MotherMaidenName));

            RuleFor(x => x.Extension)
                .MaximumLength(10).WithMessage("Extension must not exceed 10 characters.")
                .When(x => !string.IsNullOrEmpty(x.Extension));

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("BirthDate is required.");

            RuleFor(x => x.BirthPlace)
                .MaximumLength(200).WithMessage("BirthPlace must not exceed 200 characters.")
                .When(x => !string.IsNullOrEmpty(x.BirthPlace));

            RuleFor(x => x.Address)
                .MaximumLength(500).WithMessage("Address must not exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Address));

            RuleFor(x => x.ContactNo)
                .MaximumLength(20).WithMessage("ContactNo must not exceed 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.ContactNo));

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Invalid gender value.");

            RuleFor(x => x.MaritalStatus)
                .IsInEnum().WithMessage("Invalid marital status value.");

            RuleFor(x => x.EmergencyContact)
                .MaximumLength(100).WithMessage("EmergencyContact must not exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.EmergencyContact));

            RuleFor(x => x.EmergencyContactNo)
                .MaximumLength(20).WithMessage("EmergencyContactNo must not exceed 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.EmergencyContactNo));

            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("PasswordHash is required.");

            RuleFor(x => x.HireDate)
                .NotEmpty().WithMessage("HireDate is required.");

            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Position is required.")
                .MaximumLength(100).WithMessage("Position must not exceed 100 characters.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(50).WithMessage("Status must not exceed 50 characters.");

            RuleFor(x => x.DailyRate)
                .GreaterThanOrEqualTo(0).WithMessage("DailyRate must be greater than or equal to 0.")
                .When(x => x.DailyRate.HasValue);

            RuleFor(x => x.MonthlyRate)
                .GreaterThanOrEqualTo(0).WithMessage("MonthlyRate must be greater than or equal to 0.")
                .When(x => x.MonthlyRate.HasValue);

            RuleFor(x => x.Allowance)
                .GreaterThanOrEqualTo(0).WithMessage("Allowance must be greater than or equal to 0.")
                .When(x => x.Allowance.HasValue);

            RuleFor(x => x.SSS)
                .MaximumLength(20).WithMessage("SSS must not exceed 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.SSS));

            RuleFor(x => x.TIN)
                .MaximumLength(20).WithMessage("TIN must not exceed 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.TIN));

            RuleFor(x => x.PHIC)
                .MaximumLength(20).WithMessage("PHIC must not exceed 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.PHIC));

            RuleFor(x => x.HDMF)
                .MaximumLength(20).WithMessage("HDMF must not exceed 20 characters.")
                .When(x => !string.IsNullOrEmpty(x.HDMF));

            RuleFor(x => x.BirthCertificate)
                .MaximumLength(50).WithMessage("BirthCertificate must not exceed 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.BirthCertificate));

            RuleFor(x => x.BankAccountNumber)
                .MaximumLength(50).WithMessage("BankAccountNumber must not exceed 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.BankAccountNumber));

            RuleFor(x => x.NoOfDependents)
                .GreaterThanOrEqualTo(0).WithMessage("NoOfDependents must be greater than or equal to 0.");

            RuleFor(x => x.Trainings)
                .MaximumLength(500).WithMessage("Trainings must not exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Trainings));

            RuleFor(x => x.Remarks)
                .MaximumLength(500).WithMessage("Remarks must not exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Remarks));
        }
    }
}