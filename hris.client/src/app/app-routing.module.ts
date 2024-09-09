import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './auth.guard';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { EmployeesComponent } from './pages/employees/employees.component';
import { HomeComponent } from './pages/home/home.component';
import { EmployeeFormComponent } from './pages/employees/form/employee.form/employee.form.component';
import { EmployeeListComponent } from './pages/employees/list/employee.list.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    children: [
      { path: 'home', component: HomeComponent },
      {
        path: 'employees',
        component: EmployeesComponent,
        children: [
          { path: '', component: EmployeeListComponent },
          { path: 'list', component: EmployeeListComponent },
          { path: 'form', component: EmployeeFormComponent }
        ]
      },
    ],
    canActivate: [AuthGuard],
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' }, // Default route
  { path: '**', redirectTo: '/login' }, // Wildcard route to handle 404
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
