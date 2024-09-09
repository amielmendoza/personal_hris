import { Component, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-employee.form',
  templateUrl: './employee.form.component.html',
  styleUrl: './employee.form.component.scss',
})
export class EmployeeFormComponent implements OnInit {
  myFormGroup: FormGroup = new FormGroup({});
  currentStep = 0;
  steps = [''];
  constructor(
    public fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.myFormGroup = this.fb.group({
      firstName: ['', Validators.required],
      middleName: ['', Validators.required],
      lastName: ['', Validators.required],
      gender: ['', Validators.required],
      maritalStatus: ['', Validators.required],
      birthDate: ['', Validators.required],
      birthPlace: ['', Validators.required],
      mothersMaidenName: ['', Validators.required],
      contactNo: ['', Validators.required],
      emailAddress: ['', [Validators.required, Validators.email]],
      address: ['', Validators.required],
      emergencyContactPerson: ['', Validators.required],
      emergencyContactNumber: ['', Validators.required],
    });
  }

  get progressPercentage(): number {
    return ((this.currentStep + 1) / 3) * 100;
  }

  goToStep(index: number) {
    this.currentStep = index;
  }

  nextStep(): void {
    // this.myFormGroup.get('firstName')?.markAsDirty();
    // this.myFormGroup.get('middleName')?.markAsDirty();
    // this.myFormGroup.get('lastName')?.markAsDirty();
    // this.myFormGroup.get('gender')?.markAsDirty();
    // this.myFormGroup.get('maritalStatus')?.markAsDirty();
    // this.myFormGroup.get('birthDate')?.markAsDirty();
    // this.myFormGroup.get('birthPlace')?.markAsDirty();
    // this.myFormGroup.get('mothersMaidenName')?.markAsDirty();
    // this.myFormGroup.get('contactNo')?.markAsDirty();
    // this.myFormGroup.get('emailAddress')?.markAsDirty();
    // this.myFormGroup.get('address')?.markAsDirty();
    // this.myFormGroup.get('emergencyContactPerson')?.markAsDirty();
    // this.myFormGroup.get('emergencyContactNumber')?.markAsDirty();
    // if(!!this.myFormGroup.get('firstName')?.invalid) return;
    // if(!!this.myFormGroup.get('middleName')?.invalid) return;
    // if(!!this.myFormGroup.get('lastName')?.invalid) return;
    // if(!!this.myFormGroup.get('gender')?.invalid) return;
    // if(!!this.myFormGroup.get('maritalStatus')?.invalid) return;
    // if(!!this.myFormGroup.get('birthDate')?.invalid) return;
    // if(!!this.myFormGroup.get('birthPlace')?.invalid) return;
    // if(!!this.myFormGroup.get('mothersMaidenName')?.invalid) return;
    // if(!!this.myFormGroup.get('contactNo')?.invalid) return;
    // if(!!this.myFormGroup.get('emailAddress')?.invalid) return;
    // if(!!this.myFormGroup.get('address')?.invalid) return;
    // if(!!this.myFormGroup.get('emergencyContactPerson')?.invalid) return;
    // if(!!this.myFormGroup.get('emergencyContactNumber')?.invalid) return;

    if (this.currentStep < 2) {
      this.currentStep++;
    }
  }

  previousStep(): void {
    if (this.currentStep > 0) {
      this.currentStep--;
    }
  }

  triggerValidation(): void {
    Object.keys(this.myFormGroup.controls).forEach((field) => {
      const control = this.myFormGroup.get(field);
      control?.markAsTouched({ onlySelf: true });
    });
  }

  onSubmit() {
    console.log('Form submitted:', this.myFormGroup);
  }

  exitForm() {
    this.router.navigate(["dashboard/employees"]);
  }
}
