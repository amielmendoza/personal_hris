import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee.form.component.html',
  styleUrls: ['./employee.form.component.scss'],
})
export class EmployeeFormComponent implements OnInit {
  employeeForm: FormGroup = new FormGroup({});
  currentStep = 0;
  formSteps: { title: string; fields: FormField[] }[] = [
    {
      title: 'Personal Information',
      fields: [
        {
          name: 'firstName',
          label: 'First Name',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'middleName',
          label: 'Middle Name',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'lastName',
          label: 'Last Name',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
          nextRow: true,
        },
        {
          name: 'address',
          label: 'Address',
          type: 'text',
          validators: ['', Validators.required],
          col: 8,
          nextRow: true,
        },

        {
          name: 'gender',
          label: 'Gender',
          type: 'radio',
          options: ['Male', 'Female'],
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'maritalStatus',
          label: 'Marital Status',
          type: 'select',
          options: ['Single', 'Married', 'Divorced'],
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'birthDate',
          label: 'Birth Date',
          type: 'date',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'birthPlace',
          label: 'Birth Place',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
          nextRow: true,
        },
        {
          name: 'contactNo',
          label: 'Contact Number',
          type: 'tel',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'emailAddress',
          label: 'Email Address',
          type: 'email',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'mothersMaidenName',
          label: "Mother's Maiden Name",
          type: 'text',
          validators: ['', Validators.required],
          col: 4,
          nextRow: true,
        },
        {
          name: 'emergencyContactPerson',
          label: 'Emergency Contact Person',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'emergencyContactNumber',
          label: 'Emergency Contact Number',
          type: 'tel',
          validators: ['', Validators.required],
          col: 2,
        },
      ],
    },
    {
      title: 'Employment Information',
      fields: [
        {
          name: 'employeeNumber',
          label: 'Employee Number',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'hiringDate',
          label: 'Hiring Date',
          type: 'date',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'contractEndDate',
          label: 'Contract End Date',
          type: 'date',
          validators: ['', Validators.required],
          col: 2,
          nextRow: true,
        },
        {
          name: 'site',
          label: 'Site',
          type: 'select',
          options: ['Imus', 'Tarlac', 'Manila'],
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'department',
          label: 'Department',
          type: 'select',
          options: ['HR', 'IT', 'Sales'],
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'position',
          label: 'Position',
          type: 'select',
          options: ['HR', 'Plumber', 'Contractor'],
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'employmentStatus',
          label: 'Employment Status',
          type: 'select',
          options: ['Regular', 'Contractual', 'Probationary'],
          validators: ['', Validators.required],
          col: 2,
          nextRow: true,
        },
        {
          name: 'dailyRate',
          label: 'Daily Rate',
          type: 'number',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'monthlyRate',
          label: 'Monthly Rate',
          type: 'number',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'allowance',
          label: 'Allowance',
          type: 'number',
          validators: ['', Validators.required],
          col: 2,
        },
      ],
    },
    {
      title: 'Document Information',
      fields: [
        {
          name: 'bankAccountNumber',
          label: 'Bank Account Number',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
          nextRow: true,
        },
        {
          name: 'sss',
          label: 'SSS',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'tin',
          label: 'TIN',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'phic',
          label: 'PHIC',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'hdmf',
          label: 'HDMF',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
          nextRow: true,
        },
        {
          name: 'numberOfDependents',
          label: 'Number of Dependents',
          type: 'number',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'birthCertificate',
          label: 'Birth Certificate',
          type: 'checkbox',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'insurance',
          label: 'Insurance',
          type: 'checkbox',
          validators: ['', Validators.required],
          col: 2,
          nextRow: true,
        },
        {
          name: 'nbiDate',
          label: 'NBI Issue Date',
          type: 'date',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'brgyClearanceDate',
          label: 'NBI Issue Date',
          type: 'date',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'policeClearanceDate',
          label: 'Police Clearance Issue Date',
          type: 'date',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'medicalCertificateDate',
          label: 'Medical Certificate Issue Date',
          type: 'date',
          validators: ['', Validators.required],
          col: 2,
          nextRow: true,
        },
        {
          name: 'certificates',
          label: 'Certificates/Training',
          type: 'text',
          validators: ['', Validators.required],
          col: 4,
          nextRow: true,
        },
        {
          name: 'status',
          label: 'Status',
          type: 'select',
          options: ['Complete', 'Incomplete'],
          validators: ['', Validators.required],
          col: 2,
        },
      ],
    },
    {
      title: 'Leave Information',
      fields: [
        {
          name: 'leaveCredits',
          label: 'Leave Credits',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
        },
        {
          name: 'leaveBalance',
          label: 'Leave Balance',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
        },
      ],
    },
    {
      title: 'Login Information',
      fields: [
        {
          name: 'password',
          label: 'Password',
          type: 'text',
          validators: ['', Validators.required],
          col: 2,
          disabled: true,
        },
        {
          name: 'role',
          label: 'Role',
          type: 'select',
          options: [
            'HR Administrator',
            'Employee',
            'HR Compensation & Benefits',
            'HR Payroll',
          ],
          validators: ['', Validators.required],
          col: 2,
        },
      ],
    },
  ];

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    const formGroup: { [key: string]: any } = {};
    this.formSteps.forEach((step) => {
      step.fields.forEach((field) => {
        formGroup[field.name] = field.validators;
      });
    });
    this.employeeForm = this.fb.group(formGroup);
  }

  get progressPercentage(): number {
    return ((this.currentStep + 1) / this.formSteps.length) * 100;
  }

  nextStep(): void {
    if (this.currentStep < this.formSteps.length - 1) {
      const currentStepFields = this.formSteps[this.currentStep].fields;
      const isCurrentStepValid = currentStepFields.every(
        (field) => this.employeeForm.get(field.name)?.valid
      );

      if (isCurrentStepValid) {
        this.currentStep++;
      } else {
        this.markCurrentStepAsTouched();
      }
    }
  }

  private markCurrentStepAsTouched(): void {
    const currentStepFields = this.formSteps[this.currentStep].fields;
    currentStepFields.forEach((field) => {
      this.employeeForm.get(field.name)?.markAsTouched();
    });
  }

  previousStep(): void {
    if (this.currentStep > 0) {
      this.currentStep--;
    }
  }

  onSubmit(): void {
    if (this.employeeForm.valid) {
      console.log('Form submitted:', this.employeeForm.value);
    } else {
      this.employeeForm.markAllAsTouched();
    }
  }

  exitForm(): void {
    this.router.navigate(['dashboard/employees']);
  }
}

interface FormField {
  name: string;
  label: string;
  type: string;
  validators: (
    | string
    | ((control: AbstractControl<any, any>) => ValidationErrors | null)
  )[];
  col: number;
  nextRow?: boolean;
  options?: string[]; // Add this line
  disabled?: boolean;
}
