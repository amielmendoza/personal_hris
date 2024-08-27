import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { EmployeesComponent } from '../employees/employees.component';
// import { DashboardRoutingModule } from './dashboard.routing.module';
import { EmployeesModule } from '../employees/employees.module';

@NgModule({
  declarations: [DashboardComponent],
  exports: [DashboardComponent],
  imports: [CommonModule, FormsModule, BrowserModule, HttpClientModule, RouterModule, EmployeesModule],
})
export class DashboardModule {}
