import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { StepperComponent } from './stepper.component';
import { SplitCasePipe } from '../../pipes/split-case.pipe';

@NgModule({
  declarations: [StepperComponent, SplitCasePipe],
  exports: [StepperComponent, SplitCasePipe],
  imports: [CommonModule, FormsModule, BrowserModule, RouterModule, ReactiveFormsModule],
})
export class StepperModule {}
