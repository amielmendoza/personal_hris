import {
  AfterContentInit,
  Component,
  ContentChildren,
  EventEmitter,
  Input,
  OnInit,
  Output,
  QueryList,
} from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-stepper',
  templateUrl: './stepper.component.html',
  styleUrl: './stepper.component.scss',
})
export class StepperComponent implements OnInit, AfterContentInit {
  @ContentChildren('stepFormTemplate') stepForms?: QueryList<any>;
  @ContentChildren('stepTemplate') steps?: QueryList<any>;
  @Input() parentForm?: FormGroup;
  @Output() onSubmit: EventEmitter<FormGroup> = new EventEmitter<FormGroup>();
  // steps = ['Step 1', 'Step 2', 'Step 3'];
  currentStep = 0;
  constructor(public fb: FormBuilder) {
  }

  ngAfterContentInit(): void {
    console.log('steps', this.steps);
    console.log('stepFormTemplate', this.stepForms);
  }

  ngOnInit(): void {
    console.log('parentForm', this.parentForm);
  }

  get progressPercentage(): number {
    return ((this.currentStep + 1) / (!!this.steps ? this.steps.length : 0)) * 100;
  }

  goToStep(index: number) {
    this.currentStep = index;
  }

  nextStep() {
    let arrayCount = this.steps?.length ?? 0;
    if (this.currentStep < arrayCount - 1) {
      this.currentStep++;
    }
  }

  previousStep() {
    if (this.currentStep > 0) {
      this.currentStep--;
    }
  }

  submitForm(): void {
      this.onSubmit.emit(); // Emit the FormGroup when submitting

  }
}
