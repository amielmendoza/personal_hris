// import { Component, OnInit } from '@angular/core';
// import {
//   FormArray,
//   FormBuilder,
//   FormControl,
//   FormGroup,
//   Validators,
// } from '@angular/forms';
// import { ActivatedRoute, Router } from '@angular/router';

// @Component({
//   selector: 'app-employee.form',
//   templateUrl: './employee.form.component.html',
//   styleUrl: './employee.form.component.scss',
// })
// export class EmployeeFormComponent implements OnInit {
//   myFormGroup: FormGroup = new FormGroup({});
//   currentStep = 0;
//   steps = [''];
//   constructor(
//     public fb: FormBuilder,
//     private router: Router,
//     private route: ActivatedRoute
//   ) {}

//   ngOnInit(): void {
//     this.myFormGroup = this.fb.group({
//       firstName: ['', Validators.required],
//       middleName: ['', Validators.required],
//       lastName: ['', Validators.required],
//       gender: ['', Validators.required],
//       maritalStatus: ['', Validators.required],
//       birthDate: ['', Validators.required],
//       birthPlace: ['', Validators.required],
//       mothersMaidenName: ['', Validators.required],
//       contactNo: ['', Validators.required],
//       emailAddress: ['', [Validators.required, Validators.email]],
//       address: ['', Validators.required],
//       emergencyContactPerson: ['', Validators.required],
//       emergencyContactNumber: ['', Validators.required],
//     });
//   }

//   get progressPercentage(): number {
//     return ((this.currentStep + 1) / 3) * 100;
//   }

//   goToStep(index: number) {
//     this.currentStep = index;
//   }

//   nextStep(): void {
//     this.myFormGroup.get('firstName')?.markAsDirty();
//     this.myFormGroup.get('middleName')?.markAsDirty();
//     this.myFormGroup.get('lastName')?.markAsDirty();
//     this.myFormGroup.get('gender')?.markAsDirty();
//     this.myFormGroup.get('maritalStatus')?.markAsDirty();
//     this.myFormGroup.get('birthDate')?.markAsDirty();
//     this.myFormGroup.get('birthPlace')?.markAsDirty();
//     this.myFormGroup.get('mothersMaidenName')?.markAsDirty();
//     this.myFormGroup.get('contactNo')?.markAsDirty();
//     this.myFormGroup.get('emailAddress')?.markAsDirty();
//     this.myFormGroup.get('address')?.markAsDirty();
//     this.myFormGroup.get('emergencyContactPerson')?.markAsDirty();
//     this.myFormGroup.get('emergencyContactNumber')?.markAsDirty();
//     if(!!this.myFormGroup.get('firstName')?.invalid) return;
//     if(!!this.myFormGroup.get('middleName')?.invalid) return;
//     if(!!this.myFormGroup.get('lastName')?.invalid) return;
//     if(!!this.myFormGroup.get('gender')?.invalid) return;
//     if(!!this.myFormGroup.get('maritalStatus')?.invalid) return;
//     if(!!this.myFormGroup.get('birthDate')?.invalid) return;
//     if(!!this.myFormGroup.get('birthPlace')?.invalid) return;
//     if(!!this.myFormGroup.get('mothersMaidenName')?.invalid) return;
//     if(!!this.myFormGroup.get('contactNo')?.invalid) return;
//     if(!!this.myFormGroup.get('emailAddress')?.invalid) return;
//     if(!!this.myFormGroup.get('address')?.invalid) return;
//     if(!!this.myFormGroup.get('emergencyContactPerson')?.invalid) return;
//     if(!!this.myFormGroup.get('emergencyContactNumber')?.invalid) return;

//     if (this.currentStep < 2) {
//       this.currentStep++;
//     }
//   }

//   previousStep(): void {
//     if (this.currentStep > 0) {
//       this.currentStep--;
//     }
//   }

//   triggerValidation(): void {
//     Object.keys(this.myFormGroup.controls).forEach((field) => {
//       const control = this.myFormGroup.get(field);
//       control?.markAsTouched({ onlySelf: true });
//     });
//   }

//   onSubmit() {
//     console.log('Form submitted:', this.myFormGroup);
//   }

//   exitForm() {
//     this.router.navigate(["dashboard/employees"]);
//   }
// }

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
          col: 12,
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
