import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { EmployeesComponent } from './employees.component';
import { EmployeeFormComponent } from './form/employee.form/employee.form.component';
import { EmployeeListComponent } from './list/employee.list.component';
import { StepperModule } from '../../components/stepper/stepper.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LookupApiService } from '../../services/lookup-api.service';
import { ToastNotificationModule } from '../../components/toast-notification/toast-notification.module';

@NgModule({
  declarations: [EmployeesComponent, EmployeeFormComponent, EmployeeListComponent],
  exports: [EmployeesComponent, EmployeeFormComponent, EmployeeListComponent],
  imports: [CommonModule, FormsModule, BrowserModule, RouterModule, StepperModule, ReactiveFormsModule, NgbModule],
  providers: [LookupApiService]
})
export class EmployeesModule {}
