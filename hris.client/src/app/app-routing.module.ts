import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { AuthGuard } from './auth.guard';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full', canActivate: [AuthGuard] }, // Redirect to home

  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: '/home' } // Wildcard route for 404
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
