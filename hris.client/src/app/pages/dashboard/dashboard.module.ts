import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard.component';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { EmployeesModule } from '../employees/employees.module';
import { HomeModule } from '../home/home.module';

@NgModule({
  declarations: [DashboardComponent],
  exports: [DashboardComponent],
  imports: [CommonModule, FormsModule, BrowserModule, RouterModule, EmployeesModule, HomeModule],
})
export class DashboardModule {}
